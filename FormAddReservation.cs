using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Balladins
{
    public partial class FormAjoutReservation : Form
    {
        // Construction du Form
        public FormAjoutReservation()
        {
            InitializeComponent();
        }

        private void btnAjoutReserv_Click(object sender, EventArgs e)
        {
            // Vérification du champ de nombre de chambres voulues, si ce n'est pas valide un message d'erreur est affiché
            if (BalladinsMethods.verifIntField(txtNb.Text))
            {
                DateTime dateDebut = datePickDebut.Value;
                DateTime dateFin = datePickFin.Value;
                List<Chambre> chambresDispo = BalladinsDbMethods.getChambresDispo(dateDebut, dateFin);
                int nbChambres = Convert.ToInt32(txtNb.Text);
                if (nbChambres <= chambresDispo.Count)
                {
                    // Récupération des entrées
                    String code = BalladinsMethods.generateCode();
                    // Si le nom contient une apostrophe on la double pour éviter tout bug
                    String nom = txtNom.Text.Replace("'", "''");

                    String telephone = txtTel.Text;
                    List<Chambre> chambres = new List<Chambre>();

                    // Ajoute autant de chambre disponible que le souhaite le client
                    for (int i = 0; i < nbChambres; i++)
                    {
                        chambres.Add(chambresDispo[i]);
                    }

                    // Ajout dans la base de données
                    BalladinsDbMethods.insertReservation(code, nom, telephone, dateDebut, dateFin, chambres);

                    // Vide des champs
                    txtNom.Text = "";
                    txtTel.Text = "";
                    txtNb.Text = "";
                }
                else
                {
                    BalladinsMethods.alert("Erreur", "Il n'y a pas assez de chambre disponible dans l'hôtel.");
                }
            }
            else
            {
                BalladinsMethods.alert("Erreur", "Le nombre de chambre souhaité ne doit contenir que des nombres entiers.");
            }
        }
    }
}
