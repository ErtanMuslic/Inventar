
namespace Inventar.Models
{
    public class Inventari
    {
        public string Id { get; set; } = String.Empty;

        public string Naziv { get; set; } = String.Empty;

        public int SerijskiBroj { get; set; } 


        //Moze da ima
        public string Marka { get; set; } = String.Empty;

        public string Model { get; set; } = String.Empty;

        public int Cena { get; set; } 

    }
}
