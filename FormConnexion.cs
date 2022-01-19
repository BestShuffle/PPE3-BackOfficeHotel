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
    public partial class FormConnexion : Form
    {
        // Construit le form
        public FormConnexion()
        {
            InitializeComponent();
        }

        // Connexion de l'hôtel
        private void btnConnect_Click(object sender, EventArgs e)
        {
            // Vérification que le champ d'identifiant ne contient que des nombres entiers
            if (BalladinsMethods.verifIntField(txtId.Text))
            {
                // Vérification que les données entrées sont correctes
                if (BalladinsMethods.validConnexion(Convert.ToInt32(txtId.Text), txtMdp.Text))
                {
                    // Chargement des données et ouverture du Form principal
                    BalladinsDbMethods.loadAll(Convert.ToInt32(txtId.Text));
                    this.Hide();
                    FormAccueil formAccueil = new FormAccueil();
                    formAccueil.Closed += (s, args) => this.Close();
                    formAccueil.Show();
                }
                else
                {
                    BalladinsMethods.alert("Identifiant ou mot de passe incorrect");
                }
            }
            else
            {
                BalladinsMethods.alert("L'identifiant ne doit contenir que des chiffres");
            }
        }
    }
}
