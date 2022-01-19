using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balladins
{
    // Classe d'objet Photo
    class Photo
    {
        private int id;
        private String nom;
        private Hotel hotel;

        // Construit un objet Photo
        public Photo(int id, String nom, Hotel hotel)
        {
            this.id = id;
            this.nom = nom;
            this.hotel = hotel;
        }

        // Fonction de récupération de l'identifiant de la photo
        public int getId()
        {
            return id;
        }

        // Fonction de définition de l'identifiant de la photo
        public void setId(int id)
        {
            this.id = id;
        }

        // Fonction de récupération du nom de la photo
        public String getNom()
        {
            return nom;
        }

        // Fonction de définition du nom de la photo
        public void setNom(String nom)
        {
            this.nom = nom;
        }

        // Fonction de récupération de l'hôtel associé à la photo
        public Hotel getHotel()
        {
            return hotel;
        }

        // Fonction de définition de l'hôtel associé à la photo
        public void setHotel(Hotel hotel)
        {
            this.hotel = hotel;
        }
    }
}
