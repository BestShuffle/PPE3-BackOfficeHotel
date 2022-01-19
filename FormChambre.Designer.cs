namespace Balladins
{
    partial class FormChambre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChambre));
            this.grdChambres = new System.Windows.Forms.DataGridView();
            this.btnAjout = new System.Windows.Forms.Button();
            this.btnSupp = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.numChambre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdChambres)).BeginInit();
            this.SuspendLayout();
            // 
            // grdChambres
            // 
            this.grdChambres.AllowUserToAddRows = false;
            this.grdChambres.AllowUserToDeleteRows = false;
            this.grdChambres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdChambres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numChambre});
            this.grdChambres.Location = new System.Drawing.Point(26, 76);
            this.grdChambres.Margin = new System.Windows.Forms.Padding(4);
            this.grdChambres.Name = "grdChambres";
            this.grdChambres.ReadOnly = true;
            this.grdChambres.RowHeadersVisible = false;
            this.grdChambres.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdChambres.RowTemplate.Height = 24;
            this.grdChambres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdChambres.Size = new System.Drawing.Size(362, 301);
            this.grdChambres.TabIndex = 0;
            // 
            // btnAjout
            // 
            this.btnAjout.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjout.Location = new System.Drawing.Point(26, 395);
            this.btnAjout.Margin = new System.Windows.Forms.Padding(4);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(110, 39);
            this.btnAjout.TabIndex = 27;
            this.btnAjout.Text = "Ajouter";
            this.btnAjout.UseVisualStyleBackColor = true;
            this.btnAjout.Click += new System.EventHandler(this.btnAjout_Click);
            // 
            // btnSupp
            // 
            this.btnSupp.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupp.Location = new System.Drawing.Point(256, 395);
            this.btnSupp.Margin = new System.Windows.Forms.Padding(4);
            this.btnSupp.Name = "btnSupp";
            this.btnSupp.Size = new System.Drawing.Size(132, 39);
            this.btnSupp.TabIndex = 28;
            this.btnSupp.Text = "Supprimer";
            this.btnSupp.UseVisualStyleBackColor = true;
            this.btnSupp.Click += new System.EventHandler(this.btnSupp_Click);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(16, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(395, 37);
            this.label11.TabIndex = 30;
            this.label11.Text = "GESTION DES CHAMBRES";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numChambre
            // 
            this.numChambre.HeaderText = "Numéro de chambre";
            this.numChambre.Name = "numChambre";
            this.numChambre.ReadOnly = true;
            this.numChambre.Width = 200;
            // 
            // FormChambre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(430, 448);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnSupp);
            this.Controls.Add(this.btnAjout);
            this.Controls.Add(this.grdChambres);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormChambre";
            this.Text = "Gestion des chambres";
            this.Load += new System.EventHandler(this.FormMesChambres_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdChambres)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdChambres;
        private System.Windows.Forms.Button btnAjout;
        private System.Windows.Forms.Button btnSupp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn numChambre;
    }
}