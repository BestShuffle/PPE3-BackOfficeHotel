using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balladins
{
    // Classe de l'objet Chambre
    class Chambre
    {
        private int id;

        // Constructeur d'un objet Chambre
        public Chambre(int id)
        {
            this.id = id;
        }

        // Fonction de récupération de l'identifiant de la chambre
        public int getId()
        {
            return id;
        }

        // Fonction de définition de l'identifiant de la chambre
        public void setId(int id)
        {
            this.id = id;
        }
    }
}
