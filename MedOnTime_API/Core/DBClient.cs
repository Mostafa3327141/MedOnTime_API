
using Core.Models.CaretakerNameSpace;
using Core.Models.logSpace;
using Core.Models.MedicationNameSpace;
using Core.Models.PatientSpace;
using Core.Models.PrescriptionSpace;
using Core.Models.SubscriptionSpace;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
// TODO: Replace manual string conversion to byte array with GridFS storage after prototype's finished.
//using MongoDB.Driver.GridFS; // Must download in package manager https://www.nuget.org/packages/MongoDB.Driver.GridFS


namespace Core
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
            var client = new MongoClient(/*medOnTimeDBConfig.Value.Connection_String*/"mongodb+srv://medontime:admin@medontime.fgmuf.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var database = client.GetDatabase(/*medOnTimeDBConfig.Value.Database_Name*/"MedOnTimeDb");

            //Medication collection
            _medications = database.GetCollection<Medication>(/*medOnTimeDBConfig.Value.Medication_Collection_Name*/"Medication");

            //Patient collection
            _patients = database.GetCollection<Patient>(/*medOnTimeDBConfig.Value.Patient_Collection_Name*/"Patient");

            //Caretaker collection
            _caretakers = database.GetCollection<Caretaker>(/*medOnTimeDBConfig.Value.Caretaker_Collection_Name*/"Caretaker");

            //Log collection
            _Logs = database.GetCollection<Log>(/*medOnTimeDBConfig.Value.Log_Collection_Name*/"Log");

            //Prescription collection
            _Prescriptions = database.GetCollection<Prescription>(/*medOnTimeDBConfig.Value.Prescription_Collection_Name*/"Prescription");

            //Subscription collection
            _Subscriptions = database.GetCollection<Subscription>(/*medOnTimeDBConfig.Value.Subscription_Collection_Name*/"Subscription");
        }

        public IMongoCollection<Medication> GetMedicationCollection() => _medications;
        public IMongoCollection<Patient> GetPatientCollection() => _patients;
        public IMongoCollection<Caretaker> GetCaretakerCollection() => _caretakers;
        public IMongoCollection<Log> GetLogCollection() => _Logs;
        public IMongoCollection<Prescription> GetPrescriptionCollection() => _Prescriptions;
        public IMongoCollection<Subscription> GetSubscriptionCollection() => _Subscriptions;

    }
}
