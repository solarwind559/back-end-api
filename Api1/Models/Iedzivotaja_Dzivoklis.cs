namespace Api1.Models
{
    public class Iedzivotaja_Dzivoklis
    {
        public int Id { get; set; }
        public int Iedzivotajs_Id { get; set; }
        public Iedzivotajs? Iedzivotajs { get; set; }
        public int Dzivoklis_Id { get; set; }
        public Dzivoklis? Dzivoklis { get; set; }
        public bool Is_Owner { get; set; }
        public string? Saikne_Ar_Dzivokli { get; set; }

    }
}
