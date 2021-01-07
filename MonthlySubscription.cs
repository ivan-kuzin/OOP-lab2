using System;

namespace OOP_LAB
{
    class MonthlySubscription : Subscription
    {
        public MonthlySubscription(Money amount, PaymentType type = PaymentType.subtracting) : base(amount, new TimeSpan(30, 0, 0, 0, 0), type)
        {

        }
    }
}
