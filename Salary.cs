using System;

namespace OOP_LAB
{
    class Salary : MonthlySubscription
    {
        public Salary(Money amount) : base(amount, PaymentType.adding)
        {

        }

        override public Payment CalculatePayment(DateTime startTime, DateTime lastPaidTime, DateTime currTime)
        {
            long timesPaid = (long)((lastPaidTime - startTime).Divide(Period));
            long timesBonusPaid = timesPaid / 12;
            long timesToPay = (long)((currTime - startTime).Divide(Period));
            long timestoPayBonus = timesToPay / 12;
            return new Payment((Amount) * (timesToPay - timesPaid + timestoPayBonus - timesBonusPaid), Type);
        }
    }
}
