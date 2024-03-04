using GasApii.Configuration;
using GasApii.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GasApii.Services
{
    public class SensorServices
    {
        private readonly IMongoCollection<Sensor> _SensorCollection;

        public SensorServices(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

            var mongoDB = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _SensorCollection = mongoDB.GetCollection<Sensor>(databaseSettings.Value.CollectionName);
        }

        public async Task<List<Sensor>> GetAsync() => await _SensorCollection.Find(_ => true).ToListAsync();

        public async Task<Sensor> GetSensorById(string Id)
        {
            return await _SensorCollection.FindAsync(new BsonDocument { { "_id", new ObjectId(Id) } }).Result.FirstAsync();
        }

        public async Task InsertSensor(Sensor sensor)
        {
            await _SensorCollection.InsertOneAsync(sensor);
        }

        public async Task UpdateSensor(Sensor sensor)
        {
            var filter = Builders<Sensor>.Filter.Eq(s => s.Id, sensor.Id);
            await _SensorCollection.ReplaceOneAsync(filter, sensor);
        }

        public async Task DeleteSensor(string Id)
        {
            var filter = Builders<Sensor>.Filter.Eq(s => s.Id, Id);
            await _SensorCollection.DeleteOneAsync(filter);
        }
    }
}
