using Core.Models.CaretakerNameSpace;
using Core.Models.logSpace;
using Core.Models.MedicationNameSpace;
using Core.Models.PatientSpace;
using Core.Models.PrescriptionSpace;
using Core.Models.SubscriptionSpace;
using MongoDB.Driver;
//using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IDBClient
    {
        IMongoCollection<Medication> GetMedicationCollection();
        IMongoCollection<Patient> GetPatientCollection();
        IMongoCollection<Caretaker> GetCaretakerCollection();
        IMongoCollection<Log> GetLogCollection();
        IMongoCollection<Subscription> GetSubscriptionCollection();
        IMongoCollection<Prescription> GetPrescriptionCollection();
    }
}
