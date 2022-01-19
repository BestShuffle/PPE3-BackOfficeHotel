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
    public partial class FormChambre : Form
    {
        // Construit le Form
        public FormChambre()
        {
            InitializeComponent();
        }

        // Chargement des chambres de l'hôtel dans le dataGridView
        private void refreshGrdChambres()
        {
            grdChambres.Rows.Clear();
            foreach (Chambre uneC in Globals.hotel.getChambres())
            {
                grdChambres.Rows.Add(uneC.getId().ToString());
            }
        }

        // Initialisation du Form
        private void FormMesChambres_Load(object sender, EventArgs e)
        {
            refreshGrdChambres();
        }

        // Ajout d'une chambre à l'hôtel
        private void btnAjout_Click(object sender, EventArgs e)
        {
            BalladinsDbMethods.insertChambre();
            refreshGrdChambres();
        }

        // Suppression d'une chambre de l'hôtel
        private void btnSupp_Click(object sender, EventArgs e)
        {
            int id = Globals.hotel.getChambres()[grdChambres.CurrentCell.RowIndex].getId();
            // Demande à l'utilisateur s'il souhaite bien supprimer la chambre
            if (BalladinsMethods.confirm("Souhaitez vous supprimer la chambre n°" + id + " ?"))
            {
                BalladinsDbMethods.deleteChambre(id);
                refreshGrdChambres();
            }
        }
    }
}
