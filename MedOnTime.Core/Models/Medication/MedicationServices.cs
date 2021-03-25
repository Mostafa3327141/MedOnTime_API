﻿
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedOnTime.Core.Models.Medication
{
    public class MedicationServices : IMedicationServices
    {
        private readonly IMongoCollection<Medication> _medications;

        //public MongoClientSettings ConfigurationManager { get; }

        public MedicationServices(IDBClient dbClient)
        {
            _medications = dbClient.GetMedicationCollection();

        }

        public Medication AddMedication(Medication medication)
        {
            _medications.InsertOne(medication);
            return medication;
        }

        public void DeleteMedication(string id)
        {
            _medications.DeleteOne(medication => medication.Id == id);
        }

        public Medication GetMedication(string id)
        {
            return _medications.Find(medication => medication.Id == id).First();
        }

        public List<Medication> GetMedications() => _medications.Find(medication => true).ToList();

        public Medication UpdateMedication(Medication medicationToUpdate)
        {

            GetMedication(medicationToUpdate.Id);
            _medications.ReplaceOne(m => m.Id == medicationToUpdate.Id, medicationToUpdate);
            return medicationToUpdate;

            throw new NotImplementedException();
        }
    }

}
