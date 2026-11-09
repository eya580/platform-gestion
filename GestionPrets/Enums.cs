using System;

namespace GestionPrets
{
    public enum TypeCalcul
    {
        Simple,
        Compose,
        Amortissement
    }

    public enum StatutPret
    {
        Actif,
        Solde,
        EnRetard,
        Suspendu
    }

    public enum SeveriteAlerte
    {
        Faible,
        Moyenne,
        Elevee,
        Critique
    }
}
