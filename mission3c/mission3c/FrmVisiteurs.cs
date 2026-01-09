using System;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions; // Pour vérifier le Code Postal

namespace mission3c
{
    public partial class FrmVisiteurs : Form
    {
        private gsbrapports2016Entities dbContext;

        public FrmVisiteurs()
        {
            InitializeComponent();

            try
            {
                dbContext = new gsbrapports2016Entities();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur connexion BDD : " + ex.Message);
            }

            // --- LIAISON DES ÉVÉNEMENTS ---
            this.btnEnregistrer.Click += new EventHandler(this.btnEnregistrer_Click);
            this.btnAnnuler.Click += new EventHandler(this.btnAnnuler_Click);

            // Liaison pour générer le login quand on tape le nom ou le prénom
            this.txtNom.TextChanged += (s, e) => GenererLoginMdp();
            this.txtPrenom.TextChanged += (s, e) => GenererLoginMdp();
        }

        private void FrmVisiteurs_Load(object sender, EventArgs e)
        {
            // Initialisation au chargement de la page
            GenererLoginMdp();
        }

        private void GenererLoginMdp()
        {
            // Récupère nom et prénom, enlève les espaces et met en minuscule
            string p = txtPrenom.Text.Trim().ToLower().Replace(" ", "");
            string n = txtNom.Text.Trim().ToLower().Replace(" ", "");

            // Login : 1ère lettre du prénom + nom complet
            string login = (p.Length > 0 ? p.Substring(0, 1) : "") + n;

            // Coupe si ça dépasse 20 caractères (limite SQL Server)
            if (login.Length > 20) login = login.Substring(0, 20);

            txtLogin.Text = login;

            // Mot de passe : génère une chaîne aléatoire si le champ est vide
            if (string.IsNullOrEmpty(txtMdp.Text))
            {
                var r = new Random();
                const string chars = "abcdef0123456789";
                txtMdp.Text = new string(Enumerable.Repeat(chars, 5).Select(s => s[r.Next(s.Length)]).ToArray());
            }
        }

        // Fonction pour trouver le prochain ID libre (ex: f056)
        private string GenererProchainId()
        {
            var maxId = dbContext.visiteurs
                .Where(v => v.id.StartsWith("f"))
                .OrderByDescending(v => v.id)
                .Select(v => v.id).FirstOrDefault();

            int num = 1;
            if (maxId != null && int.TryParse(maxId.Substring(1), out int current))
                num = current + 1;

            return "f" + num.ToString("D3");
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            // 1. Vérifications
            if (string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtPrenom.Text) ||
                string.IsNullOrWhiteSpace(txtAdresse.Text) || !Regex.IsMatch(txtCp.Text, @"^\d{5}$"))
            {
                MessageBox.Show("Veuillez remplir les champs. Le Code Postal doit faire 5 chiffres.", "Erreur");
                return;
            }

            try
            {
                // 2. Création de l'objet Visiteur
                // Le .Trim() est important pour SQL Server
                visiteur v = new visiteur
                {
                    id = GenererProchainId(),
                    nom = txtNom.Text.Trim(),
                    prenom = txtPrenom.Text.Trim(),
                    login = txtLogin.Text.Trim(),
                    mdp = txtMdp.Text.Trim(),
                    adresse = txtAdresse.Text.Trim(),
                    cp = txtCp.Text.Trim(),
                    ville = txtVille.Text.Trim(),
                    dateEmbauche = dtpDateEmbauche.Value
                };

                // 3. Sauvegarde
                dbContext.visiteurs.Add(v);
                dbContext.SaveChanges();

                MessageBox.Show($"Visiteur ajouté avec succès ! ID : {v.id}", "Succès");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement : " + ex.Message);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}