using System;
       using System.Windows.Forms;

namespace GestionPrets
{
    public partial class Form1 : Form
    {
        private DatabaseService dbService = new DatabaseService();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Veuillez entrer votre email et mot de passe!");
                return;
            }

            // Demo login - in production you would validate against database
            if (email == "gest@example.com" && password == "pass" ||
                email == "emp@example.com" && password == "pass" ||
                email == "admin@example.com" && password == "pass")
            {
                // Open Menu Form
                MenuForm menuForm = new MenuForm();
                menuForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Connexion échouée! Vérifiez vos identifiants.");
            }
        }
    }
}
