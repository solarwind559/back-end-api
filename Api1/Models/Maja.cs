namespace Api1.Models
{
    public class Maja
    {
        public int Id { get; set; }
        public int? Numurs { get; set; }
        public string? Iela { get; set; }
        public string? Pilseta { get; set; }
        public string? Valsts { get; set; }
        public string? Pasta_Indekss { get; set; }
        public ICollection<Dzivoklis>? Dzivokli { get; set; }
        public List<Majas_Dzivoklis> Majas_Dzivokli { get; set; } = new();

    }
}
