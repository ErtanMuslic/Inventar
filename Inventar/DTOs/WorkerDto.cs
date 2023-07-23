using Inventar.Models;

namespace API.DTOs
{
    public class WorkerDto
    {
        public string PersonalNumber { get; set; } = String.Empty;


        public string Name { get; set; } = String.Empty;

        public string Surname { get; set; } = String.Empty;

        public Gender Gender { get; set; }

        public string Qualification { get; set; } = String.Empty;

        public Guid RoomId { get; set; }
    }
}
