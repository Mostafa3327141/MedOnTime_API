
using MedOnTime_WebApp;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedOnTime.Core
{
    public class MedicationServices : IMedicationServices
    {
        private readonly IMongoCollection<Medication> _medicationCollection;

        //public MongoClientSettings ConfigurationManager { get; }

        public MedicationServices(IDBClient dbClient)
        {
            _medicationCollection = dbClient.GetMedicationCollection();

        }

        public Medication AddMedication(Medication medication)
        {
            _medicationCollection.InsertOne(medication);
            return medication;
        }

        public Medication GetMedication(string id)
        {
            return _medicationCollection.Find(medication => medication.Id == id).First();
        }

        public List<Medication> GetMedications() => _medicationCollection.Find(medication => true).ToList(); 
    }

}

