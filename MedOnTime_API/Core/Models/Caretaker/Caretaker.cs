using Core.Models.PatientSpace;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.CaretakerNameSpace
{
    public class Caretaker
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public int CaretakerID { get; set; }
        
        [BsonElement("Username")]
        public string Username { get; set; }
        
        [BsonElement("FirstName")]
        public string FirstName { get; set; }
        
        [BsonElement("LastName")]
        public string LastName { get; set; }
        
        [BsonElement("PhoneNum")]
        public string PhoneNum { get; set; }
        
        [BsonElement("Email")]
        public string Email { get; set; }
        
        public string Password { get; set; }

        [BsonElement("PasswordHash")]
        public string PasswordHash { get; set; }

        public List<int> PatientIDs { get; set; }
    }
}
