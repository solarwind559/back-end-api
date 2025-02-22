using Api1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

public static class DatabaseSeeder
{
    public static void SeedDatabase(ApplicationDbContext context)
    {
        // Ensure the database is created
        // context.Database.EnsureCreated();

        if (!context.Majas.Any())
        {
            context.Majas.AddRange(
                new Maja
                {
                    Id = 1,
                    Numurs = 1,
                    Iela = "Pirmā iela",
                    Pilseta = "Rīga",
                    Valsts = "Latvija",
                    Pasta_Indekss = "LV-1001",
                    Majas_Dzivokli = new List<Majas_Dzivoklis>
                    {
                        new Majas_Dzivoklis { Dzivoklis_Id = 1 },
                        new Majas_Dzivoklis { Dzivoklis_Id = 2 }
                    },
                },
                new Maja
                {
                    Id = 2,
                    Numurs = 2,
                    Iela = "Otrā iela",
                    Pilseta = "Rīga",
                    Valsts = "Latvija",
                    Pasta_Indekss = "LV-1002",
                    Majas_Dzivokli = new List<Majas_Dzivoklis>
                    {
                        new Majas_Dzivoklis { Dzivoklis_Id = 3 },
                        new Majas_Dzivoklis { Dzivoklis_Id = 4 },
                        new Majas_Dzivoklis { Dzivoklis_Id = 5 }
                    },
                }
            );
        }

        if (!context.Dzivokli.Any())
        {
            context.Dzivokli.AddRange(
                new Dzivoklis
                {
                    Id = 1,
                    Numurs = 1,
                    Stavs = 1,
                    Istabu_Skaits = 2,
                    Iedzivotaju_Skaits = 3,
                    Pilna_Platiba = 50,
                    Dzivojama_Platiba = 45,
                    Maja_Id = 1
                },
                new Dzivoklis
                {
                    Id = 2,
                    Numurs = 2,
                    Stavs = 2,
                    Istabu_Skaits = 3,
                    Iedzivotaju_Skaits = 4,
                    Pilna_Platiba = 70,
                    Dzivojama_Platiba = 65,
                    Maja_Id = 1
                },
                new Dzivoklis
                {
                    Id = 3,
                    Numurs = 3,
                    Stavs = 3,
                    Istabu_Skaits = 4,
                    Iedzivotaju_Skaits = 5,
                    Pilna_Platiba = 90,
                    Dzivojama_Platiba = 85,
                    Maja_Id = 2
                },
                new Dzivoklis
                {
                    Id = 4,
                    Numurs = 4,
                    Stavs = 4,
                    Istabu_Skaits = 2,
                    Iedzivotaju_Skaits = 2,
                    Pilna_Platiba = 60,
                    Dzivojama_Platiba = 55,
                    Maja_Id = 2
                },
                new Dzivoklis
                {
                    Id = 5,
                    Numurs = 5,
                    Stavs = 5,
                    Istabu_Skaits = 3,
                    Iedzivotaju_Skaits = 3,
                    Pilna_Platiba = 80,
                    Dzivojama_Platiba = 75,
                    Maja_Id = 2
                }
            );
        }

        if (!context.Iedzivotaji.Any())
        {
            context.Iedzivotaji.AddRange(
                new Iedzivotajs
                {
                    Id = 1,
                    Vards = "Jānis",
                    Uzvards = "Bērziņš",
                    Personas_Kods = 12345678901,
                    Dzimsanas_Datums = new DateOnly(1980, 1, 1),
                    Telefons = 123456789,
                    E_Mail = "janis.berzins@epasts.com",
                    Saikne_Ar_Dzivokli = "Īrnieks",
                    Is_Owner = false,
                    Iedzivotaja_Dzivokli = new List<Iedzivotaja_Dzivoklis>
                    {
                        Iedzivotajs.CreateResidentLink(3, false),
                    },
                },
                new Iedzivotajs
                {
                    Id = 2,
                    Vards = "Līga",
                    Uzvards = "Kalniņa",
                    Personas_Kods = 12345678902,
                    Dzimsanas_Datums = new DateOnly(1985, 2, 2),
                    Telefons = 876543210,
                    E_Mail = "liga.kalnina@epasts.com",
                    Saikne_Ar_Dzivokli = "Īrnieks",
                    Is_Owner = false,
                    Iedzivotaja_Dzivokli = new List<Iedzivotaja_Dzivoklis>
                    {
                        Iedzivotajs.CreateResidentLink(4, false),
                    },
                },
                new Iedzivotajs
                {
                    Id = 3,
                    Vards = "Uģis",
                    Uzvards = "Krūmiņš",
                    Personas_Kods = 12345678903,
                    Dzimsanas_Datums = new DateOnly(1990, 3, 3),
                    Telefons = 123456790,
                    E_Mail = "ugis.krumins@epasts.com",
                    Saikne_Ar_Dzivokli = "Īpašnieks",
                    Is_Owner = true,
                    Iedzivotaja_Dzivokli = new List<Iedzivotaja_Dzivoklis>
                    {
                        Iedzivotajs.CreateResidentLink(1, true),
                        Iedzivotajs.CreateResidentLink(2, false)
                    },
                },
                new Iedzivotajs
                {
                    Id = 4,
                    Vards = "Ieva",
                    Uzvards = "Krūmiņa",
                    Personas_Kods = 12345678904,
                    Dzimsanas_Datums = new DateOnly(1995, 4, 4),
                    Telefons = 876543209,
                    E_Mail = "ieva.krumina@epasts.com",
                    Saikne_Ar_Dzivokli = "Īpašnieks",
                    Is_Owner = true,
                    Iedzivotaja_Dzivokli = new List<Iedzivotaja_Dzivoklis>
                    {
                        Iedzivotajs.CreateResidentLink(1, true),
                        Iedzivotajs.CreateResidentLink(2, false)
                    },
                }
            );
        }

        context.SaveChanges();
    }
}
