
namespace User.Models
{
    public class Inventory
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public int SerialNumber { get; set; } 


        //Moze da ima
        public string Mark { get; set; } = String.Empty;

        public string Model { get; set; } = String.Empty;

        public int Price { get; set; } 
        public Guid RoomId { get; set; }

    }
}
