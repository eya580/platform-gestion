using System;
using System.Linq;
using System.Windows.Forms;

namespace GestionPrets
{
    public partial class PretForm : Form
    {
        private DatabaseService dbService;

        public PretForm(DatabaseService service)
        {
            InitializeComponent();
            dbService = service;
        }

        private void PretForm_Load(object sender, EventArgs e)
        {
            cmbTypeCalcul.DataSource = Enum.GetValues(typeof(TypeCalcul));
            LoadEmprunteurs();
            LoadPrets();
        }

        private void LoadEmprunteurs()
        {
            try
            {
                var emprunteurs = dbService.GetAllEmprunteurs();
                cmbEmprunteur.DisplayMember = "Nom";
                cmbEmprunteur.ValueMember = "Id";
                cmbEmprunteur.DataSource = emprunteurs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des emprunteurs : " + ex.Message);
            }
        }

        private void LoadPrets()
        {
            dgvPrets.Rows.Clear();

            try
            {
                var prets = dbService.GetAllPrets();
                var paiements = dbService.GetAllPaiements();

                foreach (var pret in prets)
                {
                    decimal totalPayment = 0;
                    foreach (var payment in paiements)
                    {
                        if (payment.PretId == pret.Id)
                            totalPayment += payment.Montant;
                    }
                    decimal reste = pret.MontantTotalAPayer - totalPayment;

                    dgvPrets.Rows.Add(
                        pret.Id,
                        pret.NomEmprunteur,
                        pret.MontantPrincipal.ToString("N2"),
                        (pret.TauxInteret * 100).ToString("N2") + "%",
                        pret.DureeAnnees.ToString("N1"),
                        pret.TypeCalcul.ToString(),
                        pret.Statut.ToString(),
                        pret.MontantTotalAPayer.ToString("N2"),
                        pret.ProchaineEcheance().ToString("dd/MM/yyyy"),
                        reste.ToString("N2")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des prêts : " + ex.Message);
            }
        }

        private void btnAjouterPret_Click(object sender, EventArgs e)
        {
            if (!ValidateFields(out string nomEmprunteur, out int emprunteurId, out decimal montant,
                out decimal taux, out double duree, out TypeCalcul typeCalcul))
                return;

            try
            {
                dbService.AddPret(nomEmprunteur, emprunteurId, montant, taux / 100, duree, typeCalcul);
                var pret = new Pret(nomEmprunteur, emprunteurId, montant, taux / 100, duree, typeCalcul);
                MessageBox.Show($"Prêt ajouté avec succès!\nMontant total à payer : {pret.MontantTotalAPayer:N2}");
                ClearFields();
                LoadPrets();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout : " + ex.Message);
            }
        }

        private void btnStatistiques_Click(object sender, EventArgs e)
        {
            try
            {
                var prets = dbService.GetAllPrets();
                var paiements = dbService.GetAllPaiements();

                int totalPrets = prets.Count;
                decimal totalMontant = 0;
                decimal totalInterets = 0;
                decimal totalPaye = 0;

                foreach (var pret in prets)
                {
                    totalMontant += pret.MontantPrincipal;
                    totalInterets += pret.MontantTotalAPayer - pret.MontantPrincipal;
                }

                foreach (var paiement in paiements)
                {
                    totalPaye += paiement.Montant;
                }

                MessageBox.Show(
                    $"=== STATISTIQUES ===\n\n" +
                    $"Total prêts : {totalPrets}\n" +
                    $"Montant total prêté : {totalMontant:N2}\n" +
                    $"Intérêts totaux : {totalInterets:N2}\n" +
                    $"Total payé : {totalPaye:N2}\n" +
                    $"Montant collecté : {totalPaye:N2}"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur statistiques : " + ex.Message);
            }
        }

        private void btnVerifierAlertes_Click(object sender, EventArgs e)
        {
            try
            {
                var prets = dbService.GetAllPrets();
                var paiements = dbService.GetAllPaiements();
                int alertCount = 0;
                string alertsMessage = "=== ALERTES DÉTECTÉES ===\n\n";

                foreach (var pret in prets)
                {
                    if (pret.EstEnRetard(paiements))
                    {
                        alertCount++;
                        alertsMessage += $"⚠️ Prêt #{pret.Id} - {pret.NomEmprunteur}: RETARD DE PAIEMENT\n";
                    }

                    var nextEcheance = pret.ProchaineEcheance();
                    if (nextEcheance != default && (nextEcheance - DateTime.Now).Days <= 7)
                    {
                        alertCount++;
                        alertsMessage += $"ℹ️ Prêt #{pret.Id} - {pret.NomEmprunteur}: Échéance prochaine le {nextEcheance:dd/MM/yyyy}\n";
                    }
                }

                if (alertCount == 0)
                    alertsMessage = "Aucune alerte détectée. Tous les prêts sont à jour.";

                MessageBox.Show(alertsMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur alertes : " + ex.Message);
            }
        }

        private void btnConsulterHistorique_Click(object sender, EventArgs e)
        {
            try
            {
                var paiements = dbService.GetAllPaiements();
                string message = "=== HISTORIQUE DES PAIEMENTS ===\n\n";

                if (paiements.Count == 0)
                {
                    message += "Aucun paiement enregistré.";
                }
                else
                {
                    foreach (var paiement in paiements)
                    {
                        message +=
                            $"ID: {paiement.Id} | Prêt: {paiement.PretId} | " +
                            $"Montant: {paiement.Montant:N2} | " +
                            $"Date: {paiement.Date:dd/MM/yyyy} | " +
                            $"Mode: {paiement.ModePaiement}\n";
                    }
                }

                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur historique : " + ex.Message);
            }
        }

        private void btnCalculerInterets_Click(object sender, EventArgs e)
        {
            decimal principal = 10000;
            decimal taux = 0.05m;
            int annees = 5;

            decimal interetSimple = principal * taux * annees;
            decimal interetCompose =
                principal * (decimal)Math.Pow((double)(1 + taux), annees) - principal;

            decimal i = taux / 12;
            int n = annees * 12;
            decimal mensualite =
                (principal * i) / (1 - (decimal)Math.Pow((double)(1 + i), -n));

            MessageBox.Show(
                $"=== EXEMPLE DE CALCUL D'INTÉRÊTS ===\n\n" +
                $"Principal : {principal:N2}\n" +
                $"Taux annuel : {taux * 100}%\n" +
                $"Durée : {annees} ans\n\n" +
                $"Intérêt simple : {interetSimple:N2}\n" +
                $"Intérêt composé : {interetCompose:N2}\n" +
                $"Mensualité (amortissement) : {mensualite:N2}"
            );
        }

        private bool ValidateFields(out string nomEmprunteur, out int emprunteurId, out decimal montant,
            out decimal taux, out double duree, out TypeCalcul typeCalcul)
        {
            nomEmprunteur = string.Empty;
            emprunteurId = 0;
            montant = 0;
            taux = 0;
            duree = 0;
            typeCalcul = TypeCalcul.Simple;

            if (string.IsNullOrWhiteSpace(txtNomEmprunteur.Text) ||
                cmbEmprunteur.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtMontantPrincipal.Text) ||
                string.IsNullOrWhiteSpace(txtTauxInteret.Text) ||
                string.IsNullOrWhiteSpace(txtDureeAnnees.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs");
                return false;
            }

            if (!int.TryParse(cmbEmprunteur.SelectedValue?.ToString(), out emprunteurId) ||
                !decimal.TryParse(txtMontantPrincipal.Text, out montant) ||
                !decimal.TryParse(txtTauxInteret.Text, out taux) ||
                !double.TryParse(txtDureeAnnees.Text, out duree))
            {
                MessageBox.Show("Valeurs numériques invalides");
                return false;
            }

            if (montant <= 0 || taux < 0 || duree <= 0)
            {
                MessageBox.Show("Les montants et la durée doivent être positifs");
                return false;
            }

            nomEmprunteur = txtNomEmprunteur.Text.Trim();
            typeCalcul = (TypeCalcul)cmbTypeCalcul.SelectedItem;

            return true;
        }

        private void ClearFields()
        {
            txtNomEmprunteur.Clear();
            cmbEmprunteur.SelectedIndex = (cmbEmprunteur.Items.Count > 0) ? 0 : -1;
            txtMontantPrincipal.Clear();
            txtTauxInteret.Clear();
            txtDureeAnnees.Clear();
            cmbTypeCalcul.SelectedIndex = 0;
        }

        private void btnAfficherListe_Click(object sender, EventArgs e)
        {
            LoadPrets();
        }
    }
}
