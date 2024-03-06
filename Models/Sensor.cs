using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GasApii.Models
{
    public class Sensor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id = string.Empty;

        [BsonElement("Numero")]
        public int Numero { get; set; }

        [BsonElement("Modelo")]
        public string Modelo { get; set; } = string.Empty;

        [BsonElement("Fecha")]
        public DateTime Fecha { get; set; }

        [BsonElement("celnumber")]
        public int celnumber { get; set; }     
    }
}
