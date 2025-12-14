using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.IO;
using System;

namespace GestionPrets
{
    public class Database
    {
        private static readonly string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GestionPrets.db");

        public static SqliteConnection GetConnection()
        {
            string connectionString = $"Data Source={DbPath}";
            return new SqliteConnection(connectionString);
        }

        public static void InitializeDatabase()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    // Create Emprunteurs table
                    command.CommandText = @"CREATE TABLE IF NOT EXISTS Emprunteurs (Id INTEGER PRIMARY KEY AUTOINCREMENT, NumeroIdentite TEXT UNIQUE NOT NULL, Nom TEXT NOT NULL, Telephone TEXT NOT NULL, Adresse TEXT NOT NULL, ScoreCredit REAL NOT NULL, DateCreation DATETIME DEFAULT CURRENT_TIMESTAMP)";
                    command.ExecuteNonQuery();

                    // Create Prets table
                    command.CommandText = @"CREATE TABLE IF NOT EXISTS Prets (Id INTEGER PRIMARY KEY AUTOINCREMENT, NomEmprunteur TEXT NOT NULL, EmprunteurId INTEGER NOT NULL, MontantPrincipal REAL NOT NULL, TauxInteret REAL NOT NULL, DureeAnnees REAL NOT NULL, TypeCalcul TEXT NOT NULL, Statut TEXT NOT NULL, DateCreation DATETIME DEFAULT CURRENT_TIMESTAMP, MontantTotalAPayer REAL NOT NULL, FOREIGN KEY(EmprunteurId) REFERENCES Emprunteurs(Id) ON DELETE CASCADE)";
                    command.ExecuteNonQuery();

                    // Create Paiements table
                    command.CommandText = @"CREATE TABLE IF NOT EXISTS Paiements (Id INTEGER PRIMARY KEY AUTOINCREMENT, PretId INTEGER NOT NULL, Montant REAL NOT NULL, Date DATETIME NOT NULL, ModePaiement TEXT NOT NULL, NumeroTransaction TEXT NOT NULL, FOREIGN KEY(PretId) REFERENCES Prets(Id) ON DELETE CASCADE)";
                    command.ExecuteNonQuery();
                }

