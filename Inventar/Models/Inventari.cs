using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Inventar.Models
{
    [BsonIgnoreExtraElements]
    public class Inventari
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Naziv { get; set; } = String.Empty;

        [BsonElement("serialNumber")]
        public int SerijskiBroj { get; set; } 


        //Moze da ima
        [BsonElement("brand")]
        public string Marka { get; set; } = String.Empty;

        [BsonElement("model")]
        public string Model { get; set; } = String.Empty;

        [BsonElement("price")]
        public int Cena { get; set; } 

    }
}
