using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedOnTime.Core.Models.SubscriptionSpace
{
    public class Subscription
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime CaretakerID { get; set; }
    }
}