                // Verify schema and repair missing columns when possible
                VerifySchema(connection);
            }
        }

        private static void VerifySchema(SqliteConnection connection)
        {
            try
            {
                using (var command = connection.CreateCommand())
                {
                    // Helper to check and add columns
                    void EnsureColumn(string table, string column, string columnDef)
                    {
                        command.CommandText = $"PRAGMA table_info('{table}')";
                        var existing = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                                existing.Add(reader.GetString(1));
                        }

                        if (!existing.Contains(column))
                        {
                            try
                            {
                                command.CommandText = $"ALTER TABLE {table} ADD COLUMN {column} {columnDef}";
                                command.ExecuteNonQuery();
                                Console.WriteLine($"Schema updated: Added column {column} to {table}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Failed to add column {column} to {table}: {ex.Message}");
                            }
                        }
                    }

                    // Emprunteurs expected columns
                    EnsureColumn("Emprunteurs", "Id", "INTEGER PRIMARY KEY AUTOINCREMENT");
                    EnsureColumn("Emprunteurs", "NumeroIdentite", "TEXT UNIQUE NOT NULL");
                    EnsureColumn("Emprunteurs", "Nom", "TEXT NOT NULL");
                    EnsureColumn("Emprunteurs", "Telephone", "TEXT NOT NULL");
                    EnsureColumn("Emprunteurs", "Adresse", "TEXT NOT NULL");
                    EnsureColumn("Emprunteurs", "ScoreCredit", "REAL NOT NULL DEFAULT 0");
                    EnsureColumn("Emprunteurs", "DateCreation", "DATETIME DEFAULT CURRENT_TIMESTAMP");

                    // Prets expected columns
                    EnsureColumn("Prets", "Id", "INTEGER PRIMARY KEY AUTOINCREMENT");
                    EnsureColumn("Prets", "NomEmprunteur", "TEXT NOT NULL");
                    EnsureColumn("Prets", "EmprunteurId", "INTEGER NOT NULL");
                    EnsureColumn("Prets", "MontantPrincipal", "REAL NOT NULL DEFAULT 0");
                    EnsureColumn("Prets", "TauxInteret", "REAL NOT NULL DEFAULT 0");
                    EnsureColumn("Prets", "DureeAnnees", "REAL NOT NULL DEFAULT 0");
                    EnsureColumn("Prets", "TypeCalcul", "TEXT NOT NULL DEFAULT 'Simple'");
                    EnsureColumn("Prets", "Statut", "TEXT NOT NULL DEFAULT 'Actif'");
                    EnsureColumn("Prets", "DateCreation", "DATETIME DEFAULT CURRENT_TIMESTAMP");
                    EnsureColumn("Prets", "MontantTotalAPayer", "REAL NOT NULL DEFAULT 0");

                    // Paiements expected columns
                    EnsureColumn("Paiements", "Id", "INTEGER PRIMARY KEY AUTOINCREMENT");
                    EnsureColumn("Paiements", "PretId", "INTEGER NOT NULL");
                    EnsureColumn("Paiements", "Montant", "REAL NOT NULL DEFAULT 0");
                    EnsureColumn("Paiements", "Date", "DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP");
                    EnsureColumn("Paiements", "ModePaiement", "TEXT NOT NULL DEFAULT ''");
                    EnsureColumn("Paiements", "NumeroTransaction", "TEXT NOT NULL DEFAULT ''");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error verifying schema: " + ex.Message);
            }
        }

        public static List<Emprunteur> GetAllEmprunteurs()
        {
            var emprunteurs = new List<Emprunteur>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Id, NumeroIdentite, Nom, Telephone, Adresse, ScoreCredit FROM Emprunteurs";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            emprunteurs.Add(new Emprunteur(reader.GetInt32(0), reader.GetString(2), "email@example.com", "password", reader.GetString(1), reader.GetString(3), reader.GetString(4), (decimal)reader.GetDouble(5)));
                        }
                    }
                }
            }
            return emprunteurs;
        }

        public static Emprunteur? GetEmprunteurById(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Id, NumeroIdentite, Nom, Telephone, Adresse, ScoreCredit FROM Emprunteurs WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            return new Emprunteur(reader.GetInt32(0), reader.GetString(2), "email@example.com", "password", reader.GetString(1), reader.GetString(3), reader.GetString(4), (decimal)reader.GetDouble(5));
                    }
                }
            }
            return null;
        }

        public static int InsertEmprunteur(string numeroIdentite, string nom, string telephone, string adresse, decimal scoreCredit)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Emprunteurs (NumeroIdentite, Nom, Telephone, Adresse, ScoreCredit) VALUES (@numeroIdentite, @nom, @telephone, @adresse, @scoreCredit); SELECT last_insert_rowid();";
                    command.Parameters.AddWithValue("@numeroIdentite", numeroIdentite);
                    command.Parameters.AddWithValue("@nom", nom);
                    command.Parameters.AddWithValue("@telephone", telephone);
                    command.Parameters.AddWithValue("@adresse", adresse);
                    command.Parameters.AddWithValue("@scoreCredit", scoreCredit);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public static bool UpdateEmprunteur(int id, string numeroIdentite, string nom, string telephone, string adresse, decimal scoreCredit)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE Emprunteurs SET NumeroIdentite = @numeroIdentite, Nom = @nom, Telephone = @telephone, Adresse = @adresse, ScoreCredit = @scoreCredit WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@numeroIdentite", numeroIdentite);
                    command.Parameters.AddWithValue("@nom", nom);
                    command.Parameters.AddWithValue("@telephone", telephone);
                    command.Parameters.AddWithValue("@adresse", adresse);
                    command.Parameters.AddWithValue("@scoreCredit", scoreCredit);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool DeleteEmprunteur(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Emprunteurs WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Pret> GetAllPrets()
        {
            var prets = new List<Pret>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT Id, NomEmprunteur, EmprunteurId, MontantPrincipal, TauxInteret, DureeAnnees, TypeCalcul, Statut, MontantTotalAPayer FROM Prets";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var typeCalcul = Enum.Parse<TypeCalcul>(reader.GetString(6));
                            prets.Add(new Pret(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), (decimal)reader.GetDouble(3), (decimal)reader.GetDouble(4), reader.GetDouble(5), typeCalcul));
                        }
                    }
                }
            }
            return prets;
        }

        public static Pret? GetPretById(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT Id, NomEmprunteur, EmprunteurId, MontantPrincipal, TauxInteret, DureeAnnees, TypeCalcul, Statut, MontantTotalAPayer FROM Prets WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var typeCalcul = Enum.Parse<TypeCalcul>(reader.GetString(6));
                            return new Pret(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), (decimal)reader.GetDouble(3), (decimal)reader.GetDouble(4), reader.GetDouble(5), typeCalcul);
                        }
                    }
                }
            }
            return null;
        }

        public static int InsertPret(string nomEmprunteur, int emprunteurId, decimal montantPrincipal, decimal tauxInteret, double dureeAnnees, TypeCalcul typeCalcul)
        {
            var pret = new Pret(nomEmprunteur, emprunteurId, montantPrincipal, tauxInteret, dureeAnnees, typeCalcul);
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Prets (NomEmprunteur, EmprunteurId, MontantPrincipal, TauxInteret, DureeAnnees, TypeCalcul, Statut, MontantTotalAPayer) VALUES (@nomEmprunteur, @emprunteurId, @montantPrincipal, @tauxInteret, @dureeAnnees, @typeCalcul, @statut, @montantTotalAPayer); SELECT last_insert_rowid();";
                    command.Parameters.AddWithValue("@nomEmprunteur", nomEmprunteur);
                    command.Parameters.AddWithValue("@emprunteurId", emprunteurId);
                    command.Parameters.AddWithValue("@montantPrincipal", montantPrincipal);
                    command.Parameters.AddWithValue("@tauxInteret", tauxInteret);
                    command.Parameters.AddWithValue("@dureeAnnees", dureeAnnees);
                    command.Parameters.AddWithValue("@typeCalcul", typeCalcul.ToString());
                    command.Parameters.AddWithValue("@statut", StatutPret.Actif.ToString());
                    command.Parameters.AddWithValue("@montantTotalAPayer", pret.MontantTotalAPayer);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public static bool UpdatePret(int id, string nomEmprunteur, int emprunteurId, decimal montantPrincipal, decimal tauxInteret, double dureeAnnees, TypeCalcul typeCalcul)
        {
            var pret = new Pret(nomEmprunteur, emprunteurId, montantPrincipal, tauxInteret, dureeAnnees, typeCalcul);
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE Prets SET NomEmprunteur = @nomEmprunteur, EmprunteurId = @emprunteurId, MontantPrincipal = @montantPrincipal, TauxInteret = @tauxInteret, DureeAnnees = @dureeAnnees, TypeCalcul = @typeCalcul, MontantTotalAPayer = @montantTotalAPayer WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nomEmprunteur", nomEmprunteur);
                    command.Parameters.AddWithValue("@emprunteurId", emprunteurId);
                    command.Parameters.AddWithValue("@montantPrincipal", montantPrincipal);
                    command.Parameters.AddWithValue("@tauxInteret", tauxInteret);
                    command.Parameters.AddWithValue("@dureeAnnees", dureeAnnees);
                    command.Parameters.AddWithValue("@typeCalcul", typeCalcul.ToString());
                    command.Parameters.AddWithValue("@montantTotalAPayer", pret.MontantTotalAPayer);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool DeletePret(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Prets WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Pret> GetPretsByEmprunteur(int emprunteurId)
        {
            var prets = new List<Pret>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT Id, NomEmprunteur, EmprunteurId, MontantPrincipal, TauxInteret, DureeAnnees, TypeCalcul, Statut, MontantTotalAPayer FROM Prets WHERE EmprunteurId = @emprunteurId";
                    command.Parameters.AddWithValue("@emprunteurId", emprunteurId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var typeCalcul = Enum.Parse<TypeCalcul>(reader.GetString(6));
                            prets.Add(new Pret(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), (decimal)reader.GetDouble(3), (decimal)reader.GetDouble(4), reader.GetDouble(5), typeCalcul));
                        }
                    }
                }
            }
            return prets;
        }

        public static List<Paiement> GetAllPaiements()
        {
            var paiements = new List<Paiement>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT Id, PretId, Montant, Date, ModePaiement, NumeroTransaction FROM Paiements";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            paiements.Add(new Paiement(reader.GetInt32(0), reader.GetInt32(1), (decimal)reader.GetDouble(2), reader.GetDateTime(3), reader.GetString(4), reader.GetString(5)));
                        }
                    }
                }
            }
            return paiements;
        }

        public static Paiement? GetPaiementById(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT Id, PretId, Montant, Date, ModePaiement, NumeroTransaction FROM Paiements WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            return new Paiement(reader.GetInt32(0), reader.GetInt32(1), (decimal)reader.GetDouble(2), reader.GetDateTime(3), reader.GetString(4), reader.GetString(5));
                    }
                }
            }
            return null;
        }

        public static int InsertPaiement(int pretId, decimal montant, DateTime date, string modePaiement, string numeroTransaction)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Paiements (PretId, Montant, Date, ModePaiement, NumeroTransaction) VALUES (@pretId, @montant, @date, @modePaiement, @numeroTransaction); SELECT last_insert_rowid();";
                    command.Parameters.AddWithValue("@pretId", pretId);
                    command.Parameters.AddWithValue("@montant", montant);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@modePaiement", modePaiement);
                    command.Parameters.AddWithValue("@numeroTransaction", numeroTransaction);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public static bool UpdatePaiement(int id, int pretId, decimal montant, DateTime date, string modePaiement, string numeroTransaction)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE Paiements SET PretId = @pretId, Montant = @montant, Date = @date, ModePaiement = @modePaiement, NumeroTransaction = @numeroTransaction WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@pretId", pretId);
                    command.Parameters.AddWithValue("@montant", montant);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@modePaiement", modePaiement);
                    command.Parameters.AddWithValue("@numeroTransaction", numeroTransaction);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool DeletePaiement(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Paiements WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Paiement> GetPaiementsByPret(int pretId)
        {
            var paiements = new List<Paiement>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT Id, PretId, Montant, Date, ModePaiement, NumeroTransaction FROM Paiements WHERE PretId = @pretId";
                    command.Parameters.AddWithValue("@pretId", pretId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            paiements.Add(new Paiement(reader.GetInt32(0), reader.GetInt32(1), (decimal)reader.GetDouble(2), reader.GetDateTime(3), reader.GetString(4), reader.GetString(5)));
                        }
                    }
                }
            }
            return paiements;
        }
    }
}
