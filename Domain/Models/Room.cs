
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

        public Inventory? Inventory { get; set; }

        public Worker? Worker { get; set; }

        public Guid? workerId { get; set; }


    }
}
