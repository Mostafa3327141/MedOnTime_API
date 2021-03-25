using MedOnTime.Core.Models.Medication;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedOnTime.Core
{
    public interface IDBClient
    {
        IMongoCollection<Medication> GetMedicationCollection();
            
    }
}
