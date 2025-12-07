namespace GestionPrets
{
    partial class PretForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNomEmprunteur = new System.Windows.Forms.TextBox();
            this.txtEmprunteurId = new System.Windows.Forms.TextBox();
            this.txtMontantPrincipal = new System.Windows.Forms.TextBox();
            this.txtTauxInteret = new System.Windows.Forms.TextBox();
            this.txtDureeAnnees = new System.Windows.Forms.TextBox();
            this.cmbTypeCalcul = new System.Windows.Forms.ComboBox();
            this.btnAjouterPret = new System.Windows.Forms.Button();
            this.btnAfficherListe = new System.Windows.Forms.Button();
            this.dgvPrets = new System.Windows.Forms.DataGridView();
            this.btnStatistiques = new System.Windows.Forms.Button();
            this.btnVerifierAlertes = new System.Windows.Forms.Button();
            this.btnConsulterHistorique = new System.Windows.Forms.Button();
            this.btnCalculerInterets = new System.Windows.Forms.Button();
            this.labelId = new System.Windows.Forms.Label();
            this.labelNomEmprunteur = new System.Windows.Forms.Label();
            this.labelEmprunteurId = new System.Windows.Forms.Label();
            this.labelMontantPrincipal = new System.Windows.Forms.Label();
            this.labelTauxInteret = new System.Windows.Forms.Label();
            this.labelDureeAnnees = new System.Windows.Forms.Label();
            this.labelTypeCalcul = new System.Windows.Forms.Label();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNomEmprunteur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMontantPrincipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTauxInteret = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDureeAnnees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTypeCalcul = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMontantTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProchaineEcheance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnResteAPayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrets)).BeginInit();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(200, 20);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 0;
            // 
            // txtNomEmprunteur
            // 
            this.txtNomEmprunteur.Location = new System.Drawing.Point(200, 50);
            this.txtNomEmprunteur.Name = "txtNomEmprunteur";
            this.txtNomEmprunteur.Size = new System.Drawing.Size(100, 20);
            this.txtNomEmprunteur.TabIndex = 1;
            // 
            // txtEmprunteurId
            // 
            this.txtEmprunteurId.Location = new System.Drawing.Point(200, 80);
            this.txtEmprunteurId.Name = "txtEmprunteurId";
            this.txtEmprunteurId.Size = new System.Drawing.Size(100, 20);
            this.txtEmprunteurId.TabIndex = 2;
            // 
            // txtMontantPrincipal
            // 
            this.txtMontantPrincipal.Location = new System.Drawing.Point(200, 110);
            this.txtMontantPrincipal.Name = "txtMontantPrincipal";
            this.txtMontantPrincipal.Size = new System.Drawing.Size(100, 20);
            this.txtMontantPrincipal.TabIndex = 3;
            // 
            // txtTauxInteret
            // 
            this.txtTauxInteret.Location = new System.Drawing.Point(200, 140);
            this.txtTauxInteret.Name = "txtTauxInteret";
            this.txtTauxInteret.Size = new System.Drawing.Size(100, 20);
            this.txtTauxInteret.TabIndex = 4;
            // 
            // txtDureeAnnees
            // 
            this.txtDureeAnnees.Location = new System.Drawing.Point(200, 170);
            this.txtDureeAnnees.Name = "txtDureeAnnees";
            this.txtDureeAnnees.Size = new System.Drawing.Size(100, 20);
            this.txtDureeAnnees.TabIndex = 5;
            // 
            // cmbTypeCalcul
            // 
            this.cmbTypeCalcul.FormattingEnabled = true;
            this.cmbTypeCalcul.Location = new System.Drawing.Point(200, 200);
            this.cmbTypeCalcul.Name = "cmbTypeCalcul";
            this.cmbTypeCalcul.Size = new System.Drawing.Size(100, 21);
            this.cmbTypeCalcul.TabIndex = 6;
            // 
            // btnAjouterPret
            // 
            this.btnAjouterPret.Location = new System.Drawing.Point(50, 230);
            this.btnAjouterPret.Name = "btnAjouterPret";
            this.btnAjouterPret.Size = new System.Drawing.Size(150, 30);
            this.btnAjouterPret.TabIndex = 7;
            this.btnAjouterPret.Text = "Ajouter Prêt";
            this.btnAjouterPret.UseVisualStyleBackColor = true;
            this.btnAjouterPret.Click += new System.EventHandler(this.btnAjouterPret_Click);
            // 
            // btnAfficherListe
            // 
            this.btnAfficherListe.Location = new System.Drawing.Point(220, 230);
            this.btnAfficherListe.Name = "btnAfficherListe";
            this.btnAfficherListe.Size = new System.Drawing.Size(150, 30);
            this.btnAfficherListe.TabIndex = 8;
            this.btnAfficherListe.Text = "Afficher Liste";
            this.btnAfficherListe.UseVisualStyleBackColor = true;
            this.btnAfficherListe.Click += new System.EventHandler(this.btnAfficherListe_Click);
            // 
            // dgvPrets
            // 
            this.dgvPrets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnNomEmprunteur,
            this.ColumnMontantPrincipal,
            this.ColumnTauxInteret,
            this.ColumnDureeAnnees,
            this.ColumnTypeCalcul,
            this.ColumnStatut,
            this.ColumnMontantTotal,
            this.ColumnProchaineEcheance,
            this.ColumnResteAPayer});
            this.dgvPrets.Location = new System.Drawing.Point(50, 280);
            this.dgvPrets.Name = "dgvPrets";
            this.dgvPrets.Size = new System.Drawing.Size(700, 200);
            this.dgvPrets.TabIndex = 9;
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            // 
            // ColumnNomEmprunteur
            // 
            this.ColumnNomEmprunteur.HeaderText = "Nom Emprunteur";
            this.ColumnNomEmprunteur.Name = "ColumnNomEmprunteur";
            // 
            // ColumnMontantPrincipal
            // 
            this.ColumnMontantPrincipal.HeaderText = "Montant Principal";
            this.ColumnMontantPrincipal.Name = "ColumnMontantPrincipal";
            // 
            // ColumnTauxInteret
            // 
            this.ColumnTauxInteret.HeaderText = "Taux d'Intérêt";
            this.ColumnTauxInteret.Name = "ColumnTauxInteret";
            // 
            // ColumnDureeAnnees
            // 
            this.ColumnDureeAnnees.HeaderText = "Durée (Années)";
            this.ColumnDureeAnnees.Name = "ColumnDureeAnnees";
            // 
            // ColumnTypeCalcul
            // 
            this.ColumnTypeCalcul.HeaderText = "Type de Calcul";
            this.ColumnTypeCalcul.Name = "ColumnTypeCalcul";
            // 
            // ColumnStatut
            // 
            this.ColumnStatut.HeaderText = "Statut";
            this.ColumnStatut.Name = "ColumnStatut";
            // 
            // ColumnMontantTotal
            // 
            this.ColumnMontantTotal.HeaderText = "Montant Total à Payer";
            this.ColumnMontantTotal.Name = "ColumnMontantTotal";
            // 
            // ColumnProchaineEcheance
            // 
            this.ColumnProchaineEcheance.HeaderText = "Prochaine Échéance";
            this.ColumnProchaineEcheance.Name = "ColumnProchaineEcheance";
            // 
            // ColumnResteAPayer
            // 
            this.ColumnResteAPayer.HeaderText = "Reste à Payer";
            this.ColumnResteAPayer.Name = "ColumnResteAPayer";
            // 
            // btnStatistiques
            // 
            this.btnStatistiques.Location = new System.Drawing.Point(50, 500);
            this.btnStatistiques.Name = "btnStatistiques";
            this.btnStatistiques.Size = new System.Drawing.Size(150, 30);
            this.btnStatistiques.TabIndex = 10;
            this.btnStatistiques.Text = "Voir Statistiques";
            this.btnStatistiques.UseVisualStyleBackColor = true;
            this.btnStatistiques.Click += new System.EventHandler(this.btnStatistiques_Click);
            // 
            // btnVerifierAlertes
            // 
            this.btnVerifierAlertes.Location = new System.Drawing.Point(220, 500);
            this.btnVerifierAlertes.Name = "btnVerifierAlertes";
            this.btnVerifierAlertes.Size = new System.Drawing.Size(150, 30);
            this.btnVerifierAlertes.TabIndex = 11;
            this.btnVerifierAlertes.Text = "Vérifier Alertes";
            this.btnVerifierAlertes.UseVisualStyleBackColor = true;
            this.btnVerifierAlertes.Click += new System.EventHandler(this.btnVerifierAlertes_Click);
            // 
            // btnConsulterHistorique
            // 
            this.btnConsulterHistorique.Location = new System.Drawing.Point(390, 500);
            this.btnConsulterHistorique.Name = "btnConsulterHistorique";
            this.btnConsulterHistorique.Size = new System.Drawing.Size(150, 30);
            this.btnConsulterHistorique.TabIndex = 12;
            this.btnConsulterHistorique.Text = "Consulter Historique";
            this.btnConsulterHistorique.UseVisualStyleBackColor = true;
            this.btnConsulterHistorique.Click += new System.EventHandler(this.btnConsulterHistorique_Click);
            // 
            // btnCalculerInterets
            // 
            this.btnCalculerInterets.Location = new System.Drawing.Point(560, 500);
            this.btnCalculerInterets.Name = "btnCalculerInterets";
            this.btnCalculerInterets.Size = new System.Drawing.Size(150, 30);
            this.btnCalculerInterets.TabIndex = 13;
            this.btnCalculerInterets.Text = "Calculer Intérêts";
            this.btnCalculerInterets.UseVisualStyleBackColor = true;
            this.btnCalculerInterets.Click += new System.EventHandler(this.btnCalculerInterets_Click);
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(50, 23);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(20, 13);
            this.labelId.TabIndex = 14;
            this.labelId.Text = "Id:";
            // 
            // labelNomEmprunteur
            // 
            this.labelNomEmprunteur.AutoSize = true;
            this.labelNomEmprunteur.Location = new System.Drawing.Point(50, 53);
            this.labelNomEmprunteur.Name = "labelNomEmprunteur";
            this.labelNomEmprunteur.Size = new System.Drawing.Size(90, 13);
            this.labelNomEmprunteur.TabIndex = 15;
            this.labelNomEmprunteur.Text = "Nom Emprunteur:";
            // 
            // labelEmprunteurId
            // 
            this.labelEmprunteurId.AutoSize = true;
            this.labelEmprunteurId.Location = new System.Drawing.Point(50, 83);
            this.labelEmprunteurId.Name = "labelEmprunteurId";
            this.labelEmprunteurId.Size = new System.Drawing.Size(80, 13);
            this.labelEmprunteurId.TabIndex = 16;
            this.labelEmprunteurId.Text = "Emprunteur Id:";
            // 
            // labelMontantPrincipal
            // 
            this.labelMontantPrincipal.AutoSize = true;
            this.labelMontantPrincipal.Location = new System.Drawing.Point(50, 113);
            this.labelMontantPrincipal.Name = "labelMontantPrincipal";
            this.labelMontantPrincipal.Size = new System.Drawing.Size(100, 13);
            this.labelMontantPrincipal.TabIndex = 17;
            this.labelMontantPrincipal.Text = "Montant Principal:";
            // 
            // labelTauxInteret
            // 
            this.labelTauxInteret.AutoSize = true;
            this.labelTauxInteret.Location = new System.Drawing.Point(50, 143);
            this.labelTauxInteret.Name = "labelTauxInteret";
            this.labelTauxInteret.Size = new System.Drawing.Size(80, 13);
            this.labelTauxInteret.TabIndex = 18;
            this.labelTauxInteret.Text = "Taux d'Intérêt:";
            // 
            // labelDureeAnnees
            // 
            this.labelDureeAnnees.AutoSize = true;
            this.labelDureeAnnees.Location = new System.Drawing.Point(50, 173);
            this.labelDureeAnnees.Name = "labelDureeAnnees";
            this.labelDureeAnnees.Size = new System.Drawing.Size(90, 13);
            this.labelDureeAnnees.TabIndex = 19;
            this.labelDureeAnnees.Text = "Durée (Années):";
            // 
            // labelTypeCalcul
            // 
            this.labelTypeCalcul.AutoSize = true;
            this.labelTypeCalcul.Location = new System.Drawing.Point(50, 203);
            this.labelTypeCalcul.Name = "labelTypeCalcul";
            this.labelTypeCalcul.Size = new System.Drawing.Size(80, 13);
            this.labelTypeCalcul.TabIndex = 20;
            this.labelTypeCalcul.Text = "Type de Calcul:";
            // 
            // PretForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.labelTypeCalcul);
            this.Controls.Add(this.labelDureeAnnees);
            this.Controls.Add(this.labelTauxInteret);
            this.Controls.Add(this.labelMontantPrincipal);
            this.Controls.Add(this.labelEmprunteurId);
            this.Controls.Add(this.labelNomEmprunteur);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.btnCalculerInterets);
            this.Controls.Add(this.btnConsulterHistorique);
            this.Controls.Add(this.btnVerifierAlertes);
            this.Controls.Add(this.btnStatistiques);
            this.Controls.Add(this.dgvPrets);
            this.Controls.Add(this.btnAfficherListe);
            this.Controls.Add(this.btnAjouterPret);
            this.Controls.Add(this.cmbTypeCalcul);
            this.Controls.Add(this.txtDureeAnnees);
            this.Controls.Add(this.txtTauxInteret);
            this.Controls.Add(this.txtMontantPrincipal);
            this.Controls.Add(this.txtEmprunteurId);
            this.Controls.Add(this.txtNomEmprunteur);
            this.Controls.Add(this.txtId);
            this.Name = "PretForm";
            this.Text = "Gestion des Prêts";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNomEmprunteur;
        private System.Windows.Forms.TextBox txtEmprunteurId;
        private System.Windows.Forms.TextBox txtMontantPrincipal;
        private System.Windows.Forms.TextBox txtTauxInteret;
        private System.Windows.Forms.TextBox txtDureeAnnees;
        private System.Windows.Forms.ComboBox cmbTypeCalcul;
        private System.Windows.Forms.Button btnAjouterPret;
        private System.Windows.Forms.Button btnAfficherListe;
        private System.Windows.Forms.DataGridView dgvPrets;
        private System.Windows.Forms.Button btnStatistiques;
        private System.Windows.Forms.Button btnVerifierAlertes;
        private System.Windows.Forms.Button btnConsulterHistorique;
        private System.Windows.Forms.Button btnCalculerInterets;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelNomEmprunteur;
        private System.Windows.Forms.Label labelEmprunteurId;
        private System.Windows.Forms.Label labelMontantPrincipal;
        private System.Windows.Forms.Label labelTauxInteret;
        private System.Windows.Forms.Label labelDureeAnnees;
        private System.Windows.Forms.Label labelTypeCalcul;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNomEmprunteur;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMontantPrincipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTauxInteret;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDureeAnnees;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTypeCalcul;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatut;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMontantTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProchaineEcheance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnResteAPayer;
    }
}