using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balladins
{
    // Classe d'objet Equipement
    class Equipement
    {
        private int id;
        private String libelle;
        private String logo;

        // Construit un objet équipement
        public Equipement(int id, String libelle, String logo)
        {
            this.id = id;
            this.libelle = libelle;
            this.logo = logo;
        }

        // Fonction de récupération de l'identifiant de l'équipement
        public int getId()
        {
            return id;
        }

        // Fonction de définition de l'identifiant de l'équipement
        public void setId(int id)
        {
            this.id = id;
        }
        
        // Fonction de récupération du libellé de l'équipement
        public String getLibelle()
        {
            return libelle;
        }
        
        // Fonction de définition du libellé de l'équipement
        public void setLibelle(String libelle)
        {
            this.libelle = libelle;
        }

        // Fonction de récupération du logo de l'équipement
        public String getLogo()
        {
            return logo;
        }

        // Fonction de définition du logo de l'équipement
        public void setLogo(String logo)
        {
            this.logo = logo;
        }
    }
}
