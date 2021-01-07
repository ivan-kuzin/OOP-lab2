using System;

namespace OOP_LAB
{
    class DailySubscription : Subscription
    {
        public DailySubscription(Money amount, PaymentType type = PaymentType.subtracting) : base(amount, new TimeSpan(1, 0, 0, 0, 0), type)
        {

        }
    }
}
