
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MedOnTime.Core.Models.MedicationNameSpace
{
    public class Medication
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public int? PrescriptionID { get; set; }

        public int MedID { get; set; }

        public string MedicationName { get; set; }

        public string MethodOfTaking { get; set; }

        public int? MedicationImage { get; set; }

        public string Dosage { get; set; }

        public string MedicationType { get; set; }

        public int? Quantity { get; set; }

    }
}
