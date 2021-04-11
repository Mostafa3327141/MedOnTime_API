using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.SubscriptionSpace
{
    public interface ISubscriptionServices
    {
        List<Subscription> GetSubscriptions();
        Subscription GetSubscription(string id);

        Subscription AddSubscription(Subscription subscription);

        void DeleteSubscription(string id);

        Subscription UpdateSubscription(Subscription subscription);
    }
}
