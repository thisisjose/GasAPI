using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GasApii.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id = string.Empty;

        [BsonElement("name")]
        public string name { get; set; } = string.Empty;

        [BsonElement("email")]
        public string email{ get; set; } = string.Empty;
                
        [BsonElement("password")]
        public string password { get; set; } = string.Empty;

        [BsonElement("celnumber")]
        public int celnumber { get; set; }
    }
}
