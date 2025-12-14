namespace GestionPrets
{
    partial class MenuForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnEmprunteurs = new System.Windows.Forms.Button();
            this.btnPrets = new System.Windows.Forms.Button();
            this.btnPaiements = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(50, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Gestion des Prêts";

            // btnEmprunteurs
            this.btnEmprunteurs.Location = new System.Drawing.Point(50, 80);
            this.btnEmprunteurs.Name = "btnEmprunteurs";
            this.btnEmprunteurs.Size = new System.Drawing.Size(200, 50);
            this.btnEmprunteurs.TabIndex = 1;
            this.btnEmprunteurs.Text = "Emprunteurs";
            this.btnEmprunteurs.UseVisualStyleBackColor = true;
            this.btnEmprunteurs.Click += new System.EventHandler(this.btnEmprunteurs_Click);

            // btnPrets
            this.btnPrets.Location = new System.Drawing.Point(50, 140);
            this.btnPrets.Name = "btnPrets";
            this.btnPrets.Size = new System.Drawing.Size(200, 50);
            this.btnPrets.TabIndex = 2;
            this.btnPrets.Text = "Prêts";
            this.btnPrets.UseVisualStyleBackColor = true;
            this.btnPrets.Click += new System.EventHandler(this.btnPrets_Click);

            // btnPaiements
            this.btnPaiements.Location = new System.Drawing.Point(50, 200);
            this.btnPaiements.Name = "btnPaiements";
            this.btnPaiements.Size = new System.Drawing.Size(200, 50);
            this.btnPaiements.TabIndex = 3;
            this.btnPaiements.Text = "Paiements";
            this.btnPaiements.UseVisualStyleBackColor = true;
            this.btnPaiements.Click += new System.EventHandler(this.btnPaiements_Click);

            // btnQuitter
            this.btnQuitter.BackColor = System.Drawing.Color.LightCoral;
            this.btnQuitter.Location = new System.Drawing.Point(50, 260);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(200, 50);
            this.btnQuitter.TabIndex = 4;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);

            // MenuForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 330);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnPaiements);
            this.Controls.Add(this.btnPrets);
            this.Controls.Add(this.btnEmprunteurs);
            this.Controls.Add(this.lblTitle);
            this.Name = "MenuForm";
            this.Text = "Menu Principal";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnEmprunteurs;
        private System.Windows.Forms.Button btnPrets;
        private System.Windows.Forms.Button btnPaiements;
        private System.Windows.Forms.Button btnQuitter;
    }
}
