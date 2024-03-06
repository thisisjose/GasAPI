using GasApii.Configuration;
using GasApii.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GasApii.Services
{
    public class MensajeServices
    {
         private readonly IMongoCollection<Mensaje> _mensajeCollection;

        public MensajeServices(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

            var mongoDB = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _mensajeCollection = mongoDB.GetCollection<Mensaje>(databaseSettings.Value.Collections["Mensaje"]);
        }

        public async Task<List<Mensaje>> GetAsync() => await _mensajeCollection.Find(_ => true).ToListAsync();

        public async Task<Mensaje> GetMensajeById(string Id)
        {
            return await _mensajeCollection.FindAsync(new BsonDocument { { "_id", new ObjectId(Id) } }).Result.FirstAsync();
        }

        public async Task InsertMensaje(Mensaje mensaje)
        {
            await _mensajeCollection.InsertOneAsync(mensaje);
        }

        public async Task UpdateMensaje(Mensaje mensaje)
        {
            var filter = Builders<Mensaje>.Filter.Eq(s => s.Id, mensaje.Id);
            await _mensajeCollection.ReplaceOneAsync(filter, mensaje);
        }

        public async Task DeleteMensaje(string Id)
        {
            var filter = Builders<Mensaje>.Filter.Eq(s => s.Id, Id);
            await _mensajeCollection.DeleteOneAsync(filter);
        }
    }
}
