using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Balladins
{
    public partial class FormShowReservation : Form
    {
        private Reservation reservation;

        // Construction du form
        public FormShowReservation(int idR)
        {
            this.reservation = Globals.hotel.getReservById(idR);
            InitializeComponent();
        }

        // Chargement du Form
        private void FormUneReservation_Load(object sender, EventArgs e)
        {
            // Calcul du montant
            double montant = reservation.getChambres().Count() * Globals.hotel.getPrix();
            // Affichage de toutes les données de la réservation
            lblNumRes.Text += reservation.getId();
            lblNom.Text = reservation.getNom();
            lblTelephone.Text = reservation.getTelephone();
            lblDateDebut.Text = reservation.getDateDebut().ToString("dd/MM/yyyy");
            lblDateFin.Text = reservation.getDateFin().ToString("dd/MM/yyyy");

            lblMontant.Text = montant + " €";

            // Affichage de la liste des chambres
            foreach (Chambre chambre in reservation.getChambres())
            {
                lstChambres.Items.Add("N°" + chambre.getId());
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            // Définition du chemin d'accès
            String path = System.IO.Path.GetDirectoryName( 
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            // Création du stream d'accès au fichier
            System.IO.FileStream fs = new FileStream(path + "\\Reservation n°" + reservation.getId() + ".pdf", FileMode.Create);
            // Création de l'instance du document
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            // Création du writer
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            // Ouverture du document
            document.Open();

            // Ecriture des informations
            document.AddTitle("HOTELS BALLADINS");
            document.Add(new Paragraph("HOTELS BALLADINS"));
            document.Add(new Paragraph(" "));

            // Paragraphe de présentation de l'hôtel
            Paragraph paragraphHotel = new Paragraph();
            paragraphHotel.Alignment = Element.ALIGN_LEFT;
            paragraphHotel.Add(new Paragraph(Globals.hotel.getNom()));
            paragraphHotel.Add(new Paragraph(Globals.hotel.getAdresse()));
            if (Globals.hotel.getCompAdresse() != null) {
                if (Globals.hotel.getCompAdresse() != "")
                {
                    paragraphHotel.Add(new Paragraph(Globals.hotel.getCompAdresse()));
                }
            }
            paragraphHotel.Add(new Paragraph(Globals.hotel.getCodePostal() + " " + Globals.hotel.getVille()));
            paragraphHotel.Add(new Paragraph(Globals.hotel.getTelephone()));

            // Création d'un tableau affichant les détails de la réservation
            PdfPTable tableReserv = new PdfPTable(4);
            tableReserv.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            // 1ère ligne
            tableReserv.AddCell(new PdfPCell(new Phrase("Réservation n° : ")));
            tableReserv.AddCell(new PdfPCell(new Phrase(reservation.getId().ToString())));
            tableReserv.AddCell(new PdfPCell(new Phrase("Nom : ")));
            tableReserv.AddCell(new PdfPCell(new Phrase(reservation.getNom())));
            // 2ème ligne
            tableReserv.AddCell(new PdfPCell(new Phrase("Séjour du : ")));
            tableReserv.AddCell(new PdfPCell(new Phrase(reservation.getDateDebut().ToString("dd/MM/yyyy"))));
            tableReserv.AddCell(new PdfPCell(new Phrase(" ")));
            tableReserv.AddCell(new PdfPCell(new Phrase(" ")));
            // 3ème ligne
            tableReserv.AddCell(new PdfPCell(new Phrase("au : ")));
            tableReserv.AddCell(new PdfPCell(new Phrase(reservation.getDateFin().ToString("dd/MM/yyyy"))));
            tableReserv.AddCell(new PdfPCell(new Phrase(" ")));
            tableReserv.AddCell(new PdfPCell(new Phrase(" ")));
            // 4ème ligne
            tableReserv.AddCell(new PdfPCell(new Phrase("Code d'accès chambres : ")));
            tableReserv.AddCell(new PdfPCell(new Phrase(reservation.getCode().ToString())));
            tableReserv.AddCell(new PdfPCell(new Phrase(" ")));
            tableReserv.AddCell(new PdfPCell(new Phrase(" ")));

            // Création d'un tableau affichant la liste des chambres réservées avec leur prix
            PdfPTable tableChambres = new PdfPTable(4);
            tableChambres.AddCell(new PdfPCell(new Phrase("Chambre")));
            tableChambres.AddCell(new PdfPCell(new Phrase("Prix")));
            tableChambres.AddCell(new PdfPCell(new Phrase("Nuitée")));
            tableChambres.AddCell(new PdfPCell(new Phrase("Total")));
            // Calcul de la durée
            double duree = (reservation.getDateFin() - reservation.getDateDebut()).TotalDays;
            double total = 0;
            foreach (Chambre chambre in reservation.getChambres())
            {
                double totalChambre = Globals.hotel.getPrix()*duree;
                tableChambres.AddCell(new PdfPCell(new Phrase("N°" + chambre.getId().ToString())));
                tableChambres.AddCell(new PdfPCell(new Phrase(Globals.hotel.getPrix() + " €")));
                tableChambres.AddCell(new PdfPCell(new Phrase(duree.ToString())));
                tableChambres.AddCell(new PdfPCell(new Phrase(totalChambre + " €")));
                total += totalChambre;
            }
                        
            tableChambres.AddCell(new Phrase(" "));
            tableChambres.AddCell(new Phrase(" "));
            tableChambres.AddCell(new Phrase("Total TTC"));
            tableChambres.AddCell(new Phrase(total + " €"));

            document.Add(paragraphHotel);
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));
            document.Add(tableReserv);
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));
            document.Add(tableChambres);

            // Fermeture du document
            document.Close();
            // Fermeture du writer
            writer.Close();
            // Fermeture du stream
            fs.Close();
        }
    }
}
