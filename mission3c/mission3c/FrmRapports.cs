using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;                 // Pour gérer les fichiers
using System.Xml.Serialization; // Pour créer le XML

namespace mission3c
{
    public partial class FrmRapports : Form
    {
        private gsbrapports2016Entities dbContext;

        public FrmRapports()
        {
            InitializeComponent();

            try
            {
                dbContext = new gsbrapports2016Entities();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion : " + ex.Message);
            }

            // --- LIAISON MANUELLE DES ÉVÉNEMENTS ---
            // (Indispensable car absent de votre fichier Designer)
            this.cboVisiteurs.SelectedIndexChanged += new EventHandler(this.CboVisiteurs_SelectedIndexChanged);
            this.btnExporterXML.Click += new EventHandler(this.BtnExporterXML_Click);
            this.btnFermer.Click += new EventHandler(this.BtnFermer_Click);
        }

        private void FrmRapports_Load(object sender, EventArgs e)
        {
            // Au chargement de la fenêtre, on remplit la liste des visiteurs
            RemplirComboVisiteurs();
        }

        private void RemplirComboVisiteurs()
        {
            // On récupère tous les visiteurs
            // On utilise .Trim() pour nettoyer les espaces inutiles de SQL Server
            var listeVisiteurs = dbContext.visiteurs
                .OrderBy(v => v.nom)
                .Select(v => new
                {
                    // On crée une colonne "NomComplet" pour l'affichage
                    NomComplet = v.nom.Trim() + " " + v.prenom.Trim(),
                    // On garde l'ID pour savoir qui est sélectionné
                    Id = v.id
                })
                .ToList();

            // On lie la liste obtenue à la ComboBox
            cboVisiteurs.DataSource = listeVisiteurs;
            cboVisiteurs.DisplayMember = "NomComplet"; // Ce qu'on affiche
            cboVisiteurs.ValueMember = "Id";           // La valeur cachée
        }

        private void CboVisiteurs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Sécurité : on vérifie que la sélection est valide
            if (cboVisiteurs.SelectedValue == null) return;

            string idVisiteur = cboVisiteurs.SelectedValue.ToString();

            // Requête LINQ pour récupérer les rapports du visiteur sélectionné
            var rapports = dbContext.rapports
                .Where(r => r.idVisiteur == idVisiteur)
                .Select(r => new
                {
                    Date = r.date,
                    // Jointure avec la table Médecin pour avoir le nom
                    Médecin = r.medecin.nom.Trim() + " " + r.medecin.prenom.Trim(),
                    Motif = r.motif.Trim(),
                    Bilan = r.bilan.Trim()
                })
                .OrderByDescending(r => r.Date) // Les plus récents en premier
                .ToList();

            // Affichage dans le tableau
            dgvRapports.DataSource = rapports;

            // Ajuste la largeur des colonnes pour que tout rentre
            dgvRapports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BtnExporterXML_Click(object sender, EventArgs e)
        {
            // Vérifie s'il y a des données à exporter
            if (dgvRapports.Rows.Count == 0 || dgvRapports.DataSource == null)
            {
                MessageBox.Show("Veuillez sélectionner un visiteur avec des rapports.", "Rien à exporter");
                return;
            }

            // On prépare la liste des objets à exporter
            var source = dgvRapports.DataSource as System.Collections.IList;
            var listeAExporter = new List<RapportExportable>();

            foreach (dynamic item in source)
            {
                listeAExporter.Add(new RapportExportable
                {
                    Date = item.Date,
                    Medecin = item.Médecin,
                    Motif = item.Motif,
                    Bilan = item.Bilan
                });
            }

            // Boîte de dialogue pour choisir où enregistrer le fichier
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Fichier XML (*.xml)|*.xml";
            saveDialog.FileName = $"Rapports_{DateTime.Now:yyyyMMdd}.xml";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<RapportExportable>));
                    using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                    {
                        serializer.Serialize(writer, listeAExporter);
                    }
                    MessageBox.Show("Exportation réussie !", "Succès");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'export : " + ex.Message);
                }
            }
        }

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // --- CLASSE TECHNIQUE POUR L'EXPORT XML ---
    // Elle doit être "public" pour que le sérialiseur XML puisse l'utiliser.
    public class RapportExportable
    {
        public DateTime? Date { get; set; }
        public string Medecin { get; set; }
        public string Motif { get; set; }
        public string Bilan { get; set; }
    }
}