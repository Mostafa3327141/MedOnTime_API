using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedOnTime.Core.Models.logSpace
{
    public class LogServices : ILogServices
    {
        private readonly IMongoCollection<Log> _logs;

        public MongoClientSettings ConfigurationManager { get; }

        public LogServices(IDBClient dbClient)
        {
            _logs = (IMongoCollection<Log>)dbClient.GetLogCollection();

        }

        public Log AddLog(Log log)
        {
            _logs.InsertOne(log);
            return log;
        }

        public void DeleteLog(string id)
        {
            _logs.DeleteOne(log => log.Id == id);
        }


        public List<Log> GetLogs()
        {
            return _logs.Find(log => true).ToList();
        }

        public List<Log> GetPatientLogs(string patientID)
        {
            return _logs.Find(log => log.PatientID == patientID).ToList();
        }

        public Log GetLog(string id)
        {
            return _logs.Find(log => log.Id == id).First();
        }

        public Log UpdateLog(Log logToUpdate)
        {
            GetLog(logToUpdate.Id);
            _logs.ReplaceOne(l => l.Id == logToUpdate.Id, logToUpdate);
            return logToUpdate;
        }
    }
}
