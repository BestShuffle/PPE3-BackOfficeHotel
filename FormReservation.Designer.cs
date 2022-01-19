namespace Balladins
{
    partial class FormReservation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReservation));
            this.grdReservation = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateDebut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAjoutReservation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdReservation)).BeginInit();
            this.SuspendLayout();
            // 
            // grdReservation
            // 
            this.grdReservation.AllowUserToAddRows = false;
            this.grdReservation.AllowUserToDeleteRows = false;
            this.grdReservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdReservation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Column1,
            this.DateDebut,
            this.DateFin});
            this.grdReservation.Location = new System.Drawing.Point(23, 68);
            this.grdReservation.Name = "grdReservation";
            this.grdReservation.ReadOnly = true;
            this.grdReservation.RowHeadersVisible = false;
            this.grdReservation.RowTemplate.Height = 24;
            this.grdReservation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdReservation.Size = new System.Drawing.Size(415, 300);
            this.grdReservation.TabIndex = 33;
            this.grdReservation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdReservation_CellClick);
            // 
            // id
            // 
            this.id.HeaderText = "N°";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nom";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // DateDebut
            // 
            this.DateDebut.HeaderText = "Du";
            this.DateDebut.Name = "DateDebut";
            this.DateDebut.ReadOnly = true;
            // 
            // DateFin
            // 
            this.DateFin.HeaderText = "Au";
            this.DateFin.Name = "DateFin";
            this.DateFin.ReadOnly = true;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(14, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(436, 37);
            this.label11.TabIndex = 35;
            this.label11.Text = "GESTION DES RESERVATIONS";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAjoutReservation
            // 
            this.btnAjoutReservation.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjoutReservation.Location = new System.Drawing.Point(108, 382);
            this.btnAjoutReservation.Name = "btnAjoutReservation";
            this.btnAjoutReservation.Size = new System.Drawing.Size(249, 43);
            this.btnAjoutReservation.TabIndex = 36;
            this.btnAjoutReservation.Text = "Ajouter une réservation ";
            this.btnAjoutReservation.UseVisualStyleBackColor = true;
            this.btnAjoutReservation.Click += new System.EventHandler(this.btnAjoutReservation_Click);
            // 
            // FormReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(465, 442);
            this.Controls.Add(this.btnAjoutReservation);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.grdReservation);
            this.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReservation";
            this.Text = "Gestion des réservations";
            this.Load += new System.EventHandler(this.FormReservation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdReservation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdReservation;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateDebut;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateFin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAjoutReservation;

    }
}