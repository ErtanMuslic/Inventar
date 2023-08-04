
namespace Inventar.Models
{
    public class Inventory
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public int SerialNumber { get; set; } 


        //Moze da ima
        public string Mark { get; set; } = String.Empty;

        public string Model { get; set; } = String.Empty;

        public int Quantity { get; set; }

        public int Price { get; set; } 

        public Room Room { get; set; }
        public Guid RoomId { get; set; }

    }
}
