using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedOnTime.Core.Models.CaretakerNameSpace
{
    public class CaretakerServices : ICaretakerServices
    {
        private readonly IMongoCollection<Caretaker> _caretakers;

        public MongoClientSettings ConfigurationManager { get; }

        public CaretakerServices(IDBClient dbClient)
        {
            _caretakers = (IMongoCollection<Caretaker>)dbClient.GetCaretakerCollection();

        }

        public Caretaker AddCaretaker(Caretaker caretaker)
        {
            _caretakers.InsertOne(caretaker);
            return caretaker;
        }

        public void DeleteCaretaker(string id)
        {
            _caretakers.DeleteOne(caretaker => caretaker.Id == id);
        }

        public Caretaker GetCaretaker(string id)
        {
            return _caretakers.Find(caretaker => caretaker.Id == id).First();
        }

        public List<Caretaker> GetCaretakers()
        {
            return _caretakers.Find(caretaker => true).ToList();
        }

        public Caretaker UpdateCaretaker(Caretaker caretakerToUpdate)
        {
            GetCaretaker(caretakerToUpdate.Id);
            _caretakers.ReplaceOne(c => c.Id == caretakerToUpdate.Id, caretakerToUpdate);
            return caretakerToUpdate;
        }
    }
}
