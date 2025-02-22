namespace Api1.Models
{
    public class Dzivoklis_DTO
    {
        public int Id { get; set; }
        public int? Numurs { get; set; }
        public int? Stavs { get; set; }
        public int? Istabu_Skaits { get; set; }
        public int? Iedzivotaju_Skaits { get; set; }
        public int? Pilna_Platiba { get; set; }
        public int? Dzivojama_Platiba { get; set; }
        public int Maja_Id { get; set; } // The Foreign key for Maja
        public string? Saikne_Ar_Maju { get; set; }
        }
    }
