using System;

namespace OOP_LAB
{
    class Subscription : Payment
    {
        public TimeSpan Period { get; private set; }

        public Subscription(Money amount, TimeSpan period, PaymentType type = PaymentType.subtracting) : base(amount, type)
        {
            Period = period;
        }

        public virtual Payment CalculatePayment(DateTime startTime, DateTime lastPaidTime, DateTime currTime)
        {
            long timesPaid = (long)((lastPaidTime - startTime).Divide(Period));
            long timesToPay = (long)((currTime - startTime).Divide(Period));
            return new Payment(Amount * (timesToPay - timesPaid), Type);
        }
    }
}
