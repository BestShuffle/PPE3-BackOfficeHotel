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
    public partial class FormReservation : Form
    {
        // Construit le form
        public FormReservation()
        {
            InitializeComponent();
        }

        // Chargement du form
        private void FormReservation_Load(object sender, EventArgs e)
        {
            refreshGrdReservations();
        }

        // Rafraichissement du DataGridView
        private void refreshGrdReservations()
        {
            grdReservation.Rows.Clear();
            foreach (Reservation r in Globals.hotel.getReservations())
            {
                grdReservation.Rows.Add(r.getId(), r.getNom(), r.getDateDebut().ToString("dd/MM/yyyy"), r.getDateFin().ToString("dd/MM/yyyy"));
            }
        }

        // Ouverture de la page d'ajout de réservation
        private void btnAjoutReservation_Click(object sender, EventArgs e)
        {
            FormAjoutReservation formAjoutReservation = new FormAjoutReservation();
            formAjoutReservation.Closing += (s, args) => refreshGrdReservations();
            formAjoutReservation.Show();
        }

        // Ouverture de la page de détail d'une réservation lors d'un clic sur une réservation dans le DataGridView
        private void grdReservation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            new FormShowReservation(Globals.hotel.getReservations()[grdReservation.CurrentCell.RowIndex].getId()).Show();
        }
    }
}
