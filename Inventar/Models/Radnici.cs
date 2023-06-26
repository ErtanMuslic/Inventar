using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Inventar.Models
{
    [BsonIgnoreExtraElements]
    public class Radnici
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("jbmg")]

        public string JMBG { get; set; } = String.Empty;

        [BsonElement("name")]

        public string Ime { get; set; } = String.Empty;

        [BsonElement("lastname")]
        public string Prezime { get; set; } = String.Empty;

        [BsonElement("gender")]
        public string Pol { get;set; } = String.Empty;

        [BsonElement("qualifications")]
        public string Sprema { get; set; } = String.Empty;


     }
}
