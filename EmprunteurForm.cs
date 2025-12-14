using System;
using System.Windows.Forms;

namespace GestionPrets
{
    public partial class EmprunteurForm : Form
    {
        private DatabaseService dbService;

        public EmprunteurForm(DatabaseService service)
        {
            InitializeComponent();
            dbService = service;
        }

        private void EmprunteurForm_Load(object sender, EventArgs e)
        {
            LoadEmprunteurs();
        }

        private void LoadEmprunteurs()
        {
            dgvEmprunteurs.Rows.Clear();

            try
            {
                var emprunteurs = dbService.GetAllEmprunteurs();
                var prets = dbService.GetAllPrets();

                foreach (var emprunteur in emprunteurs)
                {
                    // Count loans for this borrower
                    int loanCount = 0;
                    foreach (var pret in prets)
                    {
                        if (pret.EmprunteurId == emprunteur.Id)
                            loanCount++;
                    }

                    dgvEmprunteurs.Rows.Add(
                        emprunteur.Id,
                        emprunteur.NumeroIdentite,
                        emprunteur.Nom,
                        emprunteur.Telephone,
                        emprunteur.Adresse,
                        emprunteur.ScoreCredit.ToString("N0"),
                        loanCount
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des emprunteurs : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnAjouterEmprunteur_Click(object sender, EventArgs e)
        {
            if (!ValidateFields(out string numeroIdentite, out string nom, out string telephone, 
                out string adresse, out decimal scoreCredit))
                return;

            try
            {
                dbService.AddEmprunteur(numeroIdentite, nom, telephone, adresse, scoreCredit);
                MessageBox.Show("Emprunteur ajouté avec succès !");
                ClearFields();
                LoadEmprunteurs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout : " + ex.Message);
            }
        }

        private void btnModifierEmprunteur_Click(object sender, EventArgs e)
        {
            if (dgvEmprunteurs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un emprunteur");
                return;
            }

            if (!ValidateFields(out string numeroIdentite, out string nom, out string telephone,
                out string adresse, out decimal scoreCredit))
                return;

            int emprunteurId = Convert.ToInt32(dgvEmprunteurs.SelectedRows[0].Cells[0].Value);

            try
            {
                dbService.UpdateEmprunteur(emprunteurId, numeroIdentite, nom, telephone, adresse, scoreCredit);
                MessageBox.Show("Emprunteur modifié avec succès !");
                ClearFields();
                LoadEmprunteurs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification : " + ex.Message);
            }
        }

        private void btnSupprimerEmprunteur_Click(object sender, EventArgs e)
        {
            if (dgvEmprunteurs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un emprunteur");
                return;
            }

            int emprunteurId = Convert.ToInt32(dgvEmprunteurs.SelectedRows[0].Cells[0].Value);

            if (MessageBox.Show(
                "Êtes-vous sûr de vouloir supprimer cet emprunteur ? Les prêts associés seront également supprimés.",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                dbService.DeleteEmprunteur(emprunteurId);
                MessageBox.Show("Emprunteur supprimé avec succès !");
                ClearFields();
                LoadEmprunteurs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
            }
        }

        private void dgvEmprunteurs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmprunteurs.SelectedRows.Count == 0)
                return;

            var row = dgvEmprunteurs.SelectedRows[0];
            txtNumeroIdentite.Text = row.Cells[1].Value?.ToString() ?? "";
            txtNom.Text = row.Cells[2].Value?.ToString() ?? "";
            txtTelephone.Text = row.Cells[3].Value?.ToString() ?? "";
            txtAdresse.Text = row.Cells[4].Value?.ToString() ?? "";

            if (decimal.TryParse(row.Cells[5].Value?.ToString(), out decimal score))
                nudScoreCredit.Value = score;
            else
                nudScoreCredit.Value = 0;
        }

        private bool ValidateFields(out string numeroIdentite, out string nom, out string telephone,
            out string adresse, out decimal scoreCredit)
        {
            numeroIdentite = string.Empty;
            nom = string.Empty;
            telephone = string.Empty;
            adresse = string.Empty;
            scoreCredit = 0;

            if (string.IsNullOrWhiteSpace(txtNumeroIdentite.Text) ||
                string.IsNullOrWhiteSpace(txtNom.Text) ||
                string.IsNullOrWhiteSpace(txtTelephone.Text) ||
                string.IsNullOrWhiteSpace(txtAdresse.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs");
                return false;
            }

            scoreCredit = nudScoreCredit.Value;

            if (scoreCredit < 0 || scoreCredit > 1000)
            {
                MessageBox.Show("Le score de crédit doit être entre 0 et 1000");
                return false;
            }

            numeroIdentite = txtNumeroIdentite.Text.Trim();
            nom = txtNom.Text.Trim();
            telephone = txtTelephone.Text.Trim();
            adresse = txtAdresse.Text.Trim();

            return true;
        }

        private void ClearFields()
        {
            txtNumeroIdentite.Clear();
            txtNom.Clear();
            txtTelephone.Clear();
            txtAdresse.Clear();
            nudScoreCredit.Value = 0;
        }
    }
}
