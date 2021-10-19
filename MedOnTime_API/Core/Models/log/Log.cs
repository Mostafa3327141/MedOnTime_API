using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models.logSpace
{
    public class Log
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("PatientID")]
        public string PatientID { get; set; }

        [BsonElement("TimeTake")]
        public string TimeTake { get; set; }

        [BsonElement("MedicationID")]
        public string MedicationID { get; set; }

        [BsonElement("MedicationName")]
        public string MedicationName { get; set; }
    }
}
