using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Balladins
{
    public partial class FormHotel : Form
    {
        // Construit le Form
        public FormHotel()
        {
            InitializeComponent();
        }

        // Chargement des informations de l'hotel dans les TextBox
        private void refreshInfos()
        {
            // Affichage des informations de l'hôtel
            txtNom.Text = Globals.hotel.getNom();
            txtAdr.Text = Globals.hotel.getAdresse();
            txtCompAdr.Text = Globals.hotel.getCompAdresse();
            txtVille.Text = Globals.hotel.getVille();
            txtCp.Text = Globals.hotel.getCodePostal();
            txtTel.Text = Globals.hotel.getTelephone();
            txtDescCourte.Text = Globals.hotel.getDesCourt();
            txtDesc.Text = Globals.hotel.getDesLong();
            txtPrix.Text = Globals.hotel.getPrix().ToString();
            txtMdp.Text = Globals.hotel.getMotDePasse();

            // Vide les listes
            lstAllEquip.Items.Clear();
            lstEquip.Items.Clear();

            // Remplissage des listes
            foreach (Equipement e in BalladinsDbMethods.getAllEquipements())
            {
                lstAllEquip.Items.Add(e.getLibelle());
            }
            foreach (Equipement e in Globals.hotel.getEquipements())
            {
                lstEquip.Items.Add(e.getLibelle());
            }
        }

        // Chargement des informations de l'hôtel dans les TextBox et le DataGridView
        private void FormMonHotel_Load(object sender, EventArgs e)
        {
            refreshInfos();
        }

        // Modification des informations de l'hôtel
        private void btnModif_Click(object sender, EventArgs e)
        {
            // Mise à jour des données de l'hôtel
            // Si un champ contient une apostrophe elle est doublée pour éviter tout bug de SQL
            Globals.hotel.setNom(txtNom.Text.Replace("'", "''"));
            Globals.hotel.setAdresse(txtAdr.Text.Replace("'", "''"));
            Globals.hotel.setCompAdresse(txtCompAdr.Text.Replace("'", "''"));
            Globals.hotel.setVille(txtVille.Text.Replace("'", "''"));
            Globals.hotel.setCodePostal(txtCp.Text.Replace("'", "''"));
            Globals.hotel.setTelephone(txtTel.Text.Replace("'", "''"));
            Globals.hotel.setDesCourt(txtDescCourte.Text.Replace("'", "''"));
            Globals.hotel.setDesLong(txtDesc.Text.Replace("'", "''"));
            Globals.hotel.setPrix(Convert.ToInt32(txtPrix.Text.Replace("'", "''")));
            Globals.hotel.setMotDePasse(txtMdp.Text.Replace("'", "''"));
            BalladinsDbMethods.updateHotel();
            refreshInfos();
        }

        private void btnEquipPlus_Click(object sender, EventArgs e)
        {
            // Vérification qu'un équipement est bien sélectionné
            if (lstAllEquip.SelectedIndex != -1)
            {
                Equipement equipement = BalladinsDbMethods.getAllEquipements()[lstAllEquip.SelectedIndex];
                String selectedItem = lstAllEquip.SelectedItem.ToString();
                bool present = false;
                // 
                foreach (var item in lstEquip.Items)
                {
                    if (selectedItem == item.ToString())
                    {
                        present = true;
                    }
                }
                // Vérification que l'équipement n'est pas déjà présent
                if (!present)
                {
                    // Ajout de l'équipement à l'hôtel
                    Globals.hotel.getEquipements().Add(equipement);
                    refreshInfos();
                }
                else
                {
                    BalladinsMethods.alert("Erreur", "L'équipement '" +
                        equipement.getLibelle() + "' est déjà présent dans l'hôtel");
                }
            }
        }

        private void btnEquipMoins_Click(object sender, EventArgs e)
        {
            // Vérification qu'un équipement est bien sélectionné
            if (lstEquip.SelectedIndex != -1)
            {
                // Suppression de l'équipement de l'hôtel
                Globals.hotel.getEquipements().Remove(Globals.hotel.getEquipements()[lstEquip.SelectedIndex]);
                refreshInfos();
            }
        }
    }
}
