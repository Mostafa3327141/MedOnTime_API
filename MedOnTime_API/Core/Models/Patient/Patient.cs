using System.Collections.Generic;
using Core.Models.MedicationNameSpace;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models.PatientSpace
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
        public string? Email { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("PhoneNum")]
        public string PhoneNum { get; set; }

        [BsonElement("Age")]
        public int Age { get; set; }
        [BsonElement("UnSelectedShapes")]
        public List<Shape> UnSelectedShapes { get; set; }
        public List<int> MedicationIDs { get; set; }
        public List<int> PrescriptionIDs { get; set; }

    }
}
