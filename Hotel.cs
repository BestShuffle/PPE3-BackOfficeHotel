using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balladins
{
    // Classe d'objet Hotel
    class Hotel
    {
        private int id;
        private String nom;
        private String adresse;
        private String compAdresse;
        private String ville;
        private String codePostal;
        private String telephone;
        private String desCourt;
        private String desLong;
        private double prix;
        private String motDePasse;
        private List<Reservation> reservations;
        private List<Equipement> equipements;
        private List<Chambre> chambres;

        // Construit un objet Hotel
        public Hotel(int id, String nom, String adresse, String compAdresse, String ville,
            String codePostal, String telephone, String desCourt, String desLong, double prix, String motDePasse)
        {
            this.id = id;
            this.nom = nom;
            this.adresse = adresse;
            this.compAdresse = compAdresse;
            this.ville = ville;
            this.codePostal = codePostal;
            this.telephone = telephone;
            this.desCourt = desCourt;
            this.desLong = desLong;
            this.prix = prix;
            this.motDePasse = motDePasse;
            this.reservations = new List<Reservation>();
            this.equipements = new List<Equipement>();
            this.chambres = new List<Chambre>();
        }

        // Fonction de récupération de réservation par id
        public Reservation getReservById(int id)
        {
            Reservation reserv = reservations[0];
            bool found = false;
            int i = 0;
            while (!found && i < reservations.Count)
            {
                if (reservations[i].getId() == id)
                {
                    reserv = reservations[i];
                    found = true;
                }
                i++;
            }
            return reserv;
        }

        // Fonction de récupération de l'identifiant
        public int getId()
        {
            return id;
        }
        
        // Fonction de définition de l'identifiant
        public void setId(int id)
        {
            this.id = id;
        }

        // Fonction de récupération du nom
        public String getNom()
        {
            return nom;
        }
        
        // Fonction de définition du nom
        public void setNom(String nom)
        {
            this.nom = nom;
        }

        // Fonction de récupération de l'adresse
        public String getAdresse()
        {
            return adresse;
        }
        
        // Fonction de définition de l'adresse
        public void setAdresse(String adresse)
        {
            this.adresse = adresse;
        }

        // Fonction de récupération du complément d'adresse
        public String getCompAdresse()
        {
            return compAdresse;
        }
        
        // Fonction de définition du complément d'adresse
        public void setCompAdresse(String compAdresse)
        {
            this.compAdresse = compAdresse;
        }

        // Fonction de récupération de la ville
        public String getVille()
        {
            return ville;
        }
        
        // Fonction de définition de la ville
        public void setVille(String ville)
        {
            this.ville = ville;
        }

        // Fonction de récupération du code postal
        public String getCodePostal()
        {
            return codePostal;
        }
        
        // Fonction de définition du code postal
        public void setCodePostal(String codePostal)
        {
            this.codePostal = codePostal;
        }

        // Fonction de récupération du telephone
        public String getTelephone()
        {
            return telephone;
        }
        
        // Fonction de définition du telephone
        public void setTelephone(String telephone)
        {
            this.telephone = telephone;
        }

        // Fonction de récupération de la description courte
        public String getDesCourt()
        {
            return desCourt;
        }
        
        // Fonction de définition de la description courte
        public void setDesCourt(String desCourt)
        {
            this.desCourt = desCourt;
        }

        // Fonction de récupération de la description longue
        public String getDesLong()
        {
            return desLong;
        }
        
        // Fonction de définition de la description longue
        public void setDesLong(String desLong)
        {
            this.desLong = desLong;
        }

        // Fonction de récupération du prix
        public double getPrix()
        {
            return prix;
        }

        // Fonction de définition du prix
        public void setPrix(int prix)
        {
            this.prix = prix;
        }

        // Fonction de récupération du mot de passe
        public String getMotDePasse()
        {
            return motDePasse;
        }

        // Fonction de définition du mot de passe
        public void setMotDePasse(String motDePasse)
        {
            this.motDePasse = motDePasse;
        }

        // Fonction de récupération des réservations
        public List<Reservation> getReservations()
        {
            return reservations;
        }

        // Fonction de définition des réservations
        public void setReservations(List<Reservation> reservations)
        {
            this.reservations = reservations;
        }

        // Fonction de récupération des equipements
        public List<Equipement> getEquipements()
        {
            return equipements;
        }

        // Fonction de définition des equipements
        public void setEquipements(List<Equipement> equipements)
        {
            this.equipements = equipements;
        }

        // Fonction de récupération des chambres
        public List<Chambre> getChambres()
        {
            return chambres;
        }

        // Fonction de définition des chambres
        public void setChambres(List<Chambre> chambres)
        {
            this.chambres = chambres;
        }
    }
}
