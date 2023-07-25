using Inventar.Models;

namespace API.DTOs
{
    public class RoomDto
    {
        public string Name { get; set; } = String.Empty;

        public int Floor { get; set; }

        public int Width { get; set; }

        public int Lenght { get; set; }

        public int Height { get; set; }

        public string? Boss { get; set; }

        public ICollection<WorkerDto>? Workers { get; set; }

        public ICollection<InventoryDto>? Inventory { get; set; } 
    }
}
