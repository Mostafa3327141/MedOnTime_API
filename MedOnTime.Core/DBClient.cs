
using MedOnTime.Core.Models.CaretakerNameSpace;
using MedOnTime.Core.Models.MedicationNameSpace;
using MedOnTime.Core.Models.PatientSpace;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MedOnTime.Core
{
    public class DBClient : IDBClient
    {

        private readonly IMongoCollection<Medication> _medications;
        private readonly IMongoCollection<Patient> _patients;
        private readonly IMongoCollection<Caretaker> _caretakers;

        public DBClient(IOptions<MedOnTimeDBConfig> medOnTimeDBConfig)
        {
            var client = new MongoClient(medOnTimeDBConfig.Value.Connection_String);
            var database = client.GetDatabase(medOnTimeDBConfig.Value.Database_Name);

            //Medication collection
            _medications = database.GetCollection<Medication>(medOnTimeDBConfig.Value.Medication_Collection_Name);

            //Patient collection
            _patients = database.GetCollection<Patient>(medOnTimeDBConfig.Value.Patient_Collection_Name);

            //Caretaker collection
            _caretakers = database.GetCollection<Caretaker>(medOnTimeDBConfig.Value.Caretaker_Collection_Name);
        }

        public IMongoCollection<Medication> GetMedicationCollection() => _medications;
        public IMongoCollection<Patient> GetPatientCollection() => _patients;
        public IMongoCollection<Caretaker> GetCaretakerCollection() => _caretakers;
    }
}
