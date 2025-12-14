using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestionPrets
{
    public partial class TableManagementForm : Form
    {
        private DatabaseService dbService;
        private string currentTable;
        private int selectedRowId = -1;

        public TableManagementForm(DatabaseService service, string tableName)
        {
            InitializeComponent();
            dbService = service;
            currentTable = tableName;
        }

        private void TableManagementForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Gestion - {currentTable}";
            lblTableName.Text = $"Table: {currentTable}";
            LoadTableData();
        }

        private void LoadTableData()
        {
            dgvData.Rows.Clear();
            dgvData.Columns.Clear();

            try
            {
                switch (currentTable)
                {
                    case "Emprunteurs":
                        LoadEmprunteurs();
                        break;
                    case "Prets":
                        LoadPrets();
                        break;
                    case "Paiements":
                        LoadPaiements();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
        }

        private void LoadEmprunteurs()
        {
            dgvData.Columns.Add("Id", "ID");
            dgvData.Columns.Add("NumeroIdentite", "Num. Identité");
            dgvData.Columns.Add("Nom", "Nom");
            dgvData.Columns.Add("Telephone", "Téléphone");
            dgvData.Columns.Add("Adresse", "Adresse");
            dgvData.Columns.Add("ScoreCredit", "Score Crédit");

            var emprunteurs = dbService.GetAllEmprunteurs();
            foreach (var emp in emprunteurs)
            {
                dgvData.Rows.Add(emp.Id, emp.NumeroIdentite, emp.Nom, emp.Telephone, emp.Adresse, emp.ScoreCredit.ToString("N0"));
            }

            pnlInputs.Controls.Clear();
            CreateInputs(new[] { "Num. Identité", "Nom", "Téléphone", "Adresse", "Score Crédit" });
        }

        private void LoadPrets()
        {
            dgvData.Columns.Add("Id", "ID");
            dgvData.Columns.Add("NomEmprunteur", "Emprunteur");
            dgvData.Columns.Add("MontantPrincipal", "Montant Principal");
            dgvData.Columns.Add("TauxInteret", "Taux %");
            dgvData.Columns.Add("DureeAnnees", "Durée (ans)");
            dgvData.Columns.Add("TypeCalcul", "Type Calcul");
            dgvData.Columns.Add("Statut", "Statut");

            var prets = dbService.GetAllPrets();
            foreach (var pret in prets)
            {
                dgvData.Rows.Add(pret.Id, pret.NomEmprunteur, pret.MontantPrincipal.ToString("N2"),
                    (pret.TauxInteret * 100).ToString("N2"), pret.DureeAnnees.ToString("N1"),
                    pret.TypeCalcul.ToString(), pret.Statut.ToString());
            }

            pnlInputs.Controls.Clear();
            CreateInputs(new[] { "Nom Emprunteur", "Emprunteur ID", "Montant Principal", "Taux Intérêt %", "Durée (ans)", "Type Calcul", "Statut" });
        }

        private void LoadPaiements()
        {
            dgvData.Columns.Add("Id", "ID");
            dgvData.Columns.Add("PretId", "Prêt ID");
            dgvData.Columns.Add("Montant", "Montant");
            dgvData.Columns.Add("Date", "Date");
            dgvData.Columns.Add("ModePaiement", "Mode Paiement");
            dgvData.Columns.Add("NumeroTransaction", "N° Transaction");

            var paiements = dbService.GetAllPaiements();
            foreach (var paie in paiements)
            {
                dgvData.Rows.Add(paie.Id, paie.PretId, paie.Montant.ToString("N2"),
                    paie.Date.ToString("dd/MM/yyyy"), paie.ModePaiement, paie.NumeroTransaction);
            }

            pnlInputs.Controls.Clear();
            CreateInputs(new[] { "Prêt ID", "Montant", "Date", "Mode Paiement", "N° Transaction" });
        }

        private void CreateInputs(string[] labels)
        {
            int yPosition = 10;
            pnlInputs.Controls.Clear();

            foreach (var label in labels)
            {
                var lbl = new Label { Text = label, Location = new System.Drawing.Point(10, yPosition), Width = 100, Height = 20 };
                var txt = new TextBox { Name = "txt" + label.Replace(" ", ""), Location = new System.Drawing.Point(120, yPosition), Width = 200, Height = 20 };
                pnlInputs.Controls.Add(lbl);
                pnlInputs.Controls.Add(txt);
                yPosition += 30;
            }
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                selectedRowId = Convert.ToInt32(dgvData.SelectedRows[0].Cells[0].Value);
                FillInputsFromRow(dgvData.SelectedRows[0]);
            }
        }

        private void FillInputsFromRow(DataGridViewRow row)
        {
            int columnIndex = 1;
            foreach (Control ctrl in pnlInputs.Controls)
            {
                if (ctrl is TextBox && columnIndex < row.Cells.Count)
                {
                    ctrl.Text = row.Cells[columnIndex].Value?.ToString() ?? "";
                    columnIndex++;
                }
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                var inputs = GetInputValues();
                switch (currentTable)
                {
                    case "Emprunteurs":
                        dbService.AddEmprunteur(inputs[0], inputs[1], inputs[2], inputs[3], decimal.Parse(inputs[4]));
                        break;
                    case "Prets":
                        dbService.AddPret(inputs[0], int.Parse(inputs[1]), decimal.Parse(inputs[2]),
                            decimal.Parse(inputs[3]) / 100, double.Parse(inputs[4]), (TypeCalcul)Enum.Parse(typeof(TypeCalcul), inputs[5]));
                        break;
                    case "Paiements":
                        dbService.AddPaiement(int.Parse(inputs[0]), decimal.Parse(inputs[1]),
                            DateTime.Parse(inputs[2]), inputs[3], inputs[4]);
                        break;
                }
                MessageBox.Show("Enregistrement ajouté avec succès!");
                LoadTableData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (selectedRowId == -1)
            {
                MessageBox.Show("Veuillez sélectionner un enregistrement");
                return;
            }

            try
            {
                var inputs = GetInputValues();
                switch (currentTable)
                {
                    case "Emprunteurs":
                        dbService.UpdateEmprunteur(selectedRowId, inputs[0], inputs[1], inputs[2], inputs[3], decimal.Parse(inputs[4]));
                        break;
                    case "Prets":
                        dbService.UpdatePret(selectedRowId, inputs[0], int.Parse(inputs[1]), decimal.Parse(inputs[2]),
                            decimal.Parse(inputs[3]) / 100, double.Parse(inputs[4]), (TypeCalcul)Enum.Parse(typeof(TypeCalcul), inputs[5]));
                        break;
                    case "Paiements":
                        dbService.UpdatePaiement(selectedRowId, int.Parse(inputs[0]), decimal.Parse(inputs[1]),
                            DateTime.Parse(inputs[2]), inputs[3], inputs[4]);
                        break;
                }
                MessageBox.Show("Enregistrement modifié avec succès!");
                LoadTableData();
                selectedRowId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (selectedRowId == -1)
            {
                MessageBox.Show("Veuillez sélectionner un enregistrement");
                return;
            }

            if (MessageBox.Show("Êtes-vous sûr?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                switch (currentTable)
                {
                    case "Emprunteurs":
                        dbService.DeleteEmprunteur(selectedRowId);
                        break;
                    case "Prets":
                        dbService.DeletePret(selectedRowId);
                        break;
                    case "Paiements":
                        dbService.DeletePaiement(selectedRowId);
                        break;
                }
                MessageBox.Show("Enregistrement supprimé avec succès!");
                LoadTableData();
                selectedRowId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
        }

        private string[] GetInputValues()
        {
            var values = new List<string>();
            foreach (Control ctrl in pnlInputs.Controls)
            {
                if (ctrl is TextBox txt)
                    values.Add(txt.Text);
            }
            return values.ToArray();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
