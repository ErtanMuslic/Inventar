namespace Inventar.Models
{
    public class Radnici
    {
        public Guid Id { get; set; }


        public string JMBG { get; set; } = String.Empty;


        public string Ime { get; set; } = String.Empty;

        public string Prezime { get; set; } = String.Empty;

        public Pol Pol { get;set; }

        public string Sprema { get; set; } = String.Empty;

        public Guid ProstorijaId { get; set; }

     }
}
