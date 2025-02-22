namespace Api1.Models
{
    public class Dzivoklis
    {
        public int Id { get; set; }
        public int? Numurs { get; set; }
        public int? Stavs { get; set; }
        public int? Istabu_Skaits { get; set; }
        public int? Iedzivotaju_Skaits { get; set; }
        public int? Pilna_Platiba { get; set; }
        public int? Dzivojama_Platiba { get; set; }

        // Foreign key for Maja
        public int Maja_Id { get; set; }
        public Maja? Maja { get; set; }
        public string Saikne_Ar_Maju => Maja != null ? $"{Maja.Iela}, {Maja.Pilseta}, {Maja.Valsts}" : "N/A";
        public List<Iedzivotaja_Dzivoklis> Iedzivotaja_Dzivokli { get; set; } = new();

        public List<Iedzivotajs> Iedzivotaji { get; set; } = new();
        public List<Majas_Dzivoklis> Majas_Dzivokli { get; set; } = new();

        }
    }
