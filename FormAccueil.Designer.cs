namespace Balladins
{
    partial class FormAccueil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAccueil));
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnHotel = new System.Windows.Forms.ToolStripButton();
            this.btnChambre = new System.Windows.Forms.ToolStripButton();
            this.btnReservation = new System.Windows.Forms.ToolStripButton();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Maroon;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHotel,
            this.btnChambre,
            this.btnReservation});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1597, 31);
            this.menu.TabIndex = 0;
            // 
            // btnHotel
            // 
            this.btnHotel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnHotel.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHotel.ForeColor = System.Drawing.Color.White;
            this.btnHotel.Image = ((System.Drawing.Image)(resources.GetObject("btnHotel.Image")));
            this.btnHotel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHotel.Name = "btnHotel";
            this.btnHotel.Size = new System.Drawing.Size(169, 28);
            this.btnHotel.Text = "Gestion de l\'hôtel";
            this.btnHotel.Click += new System.EventHandler(this.btnHotel_Click);
            // 
            // btnChambre
            // 
            this.btnChambre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnChambre.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChambre.ForeColor = System.Drawing.Color.White;
            this.btnChambre.Image = ((System.Drawing.Image)(resources.GetObject("btnChambre.Image")));
            this.btnChambre.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChambre.Name = "btnChambre";
            this.btnChambre.Size = new System.Drawing.Size(206, 28);
            this.btnChambre.Text = "Gestion des chambres";
            this.btnChambre.Click += new System.EventHandler(this.btnChambre_Click);
            // 
            // btnReservation
            // 
            this.btnReservation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReservation.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservation.ForeColor = System.Drawing.Color.White;
            this.btnReservation.Image = ((System.Drawing.Image)(resources.GetObject("btnReservation.Image")));
            this.btnReservation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReservation.Name = "btnReservation";
            this.btnReservation.Size = new System.Drawing.Size(229, 28);
            this.btnReservation.Text = "Gestion des réservations";
            this.btnReservation.Click += new System.EventHandler(this.btnReservation_Click);
            // 
            // FormAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1597, 791);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormAccueil";
            this.Text = "Accueil";
            this.Load += new System.EventHandler(this.FormAccueil_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnHotel;
        private System.Windows.Forms.ToolStripButton btnChambre;
        private System.Windows.Forms.ToolStripButton btnReservation;
    }
}