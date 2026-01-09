using System;
using System.Windows.Forms;

namespace mission3c
{
    public partial class FrmAccueil : Form
    {
        public FrmAccueil()
        {
            InitializeComponent();

            // --- ETAPE IMPORTANTE : LIAISON MANUELLE DES BOUTONS ---
            // Comme les événements ne sont pas dans le Designer, on les ajoute ici.
            this.btnAjouterVisiteur.Click += new EventHandler(this.BtnAjouterVisiteur_Click);
            this.btnGererVisiteurs.Click += new EventHandler(this.BtnSupprimerVisiteur_Click);
            this.btnVoirRapports.Click += new EventHandler(this.BtnVoirRapports_Click);
        }

        private void FrmAccueil_Load(object sender, EventArgs e)
        {
            // Rien de spécial au chargement pour l'instant
        }

        private void BtnAjouterVisiteur_Click(object sender, EventArgs e)
        {
            FrmVisiteurs frm = new FrmVisiteurs();
            frm.ShowDialog();
        }

        private void BtnSupprimerVisiteur_Click(object sender, EventArgs e)
        {
            FrmSupprimerVisiteur frm = new FrmSupprimerVisiteur();
            frm.ShowDialog();
        }

        private void BtnVoirRapports_Click(object sender, EventArgs e)
        {
            // Assure-toi d'avoir créé FrmRapports, sinon mets cette ligne en commentaire
            FrmRapports frm = new FrmRapports();
            frm.ShowDialog();
        }
    }
}