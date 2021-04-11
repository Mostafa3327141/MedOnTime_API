using Core.Models.PatientSpace;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.PatientSpace
{
    public class PatientServices : IPatientServices
    {
        private readonly IMongoCollection<Patient> _patients;

        public MongoClientSettings ConfigurationManager { get; }

        public PatientServices(IDBClient dbClient)
        {
            _patients = (IMongoCollection<Patient>)dbClient.GetPatientCollection();

        }

        public Patient AddPatient(Patient patient)
        {
            _patients.InsertOne(patient);
            return patient;
        }

        public void DeletePatient(string id)
        {
            _patients.DeleteOne(patient => patient.Id == id);
        }

        public Patient GetPatient(string id)
        {
            return _patients.Find(patient => patient.Id == id).First();
        }

        public List<Patient> GetPatients(int careTakerID)
        {
            return _patients.Find(patient => patient.CaretakerID == careTakerID).ToList();
        }

        public List<Patient> GetPatients()
        {
            return _patients.Find(patient => true).ToList();
        }

        public Patient UpdatePatient(Patient patientToUpdate)
        {
            GetPatient(patientToUpdate.Id);
            _patients.ReplaceOne(p => p.Id == patientToUpdate.Id, patientToUpdate);
            return patientToUpdate;
        }
    }
}
