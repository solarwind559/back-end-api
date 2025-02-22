namespace Api1.Models
{
    public class Iedzivotajs
    {
        public int Id { get; set; }
        public string? Vards { get; set; }
        public string? Uzvards { get; set; }
        public long? Personas_Kods { get; set; }
        public DateOnly? Dzimsanas_Datums { get; set; }
        public long? Telefons { get; set; }
        public string? E_Mail { get; set; }
        public string? Saikne_Ar_Dzivokli { get; set; }
        public bool? Is_Owner { get; set; }

        // Navigation property for many-to-many relationships
        public List<Iedzivotaja_Dzivoklis> Iedzivotaja_Dzivokli { get; set; } = new();
        
        //Foreign key:
        public int Dzivoklis_Id { get; set; }

        public static Iedzivotaja_Dzivoklis CreateResidentLink(int dzivoklisId, bool isOwner)
        {
            return new Iedzivotaja_Dzivoklis
            {
                Dzivoklis_Id = dzivoklisId,
                Is_Owner = isOwner,
                Saikne_Ar_Dzivokli = isOwner ? "Īpašnieks" : "Īrnieks"
            };
        }

    }
}
