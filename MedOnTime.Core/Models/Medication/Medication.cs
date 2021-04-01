
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

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

        public string MedicationImage { get; set; }

        [BsonElement("Dosage")]
        public string Dosage { get; set; }

        [BsonElement("MedicationType")]
        public string MedicationType { get; set; }

        [BsonElement("Quantity")]
        public int? Quantity { get; set; }

        [BsonElement("TimeOfTaking")]
        public string TimeOfTaking { get; set; }

        [BsonElement("Frequency")]
        public string Frequency { get; set; }
    }
}
