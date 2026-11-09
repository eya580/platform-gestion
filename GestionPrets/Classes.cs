using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionPrets
{
    // Classe abstraite Utilisateur (inchangée)
    public abstract class Utilisateur
    {
        protected int Id { get; set; }
        protected string Nom { get; set; }
        protected string Email { get; set; }
        protected string MotDePasse { get; set; }
        protected DateTime DateCreation { get; set; }

        public Utilisateur(int id, string nom, string email, string motDePasse)
        {
            Id = id;
            Nom = nom;
            Email = email;
            MotDePasse = motDePasse;
            DateCreation = DateTime.Now;
        }

        public virtual bool SeConnecter(string email, string motDePasse)
        {
            return this.Email == email && this.MotDePasse == motDePasse;
        }

        public virtual void SeDeconnecter()
        {
            // Logique de déconnexion (ex. : nettoyer la session)
        }

        public virtual void ModifierProfil(string nouveauNom, string nouvelEmail)
        {
            Nom = nouveauNom;
            Email = nouvelEmail;
        }
    }

    // Classe GestionnairePrets (mis à jour avec alertes et pénalités)
    public class GestionnairePrets : Utilisateur
    {
        private string Matricule { get; set; }
        private string Service { get; set; }
        private List<Pret> pretsGeres { get; set; }

        public GestionnairePrets(int id, string nom, string email, string motDePasse, string matricule, string service)
            : base(id, nom, email, motDePasse)
        {
            Matricule = matricule;
            Service = service;
            pretsGeres = new List<Pret>();
        }

        public void CreerPret(Pret pret)
        {
            pretsGeres.Add(pret);
        }

        public void ModifierPret(int pretId, Pret nouveauPret)
        {
            var pret = pretsGeres.FirstOrDefault(p => p.Id == pretId);
            if (pret != null)
            {
                // Copier les propriétés
                pret.MontantPrincipal = nouveauPret.MontantPrincipal;
                pret.TauxInteret = nouveauPret.TauxInteret;
                pret.DureeAnnees = nouveauPret.DureeAnnees;
                pret.TypeCalcul = nouveauPret.TypeCalcul;
            }
        }

        public void EnregistrerPaiement(Paiement paiement, SystemeGestionPrets systeme)
        {
            systeme.EnregistrerPaiement(paiement);
            // Mettre à jour le statut du prêt
            var pret = systeme.prets.FirstOrDefault(p => p.Id == paiement.PretId);
            if (pret != null)
            {
                // use the overload that accepts payments list
                pret.MettreAJourStatut(pret.EstEnRetard(systeme.paiements) ? StatutPret.EnRetard : StatutPret.Actif);
            }
        }

        public void ConsulterAlertes(SystemeGestionPrets systeme)
        {
            systeme.VerifierAlertes();
        }

        public void GererPenalites(int pretId, SystemeGestionPrets systeme)
        {
            var pret = systeme.prets.FirstOrDefault(p => p.Id == pretId);
            if (pret != null && pret.EstEnRetard(systeme.paiements))
            {
                // Appliquer pénalité (ex. : augmenter le taux)
                pret.TauxInteret += 0.01m; // Pénalité de 1%
            }
        }
    }

    // Classe Emprunteur (mis à jour avec historique et alertes)
    public class Emprunteur : Utilisateur
    {
        private string NumeroIdentite { get; set; }
        private string Telephone { get; set; }
        private string Adresse { get; set; }
        private decimal ScoreCredit { get; set; }
        private List<Pret> mesPrets { get; set; }

        public Emprunteur(int id, string nom, string email, string motDePasse, string numeroIdentite, string telephone, string adresse, decimal scoreCredit)
            : base(id, nom, email, motDePasse)
        {
            NumeroIdentite = numeroIdentite;
            Telephone = telephone;
            Adresse = adresse;
            ScoreCredit = scoreCredit;
            mesPrets = new List<Pret>();
        }

        public List<Pret> ConsulterMesPrets()
        {
            return mesPrets;
        }

        public List<Paiement> ConsulterHistorique(SystemeGestionPrets systeme)
        {
            return systeme.paiements.Where(p => mesPrets.Any(pret => pret.Id == p.PretId)).ToList();
        }

        public void AnalyserRisque()
        {
            // Logique basée sur ScoreCredit et retards
            if (ScoreCredit < 600)
            {
                // Risque élevé
            }
        }

        public List<Alerte> ConsulterMesAlertes(SystemeGestionPrets systeme)
        {
            return systeme.alertes.Where(a => mesPrets.Any(pret => pret.Id == a.PretId)).ToList();
        }
    }

    // Classe Administrateur (inchangée)
    public class Administrateur : Utilisateur
    {
        private string NiveauAcces { get; set; }
        private List<string> Permissions { get; set; }

        public Administrateur(int id, string nom, string email, string motDePasse, string niveauAcces, List<string> permissions)
            : base(id, nom, email, motDePasse)
        {
            NiveauAcces = niveauAcces;
            Permissions = permissions;
        }

        public void GererUtilisateurs()
        {
            // Logique pour gérer les utilisateurs
        }

        public void ConfigurerSysteme()
        {
            // Logique pour configurer le système
        }

        public StatistiquesPrets ConsulterStatistiques(SystemeGestionPrets systeme)
        {
            return systeme.ObtenirStatistiques();
        }

        public void ExporterDonnees(SystemeGestionPrets systeme)
        {
            // Logique pour exporter les données (ex. : CSV)
        }
    }

    // Classe Pret (mis à jour avec calculs complets et suivi)
    public class Pret
    {
        public int Id { get; set; }
        public string NomEmprunteur { get; set; }
        public int EmprunteurId { get; set; }
        public decimal MontantPrincipal { get; set; }
        public decimal TauxInteret { get; set; }
        public double DureeAnnees { get; set; }
        public TypeCalcul TypeCalcul { get; set; }
        public StatutPret Statut { get; set; }
        public DateTime DateCreation { get; set; }
        public List<DateTime> Echeances { get; set; } // Liste des dates d'échéance mensuelles
        public decimal MontantTotalAPayer { get; set; } // Calculé lors de la création

        public Pret(int id, string nomEmprunteur, int emprunteurId, decimal montantPrincipal, decimal tauxInteret, double dureeAnnees, TypeCalcul typeCalcul)
        {
            Id = id;
            NomEmprunteur = nomEmprunteur;
            EmprunteurId = emprunteurId;
            MontantPrincipal = montantPrincipal;
            TauxInteret = tauxInteret;
            DureeAnnees = dureeAnnees;
            TypeCalcul = typeCalcul;
            Statut = StatutPret.Actif;
            DateCreation = DateTime.Now;
            Echeances = GenererEcheances();
            MontantTotalAPayer = CalculerMontantTotal();
        }

        private List<DateTime> GenererEcheances()
        {
            var echeances = new List<DateTime>();
            for (int i = 1; i <= (int)(DureeAnnees * 12); i++)
            {
                echeances.Add(DateCreation.AddMonths(i));
            }
            return echeances;
        }

        public decimal CalculerMontantTotal()
        {
            if (TypeCalcul == TypeCalcul.Simple)
            {
                return MontantPrincipal + (MontantPrincipal * TauxInteret * (decimal)DureeAnnees);
            }
            else if (TypeCalcul == TypeCalcul.Compose)
            {
                return MontantPrincipal * (decimal)Math.Pow((double)(1 + TauxInteret), DureeAnnees);
            }
            else // Amortissement
            {
                decimal mensualite = CalculerMensualite();
                return mensualite * (decimal)(DureeAnnees * 12);
            }
        }

        public decimal CalculerMensualite()
        {
            if (TypeCalcul == TypeCalcul.Amortissement)
            {
                decimal i = TauxInteret / 12; // Taux mensuel
                int n = (int)(DureeAnnees * 12); // Nombre de mensualités
                return (MontantPrincipal * i) / (1 - (decimal)Math.Pow((double)(1 + i), -n));
            }
            return 0;
        }

        public decimal PourcentagePaye(List<Paiement> paiements)
        {
            decimal totalPaye = paiements.Where(p => p.PretId == Id).Sum(p => p.Montant);
            return (totalPaye / MontantTotalAPayer) * 100;
        }

        // Overload: version that takes the system payments
        public bool EstEnRetard(List<Paiement> paiements)
        {
            var derniereEcheance = Echeances.LastOrDefault(e => e < DateTime.Now);
            if (derniereEcheance != default)
            {
                var paiementsPourEcheance = paiements.Where(p => p.PretId == Id && p.Date <= derniereEcheance.AddDays(30)).Sum(p => p.Montant);
                return paiementsPourEcheance < CalculerMensualite(); // Simplifié
            }
            return false;
        }

        // Parameterless overload used by some callers; defaults to not-retard (requires system payments for accurate check)
        public bool EstEnRetard()
        {
            // Cannot determine without payments list; return false to avoid false positives.
            return false;
        }

        public void MettreAJourStatut(StatutPret nouveauStatut)
        {
            Statut = nouveauStatut;
        }

        public DateTime ProchaineEcheance()
        {
            return Echeances.FirstOrDefault(e => e > DateTime.Now);
        }

        public decimal ResteAPayer(List<Paiement> paiements)
        {
            decimal totalPaye = paiements.Where(p => p.PretId == Id).Sum(p => p.Montant);
            return MontantTotalAPayer - totalPaye;
        }
    }

    // Classe Paiement (mis à jour avec validation)
    public class Paiement
    {
        public int Id { get; set; }
        public int PretId { get; set; }
        public decimal Montant { get; set; }
        public DateTime Date { get; set; }
        public string ModePaiement { get; set; }
        public string NumeroTransaction { get; set; }

        public Paiement(int id, int pretId, decimal montant, DateTime date, string modePaiement, string numeroTransaction)
        {
            Id = id;
            PretId = pretId;
            Montant = montant;
            Date = date;
            ModePaiement = modePaiement;
            NumeroTransaction = numeroTransaction;
        }

        public void Valider()
        {
            // Logique de validation (ex. : vérifier le solde)
        }

        public void Annuler()
        {
            // Logique d'annulation
        }

        public string GenererRecu()
        {
            return $"Reçu pour paiement ID {Id}, Montant: {Montant}, Date: {Date}";
        }
    }

    // Classe Alerte (mis à jour avec envoi simulé)
    public class Alerte
    {
        public int Id { get; set; }
        public int PretId { get; set; }
        public string Message { get; set; }
        public SeveriteAlerte Severite { get; set; }
        public DateTime DateCreation { get; set; }
        public string Type { get; set; }

        public Alerte(int id, int pretId, string message, SeveriteAlerte severite, string type)
        {
            Id = id;
            PretId = pretId;
            Message = message;
            Severite = severite;
            DateCreation = DateTime.Now;
            Type = type;
        }

        public void MarquerCommeLue()
        {
            // Logique pour marquer comme lue
        }

        public void Envoyer()
        {
            // Simulation d'envoi : email, SMS, ou interface
            Console.WriteLine($"Alerte envoyée : {Message} (Sévérité: {Severite})");
        }
    }

    // Classe SystemeGestionPrets (mis à jour avec alertes et calculs)
    public class SystemeGestionPrets
    {
        public List<Pret> prets { get; set; }
        public List<Paiement> paiements { get; set; }
        public List<Alerte> alertes { get; set; }
        public List<Utilisateur> utilisateurs { get; set; }

        public SystemeGestionPrets()
        {
            prets = new List<Pret>();
            paiements = new List<Paiement>();
            alertes = new List<Alerte>();
            utilisateurs = new List<Utilisateur>();
        }

        public decimal CalculerInteretSimple(decimal principal, decimal taux, double annees)
        {
            return principal * taux * (decimal)annees;
        }

        public decimal CalculerInteretCompose(decimal principal, decimal taux, double annees)
        {
            return principal * (decimal)Math.Pow((double)(1 + taux), annees) - principal;
        }

        public decimal CalculerAmortissement(decimal principal, decimal taux, double annees)
        {
            decimal mensualite = (principal * (taux / 12)) / (1 - (decimal)Math.Pow((double)(1 + taux / 12), -(annees * 12)));
            return mensualite * (decimal)(annees * 12);
        }

        public Pret AjouterPret(Pret pret)
        {
            prets.Add(pret);
            return pret;
        }

        public Paiement EnregistrerPaiement(Paiement paiement)
        {
            paiements.Add(paiement);
            return paiement;
        }

        public void VerifierAlertes()
        {
            foreach (var pret in prets)
            {
                var prochaineEcheance = pret.ProchaineEcheance();
                if (prochaineEcheance != default && (prochaineEcheance - DateTime.Now).Days <= 7)
                {
                    alertes.Add(new Alerte(alertes.Count + 1, pret.Id, "Échéance à venir", SeveriteAlerte.Faible, "Échéance"));
                }
                if (pret.EstEnRetard(paiements))
                {
                    alertes.Add(new Alerte(alertes.Count + 1, pret.Id, "Retard de paiement détecté", SeveriteAlerte.Elevee, "Retard"));
                }
            }
        }

        public StatistiquesPrets ObtenirStatistiques()
        {
            return new StatistiquesPrets
            {
                NombreTotalPrets = prets.Count,
                NombrePretsActifs = prets.Count(p => p.Statut == StatutPret.Actif),
                MontantTotalPrete = prets.Sum(p => p.MontantPrincipal),
                MontantTotalCollecte = paiements.Sum(p => p.Montant),
                InteretsTotaux = prets.Sum(p => p.CalculerMontantTotal() - p.MontantPrincipal)
            };
        }
    }

    // Classe StatistiquesPrets (inchangée)
    public class StatistiquesPrets
    {
        public int NombreTotalPrets { get; set; }
        public int NombrePretsActifs { get; set; }
        public decimal MontantTotalPrete { get; set; }
        public decimal MontantTotalCollecte { get; set; }
        public decimal InteretsTotaux { get; set; }
    }
}
