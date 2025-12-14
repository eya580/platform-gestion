using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionPrets
{
    /// <summary>
    /// Service layer for database operations - provides high-level methods for data management
    /// </summary>
    public class DatabaseService
    {
        // ========== EMPRUNTEURS ==========
        public List<Emprunteur> GetAllEmprunteurs() => Database.GetAllEmprunteurs();
        public Emprunteur? GetEmprunteurById(int id) => Database.GetEmprunteurById(id);
        public int AddEmprunteur(string numeroIdentite, string nom, string telephone, string adresse, decimal scoreCredit)
            => Database.InsertEmprunteur(numeroIdentite, nom, telephone, adresse, scoreCredit);
        public bool UpdateEmprunteur(int id, string numeroIdentite, string nom, string telephone, string adresse, decimal scoreCredit)
            => Database.UpdateEmprunteur(id, numeroIdentite, nom, telephone, adresse, scoreCredit);
        public bool DeleteEmprunteur(int id) => Database.DeleteEmprunteur(id);

        // ========== PRETS ==========
        public List<Pret> GetAllPrets() => Database.GetAllPrets();
        public Pret? GetPretById(int id) => Database.GetPretById(id);
        public List<Pret> GetPretsByEmprunteur(int emprunteurId) => Database.GetPretsByEmprunteur(emprunteurId);
        public int AddPret(string nomEmprunteur, int emprunteurId, decimal montantPrincipal, decimal tauxInteret, double dureeAnnees, TypeCalcul typeCalcul)
            => Database.InsertPret(nomEmprunteur, emprunteurId, montantPrincipal, tauxInteret, dureeAnnees, typeCalcul);
        public bool UpdatePret(int id, string nomEmprunteur, int emprunteurId, decimal montantPrincipal, decimal tauxInteret, double dureeAnnees, TypeCalcul typeCalcul)
            => Database.UpdatePret(id, nomEmprunteur, emprunteurId, montantPrincipal, tauxInteret, dureeAnnees, typeCalcul);
        public bool DeletePret(int id) => Database.DeletePret(id);

        // ========== PAIEMENTS ==========
        public List<Paiement> GetAllPaiements() => Database.GetAllPaiements();
        public Paiement? GetPaiementById(int id) => Database.GetPaiementById(id);
        public List<Paiement> GetPaiementsByPret(int pretId) => Database.GetPaiementsByPret(pretId);
        public int AddPaiement(int pretId, decimal montant, DateTime date, string modePaiement, string numeroTransaction)
            => Database.InsertPaiement(pretId, montant, date, modePaiement, numeroTransaction);
        public bool UpdatePaiement(int id, int pretId, decimal montant, DateTime date, string modePaiement, string numeroTransaction)
            => Database.UpdatePaiement(id, pretId, montant, date, modePaiement, numeroTransaction);
        public bool DeletePaiement(int id) => Database.DeletePaiement(id);

        // ========== UTILITIES ==========
        /// <summary>
        /// Get all prets with borrower details
        /// </summary>
        public List<(Pret pret, Emprunteur? emprunteur)> GetPrestsWithBorrowers()
        {
            var prets = GetAllPrets();
            return prets.Select(p => (p, GetEmprunteurById(p.EmprunteurId))).ToList();
        }

        /// <summary>
        /// Get payment status for a specific pret
        /// </summary>
        public decimal GetTotalPaymentForPret(int pretId)
        {
            var paiements = GetPaiementsByPret(pretId);
            return paiements.Sum(p => p.Montant);
        }

        /// <summary>
        /// Get remaining amount for a specific pret
        /// </summary>
        public decimal GetRemainingAmountForPret(int pretId)
        {
            var pret = GetPretById(pretId);
            if (pret == null) return 0;
            var paid = GetTotalPaymentForPret(pretId);
            return pret.MontantTotalAPayer - paid;
        }
    }
}
