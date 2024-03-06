using GasApii.Configuration;
using GasApii.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GasApii.Services
{
    public class UsuarioServices
    {
        private readonly IMongoCollection<Usuario> _UsuarioCollection;

        public UsuarioServices(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

            var mongoDB = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _UsuarioCollection = mongoDB.GetCollection<Usuario>(databaseSettings.Value.Collections["Usuario"]);
        }

        public async Task<List<Usuario>> GetAsync() => await _UsuarioCollection.Find(_ => true).ToListAsync();

        public async Task<Usuario> GetUsuarioById(string Id)
        {
            return await _UsuarioCollection.FindAsync(new BsonDocument { { "_id", new ObjectId(Id) } }).Result.FirstAsync();
        }

        public async Task InsertUsuario(Usuario usuario)
        {
            await _UsuarioCollection.InsertOneAsync(usuario);
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            var filter = Builders<Usuario>.Filter.Eq(s => s.Id, usuario.Id);
            await _UsuarioCollection.ReplaceOneAsync(filter, usuario);
        }

        public async Task DeleteUsuario(string Id)
        {
            var filter = Builders<Usuario>.Filter.Eq(s => s.Id, Id);
            await _UsuarioCollection.DeleteOneAsync(filter);
        }
    }
}
