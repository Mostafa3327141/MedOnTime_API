using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedOnTime.Core.Models.PrescriptionSpace
{
    public class PrescriptionServices : IPrescriptionServices
    {
        private readonly IMongoCollection<Prescription> _prescriptions;

        public MongoClientSettings ConfigurationManager { get; }

        public PrescriptionServices(IDBClient dbClient)
        {
            _prescriptions = (IMongoCollection<Prescription>)dbClient.GetPrescriptionCollection();

        }

        public Prescription AddPrescription(Prescription prescription)
        {
            _prescriptions.InsertOne(prescription);
            return prescription;
        }

        public void DeletePrescription(string id)
        {
            _prescriptions.DeleteOne(prescription => prescription.Id == id);
        }

        public List<Prescription> GetPrescriptions()
        {
            return _prescriptions.Find(prescription => true).ToList();
        }

        public Prescription GetPrescription(string id)
        {
            return _prescriptions.Find(prescription => prescription.Id == id).First();
        }

        public Prescription UpdatePrescription(Prescription prescriptionToUpdate)
        {
            GetPrescription(prescriptionToUpdate.Id);
            _prescriptions.ReplaceOne(p => p.Id == prescriptionToUpdate.Id, prescriptionToUpdate);
            return prescriptionToUpdate;
        }
    }
}
