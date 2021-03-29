using MedOnTime.Core.Models.PatientSpace;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedOnTime.Core.Models.CaretakerNameSpace
{
    public class Caretaker
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public int ctID { get; set; }

        [BsonElement("Username")]
        public string Username { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("PhoneNum")]
        public int? PhoneNum { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        /*[BsonElement("Age")]
        public int? Age { get; set; }*/

        public string Password { get; set; }

        [BsonElement("PasswordHash")]
        public string PasswordHash { get; set; }
        public List<string> PatientIDs { get; set; }

        public List<Patient> Patients { get; set; }
        public Caretaker() { }
        public Caretaker(string firstName, string lastName, string email, int phoneNum)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNum = phoneNum;
            this.PatientIDs = new List<string>();
            this.Patients = new List<Patient>();
        }
    }
}
