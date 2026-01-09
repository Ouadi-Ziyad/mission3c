using System;
using System.Linq;
using System.Windows.Forms;

namespace mission3c
{
    public partial class FrmSupprimerVisiteur : Form
    {
        private gsbrapports2016Entities dbContext;

        public FrmSupprimerVisiteur()
        {
            InitializeComponent();
            try
            {
                dbContext = new gsbrapports2016Entities();
            }
            catch { }

            // --- LIAISON DES ÉVÉNEMENTS ---
            this.btnSupprimer.Click += new EventHandler(this.btnSupprimer_Click);
            this.btnAnnuler.Click += new EventHandler(this.btnAnnuler_Click);
        }

        private void FrmSupprimerVisiteur_Load(object sender, EventArgs e)
        {
            ConfiguresColonnes();
            ChargerVisiteurs();
        }

        // Cette étape lie tes colonnes du Designer aux données de la requête LINQ
        private void ConfiguresColonnes()
        {
            dgvVisiteurs.AutoGenerateColumns = false; // Important !

            // On lie la colonne nommée "Nom" (du Designer) à la propriété "Nom" (du code)
            dgvVisiteurs.Columns["Nom"].DataPropertyName = "Nom";

            // On lie la colonne nommée "Prénom" (du Designer) à la propriété "Prenom" (du code)
            dgvVisiteurs.Columns["Prénom"].DataPropertyName = "Prenom";

            // On lie la colonne nommée "ID" (du Designer) à la propriété "ID" (du code)
            dgvVisiteurs.Columns["ID"].DataPropertyName = "ID";
        }

        private void ChargerVisiteurs()
        {
            // Requête LINQ
            var liste = dbContext.visiteurs
                .Select(v => new
                {
                    ID = v.id,
                    Nom = v.nom.Trim(),
                    Prenom = v.prenom.Trim() // Attention : pas d'accent ici pour correspondre au C#
                })
                .OrderBy(v => v.Nom)
                .ToList();

            dgvVisiteurs.DataSource = liste;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvVisiteurs.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner un visiteur.");
                return;
            }

            // On récupère l'ID via la colonne "ID" (même si elle est masquée)
            string id = dgvVisiteurs.CurrentRow.Cells["ID"].Value.ToString();
            string nom = dgvVisiteurs.CurrentRow.Cells["Nom"].Value.ToString();

            // Règle de gestion : vérifier les rapports avant de supprimer
            int nbRapports = dbContext.rapports.Count(r => r.idVisiteur == id);

            if (nbRapports > 0)
            {
                MessageBox.Show($"Impossible de supprimer {nom} car il possède {nbRapports} rapport(s).", "Sécurité");
                return;
            }

            if (MessageBox.Show($"Voulez-vous vraiment supprimer {nom} ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var v = dbContext.visiteurs.Find(id);
                if (v != null)
                {
                    dbContext.visiteurs.Remove(v);
                    dbContext.SaveChanges();

                    MessageBox.Show("Suppression réussie.");
                    ChargerVisiteurs(); // Mise à jour de la grille
                }
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}