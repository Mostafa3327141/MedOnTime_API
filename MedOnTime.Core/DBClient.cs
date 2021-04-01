
using MedOnTime.Core.Models.CaretakerNameSpace;
using MedOnTime.Core.Models.logSpace;
using MedOnTime.Core.Models.MedicationNameSpace;
using MedOnTime.Core.Models.PatientSpace;
using MedOnTime.Core.Models.PrescriptionSpace;
using MedOnTime.Core.Models.SubscriptionSpace;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MedOnTime.Core
{
    public class DBClient : IDBClient
    {

        private readonly IMongoCollection<Medication> _medications;
        private readonly IMongoCollection<Patient> _patients;
        private readonly IMongoCollection<Caretaker> _caretakers;
        private readonly IMongoCollection<Log> _Logs;
        private readonly IMongoCollection<Prescription> _Prescriptions;
        private readonly IMongoCollection<Subscription> _Subscriptions;

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

            //Log collection
            _Logs = database.GetCollection<Log>(medOnTimeDBConfig.Value.Log_Collection_Name);

            //Prescription collection
            _Prescriptions = database.GetCollection<Prescription>(medOnTimeDBConfig.Value.Prescription_Collection_Name);

            //Log collection
            _Subscriptions = database.GetCollection<Subscription>(medOnTimeDBConfig.Value.Subscription_Collection_Name);
        }

        public IMongoCollection<Medication> GetMedicationCollection() => _medications;
        public IMongoCollection<Patient> GetPatientCollection() => _patients;
        public IMongoCollection<Caretaker> GetCaretakerCollection() => _caretakers;
        public IMongoCollection<Log> GetLogCollection() => _Logs;
        public IMongoCollection<Prescription> GetPrescriptionCollection() => _Prescriptions;
        public IMongoCollection<Subscription> GetSubscriptionCollection() => _Subscriptions;

    }
}
