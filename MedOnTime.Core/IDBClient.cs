using MedOnTime.Core.Models.CaretakerNameSpace;
using MedOnTime.Core.Models.logSpace;
using MedOnTime.Core.Models.MedicationNameSpace;
using MedOnTime.Core.Models.PatientSpace;
using MedOnTime.Core.Models.PrescriptionSpace;
using MedOnTime.Core.Models.SubscriptionSpace;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedOnTime.Core
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
