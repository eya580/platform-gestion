using System;
using System.Windows.Forms;

namespace GestionPrets
{
    public partial class MenuForm : Form
    {
        private DatabaseService dbService;

        public MenuForm()
        {
            InitializeComponent();
            dbService = new DatabaseService();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Gestion des Prêts - Sélectionnez une Table";
        }

        private void btnEmprunteurs_Click(object sender, EventArgs e)
        {
            TableManagementForm form = new TableManagementForm(dbService, "Emprunteurs");
            form.ShowDialog();
        }

        private void btnPrets_Click(object sender, EventArgs e)
        {
            TableManagementForm form = new TableManagementForm(dbService, "Prets");
            form.ShowDialog();
        }

        private void btnPaiements_Click(object sender, EventArgs e)
        {
            TableManagementForm form = new TableManagementForm(dbService, "Paiements");
            form.ShowDialog();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
