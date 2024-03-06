using GasApii.Configuration;
using GasApii.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GasApii.Services
{
    public class MotorServices
    {
        private readonly IMongoCollection<Motor> _motorCollection;

        public MotorServices(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

            var mongoDB = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _motorCollection = mongoDB.GetCollection<Motor>(databaseSettings.Value.Collections["Motores"]);
        }

        public async Task<List<Motor>> GetAsync() => await _motorCollection.Find(_ => true).ToListAsync();

        public async Task<Motor> GetMotorById(string Id)
        {
            return await _motorCollection.FindAsync(new BsonDocument { { "_id", new ObjectId(Id) } }).Result.FirstAsync();
        }

        public async Task InsertMotor(Motor motor)
        {
            await _motorCollection.InsertOneAsync(motor);
        }

        public async Task UpdateMotor(Motor motor)
        {
            var filter = Builders<Motor>.Filter.Eq(s => s.Id, motor.Id);
            await _motorCollection.ReplaceOneAsync(filter, motor);
        }

        public async Task DeleteMotor(string Id)
        {
            var filter = Builders<Motor>.Filter.Eq(s => s.Id, Id);
            await _motorCollection.DeleteOneAsync(filter);
        }
    }

}
