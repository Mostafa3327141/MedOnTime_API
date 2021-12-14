
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
            var client = new MongoClient("mongodb+srv://medontime:admin@medontime.fgmuf.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var database = client.GetDatabase("MedOnTimeDb");

            //Medication collection
            _medications = database.GetCollection<Medication>("Medication");

            //Patient collection
            _patients = database.GetCollection<Patient>("Patient");

            //Caretaker collection
            _caretakers = database.GetCollection<Caretaker>("Caretaker");

            //Log collection
            _Logs = database.GetCollection<Log>("Log");

            //Prescription collection
            _Prescriptions = database.GetCollection<Prescription>("Prescription");

            //Subscription collection
            _Subscriptions = database.GetCollection<Subscription>("Subscription");
        }

        public IMongoCollection<Medication> GetMedicationCollection() => _medications;
        public IMongoCollection<Patient> GetPatientCollection() => _patients;
        public IMongoCollection<Caretaker> GetCaretakerCollection() => _caretakers;
        public IMongoCollection<Log> GetLogCollection() => _Logs;
        public IMongoCollection<Prescription> GetPrescriptionCollection() => _Prescriptions;
        public IMongoCollection<Subscription> GetSubscriptionCollection() => _Subscriptions;

    }
}
