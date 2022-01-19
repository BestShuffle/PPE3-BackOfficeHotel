using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balladins
{
    // Classe gérant les différents éléments du cinéma dans la base de données
    class BalladinsDbMethods
    {
        // Charge l'hotel et les réservations
        public static void loadAll(int idHotel)
        {
            loadHotel(idHotel);
            loadReservations();
        }

        // Charge l'hôtel voulu depuis la base de données
        public static void loadHotel(int idHotel)
        {
            Globals.db.connect();

            Globals.db.execute("SELECT * FROM hotel WHERE idH = " + idHotel);
            while (Globals.db.read())
            {
                int id = (int)Globals.db.getData("idH");
                String nom = (String)Globals.db.getData("nomH");
                String adresse = (String)Globals.db.getData("adr1");
                String compAdresse = (String)Globals.db.getData("adr2");
                String ville = (String)Globals.db.getData("ville");
                String codePostal = (String)Globals.db.getData("cp");
                String telephone = (String)Globals.db.getData("tel");
                String desCourt = (String)Globals.db.getData("descourt");
                String desLong = (String)Globals.db.getData("deslong");
                double prix = (double)Globals.db.getData("prix");
                String motDePasse = (String)Globals.db.getData("mdp");

                Globals.hotel = new Hotel(id, nom, adresse, compAdresse, ville,
                    codePostal, telephone, desCourt, desLong, prix, motDePasse);
            }

            Globals.db.disconnect();

            loadEquipements();
            loadChambres();
        }

        // Charge les equipements d'un hotel depuis la base de données
        public static void loadEquipements()
        {
            Globals.hotel.setEquipements(new List<Equipement>());

            Globals.db.connect();

            Globals.db.execute("SELECT * FROM equipement JOIN equiper ON equipement.idE = equiper.idE " +
                       "WHERE equiper.idH = " + Globals.hotel.getId());
            while (Globals.db.read())
            {
                int id = (int)Globals.db.getData("idE");
                String libelle = (String)Globals.db.getData("libE");
                String logo = (String)Globals.db.getData("logoE");

                Globals.hotel.getEquipements().Add(new Equipement(id, libelle, logo));
            }

            Globals.db.disconnect();
        }

        // Charge les chambres depuis la base de données
        public static void loadChambres()
        {
            Globals.hotel.setChambres(new List<Chambre>());

            Globals.db.connect();

            Globals.db.execute("SELECT * FROM chambre " +
                       "WHERE idH = " + Globals.hotel.getId());

            while (Globals.db.read())
            {
                int id = (int)Globals.db.getData("idC");
                Globals.hotel.getChambres().Add(new Chambre(id));
            }

            Globals.db.disconnect();
        }

        // Charge les reservations de la journée depuis la base de données
        public static void loadReservations()
        {
            Globals.hotel.setReservations(new List<Reservation>());

            Globals.db.connect();

            Globals.db.execute("SELECT * FROM reservation WHERE idH = " + Globals.hotel.getId() + " AND " +
                "dateDebut = '" + DateTime.Today.ToString("dd-MM-yyyy") + "'");
            while (Globals.db.read())
            {
                int id = (int)Globals.db.getData("idR");
                String code = (String)Globals.db.getData("codeR");
                String nom = (String)Globals.db.getData("nomR");
                String telephone = (String)Globals.db.getData("telR");
                DateTime dateDebut = (DateTime)Globals.db.getData("dateDebut");
                DateTime dateFin = (DateTime)Globals.db.getData("dateFin");
                int idH = (int)Globals.db.getData("idH");
                Globals.hotel.getReservations().Add(new Reservation(id, code, nom, telephone, dateDebut, dateFin));
            }

            Globals.db.disconnect();

            // Chargement de la liste des chambre de chaque réservations
            loadReservChambres();
        }

        // Chargement de la liste des chambre de chaque réservations
        private static void loadReservChambres()
        {
            // Pour chaque réservation on récupère ses chambres
            foreach (Reservation r in Globals.hotel.getReservations())
            {
                Globals.db.connect();
                Globals.db.execute("SELECT * FROM reserver WHERE idR = " + r.getId());
                while (Globals.db.read())
                {
                    int id = (int)Globals.db.getData("idC");
                    r.getChambres().Add(new Chambre(id));
                }
                Globals.db.disconnect();
            }

        }

        // Met à jour l'hotel dans la base de données
        public static void updateHotel()
        {
            Globals.db.connect();

            Globals.db.executeNonQuery("UPDATE hotel SET " +
                "nomH = '" + Globals.hotel.getNom() + "', " +
                "adr1 = '" + Globals.hotel.getAdresse() + "', " +
                "adr2 = '" + Globals.hotel.getCompAdresse() + "', " +
                "ville = '" + Globals.hotel.getVille() + "', " +
                "cp = '" + Globals.hotel.getCodePostal() + "', " +
                "tel = '" + Globals.hotel.getTelephone() + "', " +
                "descourt = '" + Globals.hotel.getDesCourt() + "', " +
                "deslong = '" + Globals.hotel.getDesLong() + "', " +
                "prix = " + Globals.hotel.getPrix() + ", " +
                "mdp = '" + Globals.hotel.getMotDePasse() + "' " +
                "WHERE idH = " + Globals.hotel.getId());

            // Nécéssite une déconnexion reconnexion entre chaque ExecuteNonQuery pour éviter tout bug
            Globals.db.disconnect();
            Globals.db.connect();

            Globals.db.executeNonQuery("DELETE FROM equiper WHERE idH = " + Globals.hotel.getId());

            Globals.db.disconnect();

            foreach (Equipement e in Globals.hotel.getEquipements())
            {
                Globals.db.connect();
                Globals.db.executeNonQuery("INSERT INTO equiper VALUES (" + Globals.hotel.getId() + ", " + e.getId() + ")");
                Globals.db.disconnect();
            }

            Globals.db.disconnect();

            BalladinsMethods.alert("Modification", "L'hôtel '" + Globals.hotel.getNom() + "' a été modifié.");

            loadHotel(Globals.hotel.getId());
        }

        // Ajout d'une chambre à la base de données
        public static void insertChambre()
        {
            Globals.db.connect();
            // On récupère l'id de la chambre la plus haute et on ajoute 1
            int idC = getLastChambreId() + 1;
            Globals.db.executeNonQuery("INSERT INTO chambre VALUES (" + Globals.hotel.getId() + ", " + idC + ")");
            Globals.db.disconnect();

            BalladinsMethods.alert("La chambre n°" + idC + " a bien été créée.");

            // Mise à jour de la liste de chambres
            BalladinsDbMethods.loadChambres();
        }

        // Ajout de réservation dans la base de données
        public static void insertReservation(string code, string nom, string telephone,
            DateTime dateDebut, DateTime dateFin, List<Chambre> chambres)
        {
            Globals.db.connect();

            // Ajout de la réservation
            Globals.db.executeNonQuery("INSERT INTO reservation (nomR, telR, codeR, datedebut, datefin, idH) VALUES ('" +
                nom + "', '" +
                telephone + "', '" +
                code + "', '" +
                dateDebut.ToString("dd-MM-yyyy") + "', '" +
                dateFin.ToString("dd-MM-yyyy") + "', " +
                Globals.hotel.getId() + ")");

            // Besoin de déconnexion reconnexion pour éviter un bug de connexion
            Globals.db.disconnect();
            Globals.db.connect();

            // Récupération de l'identifiant de la dernière réservation
            int newReservationId = (int)Globals.db.executeScalar("SELECT MAX(idR) FROM reservation WHERE idH = " + Globals.hotel.getId());

            // Ajout de la réservation de chaque chambre dans la table reserver
            foreach (Chambre chambre in chambres)
            {
                Globals.db.executeNonQuery("INSERT INTO reserver VALUES (" +
                    newReservationId + ", " +
                    chambre.getId() + ", " +
                    Globals.hotel.getId() + ")");
            }

            Globals.db.disconnect();

            BalladinsMethods.alert("La réservation au nom de '" + nom + "' a bien été enregistrée.");

            // Mise à jour de la liste de réservation
            BalladinsDbMethods.loadReservations();
        }

        // Suppression d'une chambre dans la base de données et de toute ses réservations associées
        public static void deleteChambre(int id)
        {
            Globals.db.connect();
            Globals.db.executeNonQuery("DELETE FROM reserver WHERE idC = " + id);
            Globals.db.executeNonQuery("DELETE FROM chambre WHERE idH = " + Globals.hotel.getId() + " AND idC = " + id);
            Globals.db.disconnect();

            BalladinsMethods.alert("Suppression", "La chambre n°" + id + " a été supprimée.");

            // Mise à jour de la liste de chambres
            BalladinsDbMethods.loadChambres();
        }

        // Retourne le numéro de la dernière chambre de l'hôtel
        // Ici il n'y a pas de connect ni de disconnect pour éviter un bug d'exécution dans insertChambre()
        public static int getLastChambreId()
        {
            return (int)Globals.db.executeScalar("SELECT MAX(idC) FROM chambre WHERE idH = " + Globals.hotel.getId());
        }

        // Retourne une liste contenant toutes les chambres disponibles
        public static List<Chambre> getChambresDispo(DateTime dateDebut, DateTime dateFin)
        {
            List<Chambre> chambresDispo = new List<Chambre>();

            Globals.db.connect();
            // Requête provenant de la notice SQL Server
            Globals.db.execute("SELECT idC FROM chambre " +
                "WHERE idH =  " + Globals.hotel.getId() + " AND " +
                "idC NOT IN (SELECT idC FROM reservation R INNER JOIN reserver Res " +
                "ON R.idR = Res.idR " +
                "WHERE R.idH = " + Globals.hotel.getId() + " " +
                "AND ('" + dateDebut.ToString("dd-MM-yyyy") + "' >= R.datedebut AND '" +
                           dateFin.ToString("dd-MM-yyyy") + "'< R.datefin) " +
                "OR ('" + dateDebut.ToString("dd-MM-yyyy") + "' >= R.datedebut AND '" +
                          dateDebut.ToString("dd-MM-yyyy") + "' < R.datefin))");
            while (Globals.db.read())
            {
                int id = (int)Globals.db.getData("idC");

                chambresDispo.Add(new Chambre(id));
            }
            Globals.db.disconnect();

            return chambresDispo;
        }

        // Retourne une liste contenant tous les équipements de la base de données
        public static List<Equipement> getAllEquipements()
        {
            List<Equipement> equipements = new List<Equipement>();

            Globals.db.connect();
            Globals.db.execute("SELECT * FROM equipement");
            while (Globals.db.read())
            {
                int id = (int)Globals.db.getData("idE");
                String libelle = (String)Globals.db.getData("libE");
                String logo = (String)Globals.db.getData("logoE");

                equipements.Add(new Equipement(id, libelle, logo));
            }
            Globals.db.disconnect();

            return equipements;
        }
    }
}
