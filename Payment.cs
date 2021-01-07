enum PaymentType
{
    adding,
    subtracting
};

namespace OOP_LAB
{
    class Payment
    {
        public PaymentType Type { get; private set; }
        public Money Amount { get; private set; }

        public Payment(Money amount, PaymentType type = PaymentType.subtracting)
        {
            Amount = amount;
            Type = type;
        }

    }
}
