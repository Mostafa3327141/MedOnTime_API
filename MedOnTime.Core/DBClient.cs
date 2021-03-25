
using MedOnTime_WebApp;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MedOnTime.Core
{
    public class DBClient : IDBClient
    {

        private readonly IMongoCollection<Medication> _medications;
        public DBClient(IOptions<MedOnTimeDBConfig> medOnTimeDBConfig)
        {
            var client = new MongoClient(medOnTimeDBConfig.Value.Connection_String);
            var database = client.GetDatabase(medOnTimeDBConfig.Value.Database_Name);
            _medications = database.GetCollection<Medication>(medOnTimeDBConfig.Value.Medication_Collection_Name);
        }

        public IMongoCollection<Medication> GetMedicationCollection() => _medications;
    }
}
