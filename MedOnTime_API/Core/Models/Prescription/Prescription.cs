using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.PrescriptionSpace
{
    public class Prescription
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public int PrescriptionID { get; set; }
        public int PatientID { get; set; }

        public int HoursBetween { get; set; }
        public string DoctorName { get; set; }
        public string Description { get; set; }
        public int Picture { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
