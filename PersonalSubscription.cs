using System;

namespace OOP_LAB
{
    class PersonalSubscription
    {
        public Subscription Subscription { get; private set; }
        public DateTime DateStart { get; private set; }
        public PersonalSubscription(Subscription subscription, DateTime dateStart)
        {
            Subscription = subscription;
            DateStart = dateStart;
        }
    }
}
