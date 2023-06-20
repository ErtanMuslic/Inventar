using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Inventar.Models
{
    [BsonIgnoreExtraElements]
    public class Prostorija
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Naziv { get; set; } = String.Empty;

        [BsonElement("floor")]
        public int Sprat { get; set; }

        [BsonElement("width")]
        public int Sirina { get; set; }

        [BsonElement("length")]
        public int Duzina { get; set; }

        [BsonElement("height")]
        public int Visina { get; set; }
    }
}
