using System;
using System.Collections.Generic;
using System.Text;
using MedOnTime.Core.Models.CaretakerNameSpace;
using MedOnTime.Core.Models.MedicationNameSpace;
using MongoDB.Bson.Serialization.Attributes;

namespace MedOnTime.Core.Models.PatientSpace
{
    public class Patient
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public int PatientID { get; set; }
        public int CaretakerID { get; set; } 

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("PhoneNum")]
        public string PhoneNum { get; set; }

        [BsonElement("Age")]
        public int Age { get; set; }

        public List<int> MedicationIDs { get; set; }
        public List<int> PrescriptionIDs { get; set; }

    }
}
