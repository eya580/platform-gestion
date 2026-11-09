
CREATE DATABASE DataPretsDB;
GO
USE DataPretsDB;

CREATE TABLE dbo.Loans (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NomEmprunteur NVARCHAR(100) NOT NULL,
    MontantPrincipal DECIMAL(18,2) NOT NULL,
    TauxInteret DECIMAL(5,2) NOT NULL,
    DureeAnnees INT NOT NULL,
    TypeCalcul NVARCHAR(50) NULL,
    Statut NVARCHAR(50) DEFAULT 'En cours',
    MontantTotal AS 
        ROUND(MontantPrincipal + (MontantPrincipal * TauxInteret / 100.0 * DureeAnnees), 2)
);

INSERT INTO dbo.Loans
(NomEmprunteur, MontantPrincipal, TauxInteret, DureeAnnees, TypeCalcul, Statut)
VALUES
('aaa', 252.00, 2.00, 20, 'Simple', 'En cours');

