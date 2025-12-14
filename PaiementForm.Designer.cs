namespace GestionPrets
{
    partial class PaiementForm
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            this.lblPret = new System.Windows.Forms.Label();
            this.cmbPrets = new System.Windows.Forms.ComboBox();
            this.lblMontant = new System.Windows.Forms.Label();
            this.txtMontant = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblModePaiement = new System.Windows.Forms.Label();
            this.txtModePaiement = new System.Windows.Forms.TextBox();
            this.lblNumeroTransaction = new System.Windows.Forms.Label();
            this.txtNumeroTransaction = new System.Windows.Forms.TextBox();
            this.btnAjouterPaiement = new System.Windows.Forms.Button();
            this.btnSupprimerPaiement = new System.Windows.Forms.Button();
            this.dgvPaiements = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPretId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNomEmprunteur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMontant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModePaiement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumeroTransaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaiements)).BeginInit();
            this.SuspendLayout();

            // lblPret
            this.lblPret.AutoSize = true;
            this.lblPret.Location = new System.Drawing.Point(12, 15);
            this.lblPret.Name = "lblPret";
            this.lblPret.Size = new System.Drawing.Size(42, 15);
            this.lblPret.TabIndex = 0;
            this.lblPret.Text = "Prêt:";

            // cmbPrets
            this.cmbPrets.FormattingEnabled = true;
            this.cmbPrets.Location = new System.Drawing.Point(60, 12);
            this.cmbPrets.Name = "cmbPrets";
            this.cmbPrets.Size = new System.Drawing.Size(224, 23);
            this.cmbPrets.TabIndex = 0;

            // lblMontant
            this.lblMontant.AutoSize = true;
            this.lblMontant.Location = new System.Drawing.Point(12, 45);
            this.lblMontant.Name = "lblMontant";
            this.lblMontant.Size = new System.Drawing.Size(66, 15);
            this.lblMontant.TabIndex = 2;
            this.lblMontant.Text = "Montant:";

            // txtMontant
            this.txtMontant.Location = new System.Drawing.Point(84, 42);
            this.txtMontant.Name = "txtMontant";
            this.txtMontant.Size = new System.Drawing.Size(200, 23);
            this.txtMontant.TabIndex = 3;

            // lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 75);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(38, 15);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date:";

            // dtpDate
            this.dtpDate.Location = new System.Drawing.Point(84, 72);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 23);
            this.dtpDate.TabIndex = 5;

            // lblModePaiement
            this.lblModePaiement.AutoSize = true;
            this.lblModePaiement.Location = new System.Drawing.Point(12, 105);
            this.lblModePaiement.Name = "lblModePaiement";
            this.lblModePaiement.Size = new System.Drawing.Size(112, 15);
            this.lblModePaiement.TabIndex = 6;
            this.lblModePaiement.Text = "Mode de paiement:";

            // txtModePaiement
            this.txtModePaiement.Location = new System.Drawing.Point(130, 102);
            this.txtModePaiement.Name = "txtModePaiement";
            this.txtModePaiement.Size = new System.Drawing.Size(154, 23);
            this.txtModePaiement.TabIndex = 7;

            // lblNumeroTransaction
            this.lblNumeroTransaction.AutoSize = true;
            this.lblNumeroTransaction.Location = new System.Drawing.Point(12, 135);
            this.lblNumeroTransaction.Name = "lblNumeroTransaction";
            this.lblNumeroTransaction.Size = new System.Drawing.Size(129, 15);
            this.lblNumeroTransaction.TabIndex = 8;
            this.lblNumeroTransaction.Text = "Numéro Transaction:";

            // txtNumeroTransaction
            this.txtNumeroTransaction.Location = new System.Drawing.Point(147, 132);
            this.txtNumeroTransaction.Name = "txtNumeroTransaction";
            this.txtNumeroTransaction.Size = new System.Drawing.Size(137, 23);
            this.txtNumeroTransaction.TabIndex = 9;

            // btnAjouterPaiement
            this.btnAjouterPaiement.Location = new System.Drawing.Point(84, 165);
            this.btnAjouterPaiement.Name = "btnAjouterPaiement";
            this.btnAjouterPaiement.Size = new System.Drawing.Size(100, 30);
            this.btnAjouterPaiement.TabIndex = 10;
            this.btnAjouterPaiement.Text = "Ajouter";
            this.btnAjouterPaiement.Click += new System.EventHandler(this.btnAjouterPaiement_Click);

            // btnSupprimerPaiement
            this.btnSupprimerPaiement.Location = new System.Drawing.Point(190, 165);
            this.btnSupprimerPaiement.Name = "btnSupprimerPaiement";
            this.btnSupprimerPaiement.Size = new System.Drawing.Size(100, 30);
            this.btnSupprimerPaiement.TabIndex = 11;
            this.btnSupprimerPaiement.Text = "Supprimer";
            this.btnSupprimerPaiement.Click += new System.EventHandler(this.btnSupprimerPaiement_Click);

            // dgvPaiements
            this.dgvPaiements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaiements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colPretId,
            this.colNomEmprunteur,
            this.colMontant,
            this.colDate,
            this.colModePaiement,
            this.colNumeroTransaction});
            this.dgvPaiements.Location = new System.Drawing.Point(12, 210);
            this.dgvPaiements.Name = "dgvPaiements";
            this.dgvPaiements.RowTemplate.Height = 25;
            this.dgvPaiements.Size = new System.Drawing.Size(760, 300);
            this.dgvPaiements.TabIndex = 12;

            // colId
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";

            // colPretId
            this.colPretId.HeaderText = "ID Prêt";
            this.colPretId.Name = "colPretId";

            // colNomEmprunteur
            this.colNomEmprunteur.HeaderText = "Emprunteur";
            this.colNomEmprunteur.Name = "colNomEmprunteur";

            // colMontant
            this.colMontant.HeaderText = "Montant";
            this.colMontant.Name = "colMontant";

            // colDate
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";

            // colModePaiement
            this.colModePaiement.HeaderText = "Mode Paiement";
            this.colModePaiement.Name = "colModePaiement";

            // colNumeroTransaction
            this.colNumeroTransaction.HeaderText = "Numéro Transaction";
            this.colNumeroTransaction.Name = "colNumeroTransaction";

            // PaiementForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 520);
            this.Controls.Add(this.dgvPaiements);
            this.Controls.Add(this.btnSupprimerPaiement);
            this.Controls.Add(this.btnAjouterPaiement);
            this.Controls.Add(this.txtNumeroTransaction);
            this.Controls.Add(this.lblNumeroTransaction);
            this.Controls.Add(this.txtModePaiement);
            this.Controls.Add(this.lblModePaiement);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtMontant);
            this.Controls.Add(this.lblMontant);
            this.Controls.Add(this.cmbPrets);
            this.Controls.Add(this.lblPret);
            this.Name = "PaiementForm";
            this.Text = "Gestion des Paiements";
            this.Load += new System.EventHandler(this.PaiementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaiements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblPret;
        private System.Windows.Forms.ComboBox cmbPrets;
        private System.Windows.Forms.Label lblMontant;
        private System.Windows.Forms.TextBox txtMontant;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblModePaiement;
        private System.Windows.Forms.TextBox txtModePaiement;
        private System.Windows.Forms.Label lblNumeroTransaction;
        private System.Windows.Forms.TextBox txtNumeroTransaction;
        private System.Windows.Forms.Button btnAjouterPaiement;
        private System.Windows.Forms.Button btnSupprimerPaiement;
        private System.Windows.Forms.DataGridView dgvPaiements;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPretId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomEmprunteur;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModePaiement;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroTransaction;
    }
}
