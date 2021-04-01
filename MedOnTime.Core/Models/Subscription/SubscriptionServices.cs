using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedOnTime.Core.Models.SubscriptionSpace
{
    public class SubscriptionServices : ISubscriptionServices
    {
        private readonly IMongoCollection<Subscription> _subscriptions;

        public MongoClientSettings ConfigurationManager { get; }

        public SubscriptionServices(IDBClient dbClient)
        {
            _subscriptions = (IMongoCollection<Subscription>)dbClient.GetSubscriptionCollection();

        }

        public Subscription AddSubscription(Subscription subscription)
        {
            _subscriptions.InsertOne(subscription);
            return subscription;
        }

        public void DeleteSubscription(string id)
        {
            _subscriptions.DeleteOne(subscription => subscription.Id == id);
        }

        public Subscription GetSubscription(string id)
        {
            return _subscriptions.Find(subscription => subscription.Id == id).First();
        }

        public List<Subscription> GetSubscriptions()
        {
            return _subscriptions.Find(subscription => true).ToList();
        }

        public Subscription UpdateSubscription(Subscription subscriptionToUpdate)
        {
            GetSubscription(subscriptionToUpdate.Id);
            _subscriptions.ReplaceOne(s => s.Id == subscriptionToUpdate.Id, subscriptionToUpdate);
            return subscriptionToUpdate;
        }
    }
}
