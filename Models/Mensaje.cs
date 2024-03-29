﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GasApii.Models
{
    public class Mensaje
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id = string.Empty;

        [BsonElement("TipoMensaje")]
        public string TipoMensaje{ get; set; } = string.Empty;

        [BsonElement("Texto")]
        public string Texto{ get; set; } = string.Empty;

        [BsonElement("Fecha")]
        public DateTime Fecha { get; set; }
    }
}
