namespace Inventar.Models
{
    public class Inventari
    {
        public Guid Id { get; set; }
        public string Naziv { get; set; }
        public int SerijskiBroj { get; set; }


        //Moze da ima
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Cena { get; set; }

    }
}
