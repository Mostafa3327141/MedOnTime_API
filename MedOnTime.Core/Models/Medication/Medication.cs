
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MedOnTime.Core.Models.MedicationNameSpace
{
    public class Medication
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("CaretakerID")]
        public string CaretakerID { get; set; }

        [BsonElement("PatientID")]
        public int PatientID { get; set; }

        [BsonElement("MedicationName")]
        public string MedicationName { get; set; }

        [BsonElement("MethodOfTaking")]
        public string MethodOfTaking { get; set; }

        [BsonElement("MedicationImage")]
        public string MedicationImage { get; set; }

        [BsonElement("Dosage")]
        public string Dosage { get; set; }

        [BsonElement("MedicationType")]
        public string MedicationType { get; set; }

        [BsonElement("Quantity")]
        public int? Quantity { get; set; }

        [BsonElement("FirstDoseTime")]
        public string FirstDoseTime { get; set; }

        [BsonElement("HoursBetween")]
        public int HoursBetween { get; set; }

        [BsonElement("Frequency")]
        public string Frequency { get; set; }

        [BsonElement("Times")]
        public List<DateTime> Times { get; set; }
    }
}
