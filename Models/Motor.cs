using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GasApii.Models
{
    public class Motor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id = string.Empty;

        [BsonElement("numeroMotor")]
        public int numeroMotor { get; set; } 

        [BsonElement("ubicacionMotor")]
        public string ubicacionMotor { get; set; } = string.Empty;

        [BsonElement("fecha")] 
        public DateTime fecha { get; set; } 
    }
}
