using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedOnTime.Core.Models.logSpace
{
    public class Log
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public int PatientID { get; set; }
        public DateTime TimeTake { get; set; }
        public int MedicationID { get; set; }
    }
}
