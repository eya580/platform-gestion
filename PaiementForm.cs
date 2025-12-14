using System;
using System.Windows.Forms;

namespace GestionPrets
{
    public partial class PaiementForm : Form
    {
        private DatabaseService dbService;

        public PaiementForm(DatabaseService service)
        {
            InitializeComponent();
            dbService = service;
        }

        private void PaiementForm_Load(object sender, EventArgs e)
        {
            LoadPaiements();
            PopulateLoansCombo();
        }

        private void PopulateLoansCombo()
        {
            try
            {
                var prets = dbService.GetAllPrets();
                cmbPrets.DataSource = prets;
                cmbPrets.DisplayMember = "NomEmprunteur";
                cmbPrets.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des prêts : " + ex.Message);
            }
        }

        private void LoadPaiements()
        {
            dgvPaiements.Rows.Clear();

            try
            {
                var paiements = dbService.GetAllPaiements();
                var prets = dbService.GetAllPrets();

                foreach (var paiement in paiements)
                {
                    var pret = dbService.GetPretById(paiement.PretId);
                    string pretName = pret?.NomEmprunteur ?? "N/A";

                    dgvPaiements.Rows.Add(
                        paiement.Id,
                        paiement.PretId,
                        pretName,
                        paiement.Montant.ToString("N2"),
                        paiement.Date.ToString("dd/MM/yyyy"),
                        paiement.ModePaiement,
                        paiement.NumeroTransaction
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des paiements : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnAjouterPaiement_Click(object sender, EventArgs e)
        {
            if (!ValidateFields(out int pretId, out decimal montant))
                return;

            try
            {
                dbService.AddPaiement(pretId, montant, dtpDate.Value, txtModePaiement.Text.Trim(), txtNumeroTransaction.Text.Trim());
                MessageBox.Show("Paiement ajouté avec succès !");
                ClearFields();
                LoadPaiements();
                PopulateLoansCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout du paiement : " + ex.Message);
            }
        }

        private void btnSupprimerPaiement_Click(object sender, EventArgs e)
        {
            if (dgvPaiements.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un paiement");
                return;
            }

            int paiementId = Convert.ToInt32(dgvPaiements.SelectedRows[0].Cells[0].Value);

            if (MessageBox.Show(
                "Êtes-vous sûr de vouloir supprimer ce paiement ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                dbService.DeletePaiement(paiementId);
                MessageBox.Show("Paiement supprimé avec succès !");
                LoadPaiements();
                PopulateLoansCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression du paiement : " + ex.Message);
            }
        }

        private bool ValidateFields(out int pretId, out decimal montant)
        {
            pretId = 0;
            montant = 0;

            if (cmbPrets.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtMontant.Text) ||
                string.IsNullOrWhiteSpace(txtModePaiement.Text) ||
                string.IsNullOrWhiteSpace(txtNumeroTransaction.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs");
                return false;
            }

            if (!int.TryParse(cmbPrets.SelectedValue.ToString(), out pretId))
            {
                MessageBox.Show("Identifiant du prêt invalide");
                return false;
            }

            if (!decimal.TryParse(txtMontant.Text, out montant))
            {
                MessageBox.Show("Montant invalide");
                return false;
            }

            if (montant <= 0)
            {
                MessageBox.Show("Le montant doit être positif");
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            cmbPrets.SelectedIndex = -1;
            txtMontant.Clear();
            txtModePaiement.Clear();
            txtNumeroTransaction.Clear();
            dtpDate.Value = DateTime.Now;
        }
    }
}
