namespace Api1.Models
{
    public class Iedzivotajs_DTO
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
    }
}
