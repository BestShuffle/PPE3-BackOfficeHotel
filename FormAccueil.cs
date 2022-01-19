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
    public partial class FormAccueil : Form
    {
        // Forms
        FormHotel formHotel;
        FormChambre formChambre;
        FormReservation formReservation;

        // Construit le Form
        public FormAccueil()
        {
            InitializeComponent();
        }

        // Chargement du Form
        private void FormAccueil_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }

        private void btnHotel_Click(object sender, EventArgs e)
        {
            // Vérification que le form n'est pas déjà ouvert
            if (formHotel == null || formHotel.IsDisposed)
            {
                formHotel = new FormHotel();
                // Ouverture du Form à l'intérieur du FormAccueil (this)
                formHotel.MdiParent = this;
                formHotel.Show();
            }
        }

        private void btnChambre_Click(object sender, EventArgs e)
        {
            // Vérification que le form n'est pas déjà ouvert
            if (formChambre == null || formChambre.IsDisposed)
            {
                formChambre = new FormChambre();
                // Ouverture du Form à l'intérieur du FormAccueil (this)
                formChambre.MdiParent = this;
                formChambre.Show();
            }
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            // Vérification que le form n'est pas déjà ouvert
            if (formReservation == null || formReservation.IsDisposed)
            {
                formReservation = new FormReservation();
                // Ouverture du Form à l'intérieur du FormAccueil (this)
                formReservation.MdiParent = this;
                formReservation.Show();
            }
        }
    }
}
