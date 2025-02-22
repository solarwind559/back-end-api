namespace Api1.Models
{
    public class Majas_Dzivoklis
    {
        public int Id { get; set; }
        public int Maja_Id { get; set; }
        public Maja? Maja { get; set; }
        public int Dzivoklis_Id { get; set; }
        public Dzivoklis? Dzivoklis { get; set; }
    }
}
