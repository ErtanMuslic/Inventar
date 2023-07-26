
namespace Inventar.Models
{
    public class Room
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public int Floor { get; set; }

        public int Width { get; set; }

        public int Lenght { get; set; }

        public int Height { get; set; }

        public string Boss { get; set; } = String.Empty;

        public Guid WorkerId { get; set; }

        public Inventory? Inventory { get; set; }

        public Guid InventoryId { get; set; }


    }
}
