
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MedOnTime_WebApp
{
    public class Medication
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public int? PrescriptionID { get; set; }

        //[BsonElement("MedID")]
        public int MedID { get; set; }

        //[BsonElement("MedicationName")]
        public string MedicationName { get; set; }

        //[BsonElement("MethodOfTaking")]
        public string MethodOfTaking { get; set; }

        public int? MedicationImage { get; set; }

        //[BsonElement("Dosage")]
        public string Dosage { get; set; }

        //[BsonElement("MedicationType")]
        public string MedicationType { get; set; }

        //[BsonElement("Quantity")]
        public int? Quantity { get; set; }

        //public Medication() { }

        //public Medication(int? prescriptionID, int medID, string medicationName, string methodOfTaking, int? medImage, string dosage, string medicationType, int quanitity)
        //{
        //    this.PrescriptionID = prescriptionID;
        //    this.MedID = medID;
        //    this.MedicationName = medicationName;
        //    this.MethodOfTaking = methodOfTaking;
        //    this.MedicationImage = medImage;
        //    this.Dosage = dosage;
        //    this.MedicationType = medicationType;
        //    this.Quantity = quanitity;
        //}
    }
}
