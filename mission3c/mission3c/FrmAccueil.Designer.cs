namespace mission3c
{
    partial class FrmAccueil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitre = new System.Windows.Forms.Label();
            this.btnGererVisiteurs = new System.Windows.Forms.Button();
            this.btnAjouterVisiteur = new System.Windows.Forms.Button();
            this.btnVoirRapports = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.Location = new System.Drawing.Point(218, 71);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(374, 51);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "GSB - Mission 3 C";
            // 
            // btnGererVisiteurs
            // 
            this.btnGererVisiteurs.Location = new System.Drawing.Point(227, 135);
            this.btnGererVisiteurs.Name = "btnGererVisiteurs";
            this.btnGererVisiteurs.Size = new System.Drawing.Size(298, 64);
            this.btnGererVisiteurs.TabIndex = 1;
            this.btnGererVisiteurs.Text = "Supprimer les visiteurs";
            this.btnGererVisiteurs.UseVisualStyleBackColor = true;
            // 
            // btnAjouterVisiteur
            // 
            this.btnAjouterVisiteur.Location = new System.Drawing.Point(227, 205);
            this.btnAjouterVisiteur.Name = "btnAjouterVisiteur";
            this.btnAjouterVisiteur.Size = new System.Drawing.Size(298, 64);
            this.btnAjouterVisiteur.TabIndex = 2;
            this.btnAjouterVisiteur.Text = "Ajouter un visiteur";
            this.btnAjouterVisiteur.UseVisualStyleBackColor = true;
            // 
            // btnVoirRapports
            // 
            this.btnVoirRapports.Location = new System.Drawing.Point(227, 275);
            this.btnVoirRapports.Name = "btnVoirRapports";
            this.btnVoirRapports.Size = new System.Drawing.Size(298, 64);
            this.btnVoirRapports.TabIndex = 3;
            this.btnVoirRapports.Text = "Voir les rapports";
            this.btnVoirRapports.UseVisualStyleBackColor = true;
            // 
            // FrmAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVoirRapports);
            this.Controls.Add(this.btnAjouterVisiteur);
            this.Controls.Add(this.btnGererVisiteurs);
            this.Controls.Add(this.lblTitre);
            this.Name = "FrmAccueil";
            this.Text = "Accueil - GSB Mission 3 C";
            this.Load += new System.EventHandler(this.FrmAccueil_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Button btnGererVisiteurs;
        private System.Windows.Forms.Button btnAjouterVisiteur;
        private System.Windows.Forms.Button btnVoirRapports;
    }
}

