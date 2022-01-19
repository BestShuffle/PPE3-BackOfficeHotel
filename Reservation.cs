using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balladins
{
    // Classe d'objet Reservation
    class Reservation
    {
        private int id;
        private String code;
        private String nom;
        private String telephone;
        private DateTime dateDebut;
        private DateTime dateFin;
        private List<Chambre> chambres;

        // Construit un objet Reservation
        public Reservation(int id, String code, String nom, String telephone, DateTime dateDebut, DateTime dateFin)
        {
            this.id = id;
            this.code = code;
            this.nom = nom;
            this.telephone = telephone;
            this.dateDebut = dateDebut;
            this.dateFin = dateFin;
            this.chambres = new List<Chambre>();
        }

        // Fonction de récupération de l'identifiant de réservation
        public int getId()
        {
            return id;
        }

        // Fonction de définition de l'identifiant de réservation
        public void setId(int id)
        {
            this.id = id;
        }

        // Fonction de définition du code de réservation
        public void setCode(String code)
        {
            this.code = code;
        }

        // Fonction de récupération du code de réservation
        public String getCode()
        {
            return code;
        }

        // Fonction de récupération du nom de réservation
        public String getNom()
        {
            return nom;
        }

        // Fonction de définition du nom de réservation
        public void setNom(String nom)
        {
            this.nom = nom;
        }

        // Fonction de récupération du téléphone de réservation
        public String getTelephone()
        {
            return telephone;
        }

        // Fonction de définition du téléphone de réservation
        public void setTelephone(String telephone)
        {
            this.telephone = telephone;
        }

        // Fonction de récupération de la date de début de réservation
        public DateTime getDateDebut()
        {
            return dateDebut;
        }

        // Fonction de définition de la date de début de réservation
        public void setDateDebut(DateTime dateDebut)
        {
            this.dateDebut = dateDebut;
        }

        // Fonction de récupération de la date de fin de réservation
        public DateTime getDateFin()
        {
            return dateFin;
        }

        // Fonction de définition de la date de fin de réservation
        public void setDateFin(DateTime dateFin)
        {
            this.dateFin = dateFin;
        }

        // Fonction de récupération de la liste des chambres réservées
        public List<Chambre> getChambres()
        {
            return chambres;
        }

        // Fonction de définition de la liste des chambres réservées
        public void setChambres(List<Chambre> chambres)
        {
            this.chambres = chambres;
        }
    }
}
