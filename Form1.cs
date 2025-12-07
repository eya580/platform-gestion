using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestionPrets
{
    public partial class Form1 : Form
    {
        private SystemeGestionPrets systeme = new SystemeGestionPrets();

        public Form1()
        {
            InitializeComponent();
            // Ajouter des utilisateurs de test
            systeme.utilisateurs.Add(new GestionnairePrets(1, "Gestionnaire", "gest@example.com", "pass", "MAT001", "Prêts"));
            systeme.utilisateurs.Add(new Emprunteur(2, "Emprunteur", "emp@example.com", "pass", "ID001", "123456789", "Adresse", 750));
            systeme.utilisateurs.Add(new Administrateur(3, "Admin", "admin@example.com", "pass", "Niveau1", new List<string> { "Lire", "Écrire" }));
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            foreach (var user in systeme.utilisateurs)
            {
                if (user.SeConnecter(email, password))
                {
                    if (user is GestionnairePrets)
                    {
                        PretForm pretForm = new PretForm(systeme);
                        pretForm.Show();
                    }
                    else if (user is Emprunteur)
                    {
                        MessageBox.Show("Bienvenue Emprunteur!");
                    }
                    else if (user is Administrateur)
                    {
                        MessageBox.Show("Bienvenue Administrateur!");
                    }
                    this.Hide();
                    return;
                }
            }
            MessageBox.Show("Connexion échouée!");
        }
    }
}
