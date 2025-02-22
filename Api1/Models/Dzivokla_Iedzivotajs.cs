namespace Api1.Models
{
    public class Dzivokla_Iedzivotajs
    {
        public int Id { get; set; }
        public int Iedzivotajs_Id { get; set; }
        public Iedzivotajs? Iedzivotajs { get; set; }
        public int Dzivoklis_Id { get; set; }
        public Dzivoklis? Dzivoklis { get; set; }
    }
}