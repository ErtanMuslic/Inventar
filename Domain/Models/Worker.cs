using System.ComponentModel.DataAnnotations;

namespace Inventar.Models
{
    public class Worker
    {
        public Guid Id { get; set; }


        public string PersonalNumber { get; set; } = String.Empty;


        public string Name { get; set; } = String.Empty;

        public string Surname { get; set; } = String.Empty;

        [EnumDataType(typeof(Gender))]
        public Gender Gender { get;set; }

        public string Qualification { get; set; } = String.Empty;

     }
}
