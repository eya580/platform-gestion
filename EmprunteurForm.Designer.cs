namespace GestionPrets
{
    partial class EmprunteurForm
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            this.lblNumeroIdentite = new System.Windows.Forms.Label();
            this.txtNumeroIdentite = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.lblAdresse = new System.Windows.Forms.Label();
            this.txtAdresse = new System.Windows.Forms.TextBox();
            this.lblScoreCredit = new System.Windows.Forms.Label();
            this.nudScoreCredit = new System.Windows.Forms.NumericUpDown();
            this.btnAjouterEmprunteur = new System.Windows.Forms.Button();
            this.btnModifierEmprunteur = new System.Windows.Forms.Button();
            this.btnSupprimerEmprunteur = new System.Windows.Forms.Button();
            this.dgvEmprunteurs = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumeroIdentite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdresse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScoreCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprunteurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScoreCredit)).BeginInit();
            this.SuspendLayout();

            // lblNumeroIdentite
            this.lblNumeroIdentite.AutoSize = true;
            this.lblNumeroIdentite.Location = new System.Drawing.Point(12, 15);
            this.lblNumeroIdentite.Name = "lblNumeroIdentite";
            this.lblNumeroIdentite.Size = new System.Drawing.Size(111, 15);
            this.lblNumeroIdentite.TabIndex = 0;
            this.lblNumeroIdentite.Text = "Numéro Identité:";

            // txtNumeroIdentite
            this.txtNumeroIdentite.Location = new System.Drawing.Point(140, 12);
            this.txtNumeroIdentite.Name = "txtNumeroIdentite";
            this.txtNumeroIdentite.Size = new System.Drawing.Size(300, 23);
            this.txtNumeroIdentite.TabIndex = 1;

            // lblNom
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(12, 45);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(42, 15);
            this.lblNom.TabIndex = 2;
            this.lblNom.Text = "Nom:";

            // txtNom
            this.txtNom.Location = new System.Drawing.Point(60, 42);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(380, 23);
            this.txtNom.TabIndex = 3;

            // lblTelephone
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Location = new System.Drawing.Point(12, 75);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(71, 15);
            this.lblTelephone.TabIndex = 4;
            this.lblTelephone.Text = "Téléphone:";

            // txtTelephone
            this.txtTelephone.Location = new System.Drawing.Point(92, 72);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(348, 23);
            this.txtTelephone.TabIndex = 5;

            // lblAdresse
            this.lblAdresse.AutoSize = true;
            this.lblAdresse.Location = new System.Drawing.Point(12, 105);
            this.lblAdresse.Name = "lblAdresse";
            this.lblAdresse.Size = new System.Drawing.Size(60, 15);
            this.lblAdresse.TabIndex = 6;
            this.lblAdresse.Text = "Adresse:";

            // txtAdresse
            this.txtAdresse.Location = new System.Drawing.Point(78, 102);
            this.txtAdresse.Name = "txtAdresse";
            this.txtAdresse.Size = new System.Drawing.Size(362, 23);
            this.txtAdresse.TabIndex = 7;

            // lblScoreCredit
            this.lblScoreCredit.AutoSize = true;
            this.lblScoreCredit.Location = new System.Drawing.Point(12, 135);
            this.lblScoreCredit.Name = "lblScoreCredit";
            this.lblScoreCredit.Size = new System.Drawing.Size(84, 15);
            this.lblScoreCredit.TabIndex = 8;
            this.lblScoreCredit.Text = "Score Crédit:";

            // nudScoreCredit
            this.nudScoreCredit.Location = new System.Drawing.Point(102, 132);
            this.nudScoreCredit.Name = "nudScoreCredit";
            this.nudScoreCredit.Size = new System.Drawing.Size(120, 23);
            this.nudScoreCredit.TabIndex = 9;
            this.nudScoreCredit.Minimum = 0;
            this.nudScoreCredit.Maximum = 1000;

            // btnAjouterEmprunteur
            this.btnAjouterEmprunteur.Location = new System.Drawing.Point(50, 170);
            this.btnAjouterEmprunteur.Name = "btnAjouterEmprunteur";
            this.btnAjouterEmprunteur.Size = new System.Drawing.Size(120, 30);
            this.btnAjouterEmprunteur.TabIndex = 10;
            this.btnAjouterEmprunteur.Text = "Ajouter";
            this.btnAjouterEmprunteur.Click += new System.EventHandler(this.btnAjouterEmprunteur_Click);

            // btnModifierEmprunteur
            this.btnModifierEmprunteur.Location = new System.Drawing.Point(186, 170);
            this.btnModifierEmprunteur.Name = "btnModifierEmprunteur";
            this.btnModifierEmprunteur.Size = new System.Drawing.Size(120, 30);
            this.btnModifierEmprunteur.TabIndex = 11;
            this.btnModifierEmprunteur.Text = "Modifier";
            this.btnModifierEmprunteur.Click += new System.EventHandler(this.btnModifierEmprunteur_Click);

            // btnSupprimerEmprunteur
            this.btnSupprimerEmprunteur.Location = new System.Drawing.Point(322, 170);
            this.btnSupprimerEmprunteur.Name = "btnSupprimerEmprunteur";
            this.btnSupprimerEmprunteur.Size = new System.Drawing.Size(120, 30);
            this.btnSupprimerEmprunteur.TabIndex = 12;
            this.btnSupprimerEmprunteur.Text = "Supprimer";
            this.btnSupprimerEmprunteur.Click += new System.EventHandler(this.btnSupprimerEmprunteur_Click);

            // dgvEmprunteurs
            this.dgvEmprunteurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmprunteurs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colNumeroIdentite,
            this.colNom,
            this.colTelephone,
            this.colAdresse,
            this.colScoreCredit,
            this.colLoans});
            this.dgvEmprunteurs.Location = new System.Drawing.Point(12, 220);
            this.dgvEmprunteurs.Name = "dgvEmprunteurs";
            this.dgvEmprunteurs.RowTemplate.Height = 25;
            this.dgvEmprunteurs.Size = new System.Drawing.Size(860, 300);
            this.dgvEmprunteurs.TabIndex = 13;
            this.dgvEmprunteurs.SelectionChanged += new System.EventHandler(this.dgvEmprunteurs_SelectionChanged);

            // colId
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";

            // colNumeroIdentite
            this.colNumeroIdentite.HeaderText = "Numéro Identité";
            this.colNumeroIdentite.Name = "colNumeroIdentite";

            // colNom
            this.colNom.HeaderText = "Nom";
            this.colNom.Name = "colNom";

            // colTelephone
            this.colTelephone.HeaderText = "Téléphone";
            this.colTelephone.Name = "colTelephone";

            // colAdresse
            this.colAdresse.HeaderText = "Adresse";
            this.colAdresse.Name = "colAdresse";

            // colScoreCredit
            this.colScoreCredit.HeaderText = "Score Crédit";
            this.colScoreCredit.Name = "colScoreCredit";

            // colLoans
            this.colLoans.HeaderText = "Nombre de Prêts";
            this.colLoans.Name = "colLoans";

            // EmprunteurForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 541);
            this.Controls.Add(this.dgvEmprunteurs);
            this.Controls.Add(this.btnSupprimerEmprunteur);
            this.Controls.Add(this.btnModifierEmprunteur);
            this.Controls.Add(this.btnAjouterEmprunteur);
            this.Controls.Add(this.nudScoreCredit);
            this.Controls.Add(this.lblScoreCredit);
            this.Controls.Add(this.txtAdresse);
            this.Controls.Add(this.lblAdresse);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.lblTelephone);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.txtNumeroIdentite);
            this.Controls.Add(this.lblNumeroIdentite);
            this.Name = "EmprunteurForm";
            this.Text = "Gestion des Emprunteurs";
            this.Load += new System.EventHandler(this.EmprunteurForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprunteurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScoreCredit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblNumeroIdentite;
        private System.Windows.Forms.TextBox txtNumeroIdentite;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label lblAdresse;
        private System.Windows.Forms.TextBox txtAdresse;
        private System.Windows.Forms.Label lblScoreCredit;
        private System.Windows.Forms.NumericUpDown nudScoreCredit;
        private System.Windows.Forms.Button btnAjouterEmprunteur;
        private System.Windows.Forms.Button btnModifierEmprunteur;
        private System.Windows.Forms.Button btnSupprimerEmprunteur;
        private System.Windows.Forms.DataGridView dgvEmprunteurs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroIdentite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdresse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScoreCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoans;
    }
}
