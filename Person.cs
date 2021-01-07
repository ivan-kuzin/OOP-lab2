using System;
using System.Collections.Generic;

namespace OOP_LAB
{
    class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Money Balance { get; private set; }
        public DateTime PointInTime { get; private set; }

        private Dictionary<uint, PersonalSubscription> subscriptions;
        public Person(string firstName, string lastName, Money balance, DateTime pointInTIme = default(DateTime))
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException("Имя не может быть пустым");
            }
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
            PointInTime = pointInTIme;
            subscriptions = new Dictionary<uint, PersonalSubscription>();
        }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public void AddBalance(Money cash)
        {
            Balance = Balance + cash;
        }

        public void SubBalance(Money cash)
        {
            Balance = Balance - cash;
        }

        public override string ToString()
        {
            return $"{FullName}({PointInTime}): {Balance}";
        }

        public void Pay(Payment payment)
        {
            Money Total = payment.Amount;
            switch (payment.Type)
            {
                case PaymentType.adding:
                    Balance = Balance + Total;
                    break;
                case PaymentType.subtracting:
                    Balance = Balance - Total;
                    break;
            }
        }

        public uint AddSubscription(Subscription subscription, string description = "")
        {
            for (uint i = 0; ;i++)
            {
                if (!subscriptions.ContainsKey(i))
                {
                    subscriptions[i] = new PersonalSubscription(subscription, PointInTime);
                    return i;
                }
            }
        }

        public void RemoveSubscription(uint subscriptionId)
        {
            subscriptions.Remove(subscriptionId);
        }

        public void MoveInTime(DateTime destination)
        {
            if (destination < PointInTime)
            {
                throw new ArgumentException("Путешествие в прошлое не возможно!");
            }
            foreach (var entry in subscriptions)
            {
                PersonalSubscription subscription = entry.Value;
                Payment payment = subscription.Subscription.CalculatePayment(subscription.DateStart, PointInTime, destination);
                Pay(payment);
            }
            PointInTime = destination;
        }
    }
}
