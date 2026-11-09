using System;
using System.Linq;
using System.Windows.Forms;

namespace GestionPrets
{
    public partial class PretForm : Form
    {
        private SystemeGestionPrets systeme;

        public PretForm(SystemeGestionPrets sys)
        {
            InitializeComponent();
            systeme = sys;
            cmbTypeCalcul.DataSource = Enum.GetValues(typeof(TypeCalcul));
        }

        private void btnAjouterPret_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                string nomEmprunteur = txtNomEmprunteur.Text;
                int emprunteurId = int.Parse(txtEmprunteurId.Text);
                decimal montantPrincipal = decimal.Parse(txtMontantPrincipal.Text);
                decimal tauxInteret = decimal.Parse(txtTauxInteret.Text);
                // Pour permettre un taux d'intérêt réel (par exemple 5.5 pour 5.5%), divisez par 100 pour obtenir le taux décimal
                tauxInteret = tauxInteret / 100;
                double dureeAnnees = double.Parse(txtDureeAnnees.Text);
                TypeCalcul typeCalcul = (TypeCalcul)cmbTypeCalcul.SelectedItem;

                Pret pret = new Pret(id, nomEmprunteur, emprunteurId, montantPrincipal, tauxInteret, dureeAnnees, typeCalcul);
                systeme.AjouterPret(pret);
                MessageBox.Show($"Prêt ajouté! Montant total à payer: {pret.MontantTotalAPayer}");
                RafraichirListePrets();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout: " + ex.Message);
            }
        }

        private void btnAfficherListe_Click(object sender, EventArgs e)
        {
            RafraichirListePrets();
        }

        private void RafraichirListePrets()
        {
            dgvPrets.Rows.Clear();
            foreach (var pret in systeme.prets)
            {
                // Pour afficher le taux en pourcentage (multipliez par 100), ajustez selon vos besoins
                decimal tauxAffichage = pret.TauxInteret * 100;
                dgvPrets.Rows.Add(pret.Id, pret.NomEmprunteur, pret.MontantPrincipal, tauxAffichage, pret.DureeAnnees, pret.TypeCalcul, pret.Statut, pret.MontantTotalAPayer, pret.ProchaineEcheance(), pret.ResteAPayer(systeme.paiements));
            }
        }

        private void btnStatistiques_Click(object sender, EventArgs e)
        {
            var stats = systeme.ObtenirStatistiques();
            MessageBox.Show($"Total Prêts: {stats.NombreTotalPrets}, Montant Total: {stats.MontantTotalPrete}, Intérêts Totaux: {stats.InteretsTotaux}");
        }

        private void btnVerifierAlertes_Click(object sender, EventArgs e)
        {
            systeme.VerifierAlertes();
            MessageBox.Show("Alertes vérifiées. Nombre d'alertes: " + systeme.alertes.Count);
        }

        private void btnConsulterHistorique_Click(object sender, EventArgs e)
        {
            var historique = systeme.paiements;
            string message = "Historique des paiements:\n";
            foreach (var p in historique)
            {
                message += $"ID: {p.Id}, Montant: {p.Montant}, Date: {p.Date}\n";
            }
            MessageBox.Show(message);
        }

        private void btnCalculerInterets_Click(object sender, EventArgs e)
        {
            decimal interetSimple = systeme.CalculerInteretSimple(10000, 0.05m, 5);
            decimal interetCompose = systeme.CalculerInteretCompose(10000, 0.05m, 5);
            decimal amortissement = systeme.CalculerAmortissement(10000, 0.05m, 5);
            MessageBox.Show($"Intérêt Simple: {interetSimple}\nIntérêt Composé: {interetCompose}\nAmortissement: {amortissement}");
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
