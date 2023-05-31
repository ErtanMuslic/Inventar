namespace Inventar.Models
{
    public class Prostorija
    {
        public Guid Id { get; set; }
        public string Naziv { get; set; }
        
        public int Sprat { get; set; }
        public int Sirina { get; set; }
        public int Duzina { get; set; }

        public int Visina { get; set; }
    }
}
