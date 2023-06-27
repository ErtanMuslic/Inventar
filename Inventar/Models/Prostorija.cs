
namespace Inventar.Models
{
    public class Prostorija
    {
        public Guid Id { get; set; }

        public string Naziv { get; set; } = String.Empty;

        public int Sprat { get; set; }

        public int Sirina { get; set; }

        public int Duzina { get; set; }

        public int Visina { get; set; }

        public string Sef { get; set; }

        public ICollection<Radnici> Radnici { get; set; } 

        public Guid IdRadnika { get; set; }

        public ICollection<Inventari> Inventari { get; set; }

        public Guid IdInventari { get; set; }


    }
}
