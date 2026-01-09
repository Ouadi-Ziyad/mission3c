namespace mission3c
{
    partial class FrmRapports
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
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblVisiteur = new System.Windows.Forms.Label();
            this.cboVisiteurs = new System.Windows.Forms.ComboBox();
            this.dgvRapports = new System.Windows.Forms.DataGridView();
            this.btnFermer = new System.Windows.Forms.Button();
            this.btnExporterXML = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRapports)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.8F);
            this.lblTitre.Location = new System.Drawing.Point(227, 9);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(326, 39);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Rapports du visiteur";
            // 
            // lblVisiteur
            // 
            this.lblVisiteur.AutoSize = true;
            this.lblVisiteur.Location = new System.Drawing.Point(12, 60);
            this.lblVisiteur.Name = "lblVisiteur";
            this.lblVisiteur.Size = new System.Drawing.Size(116, 16);
            this.lblVisiteur.TabIndex = 1;
            this.lblVisiteur.Text = "Choisir un visiteur :";
            // 
            // cboVisiteurs
            // 
            this.cboVisiteurs.FormattingEnabled = true;
            this.cboVisiteurs.Location = new System.Drawing.Point(15, 88);
            this.cboVisiteurs.Name = "cboVisiteurs";
            this.cboVisiteurs.Size = new System.Drawing.Size(121, 24);
            this.cboVisiteurs.TabIndex = 2;
            // 
            // dgvRapports
            // 
            this.dgvRapports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRapports.Location = new System.Drawing.Point(15, 127);
            this.dgvRapports.Name = "dgvRapports";
            this.dgvRapports.RowHeadersWidth = 51;
            this.dgvRapports.RowTemplate.Height = 24;
            this.dgvRapports.Size = new System.Drawing.Size(773, 150);
            this.dgvRapports.TabIndex = 3;
            // 
            // btnFermer
            // 
            this.btnFermer.Location = new System.Drawing.Point(713, 296);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(75, 23);
            this.btnFermer.TabIndex = 4;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            // 
            // btnExporterXML
            // 
            this.btnExporterXML.Location = new System.Drawing.Point(15, 296);
            this.btnExporterXML.Name = "btnExporterXML";
            this.btnExporterXML.Size = new System.Drawing.Size(113, 23);
            this.btnExporterXML.TabIndex = 5;
            this.btnExporterXML.Text = "Exporter en XML";
            this.btnExporterXML.UseVisualStyleBackColor = true;
            // 
            // FrmRapports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExporterXML);
            this.Controls.Add(this.btnFermer);
            this.Controls.Add(this.dgvRapports);
            this.Controls.Add(this.cboVisiteurs);
            this.Controls.Add(this.lblVisiteur);
            this.Controls.Add(this.lblTitre);
            this.Name = "FrmRapports";
            this.Text = "FrmRapports";
            this.Load += new System.EventHandler(this.FrmRapports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRapports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblVisiteur;
        private System.Windows.Forms.ComboBox cboVisiteurs;
        private System.Windows.Forms.DataGridView dgvRapports;
        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.Button btnExporterXML;
    }
}