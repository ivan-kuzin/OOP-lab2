using System;

namespace OOP_LAB
{
    public class Money
    {
        public long Rubles { get; private set; }
        public byte Penny { get; private set; }

        public Money(long rubles, byte penny = 0)
        {

            Rubles = rubles + penny / 100;
            Penny = (byte)(penny % 100);
            if (Rubles < 0 || Penny < 0)
            {
                throw new ArgumentException("Деньги не могут быть отрицательными");
            }
        }

        public Money()
        {
            Rubles = 0;
            Penny = 0;
        }

        public static Money operator +(Money coin1, Money coin2)
        {
            var sum_penny = coin1.Penny + coin2.Penny;
            var sum_rubles = coin1.Rubles + coin2.Rubles;
            return new Money(sum_rubles + sum_penny / 100, (byte)(sum_penny % 100));
        }

        public static Money operator -(Money coin1, Money coin2)
        {
            if (coin1.Penny >= coin2.Penny)
            {
                return new Money(coin1.Rubles - coin2.Rubles, (byte)(coin1.Penny - coin2.Penny));
            }
            else
            {
                return new Money(coin1.Rubles - coin2.Rubles - 1, (byte)(coin1.Penny + 100 - coin2.Penny));
            }
        }

        public static Money operator *(Money coin, long multiplier)
        {
            if (multiplier < 0)
            {
                throw new ArgumentException("Деньги не могут быть отрицательными");
            }
            long mul_penny = coin.Penny * multiplier;
            return new Money(coin.Rubles * multiplier + mul_penny / 100, (byte)(mul_penny % 100));
        }

        public static Money operator /(Money coin, long divider)
        {
            if (divider == 0)
            {
                throw new DivideByZeroException("На ноль делить нельзя");
            }
            if (divider < 0)
            {
                throw new ArgumentException("Деньги не могут быть отрицательными");
            }

            var kopeck = ((coin.Rubles % divider) * 100 / divider) + (coin.Penny / divider);
            return new Money((coin.Rubles / divider + kopeck / 100), (byte)(kopeck % 100));
        }

        public static bool operator >(Money coin1, Money coin2)
        {
            return (coin1.Rubles > coin2.Rubles) || (coin1.Rubles == coin2.Rubles && coin1.Penny > coin2.Penny);
        }

        public static bool operator <(Money coin1, Money coin2)
        {
            return coin1.Rubles < coin2.Rubles || coin1.Rubles == coin2.Rubles && coin1.Penny < coin2.Penny;
        }

        public static bool operator >=(Money coin1, Money coin2)
        {
            return !(coin1 < coin2);
        }

        public static bool operator <=(Money coin1, Money coin2)
        {
            return !(coin1 > coin2);
        }

        public static bool operator ==(Money coin1, Money coin2)
        {
            return (coin1.Rubles == coin2.Rubles && coin1.Penny == coin2.Penny);
        }

        public static bool operator !=(Money coin1, Money coin2)
        {
            return !(coin1 == coin2);
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                return this == (Money)obj;
            }
        }

        public override int GetHashCode()
        {
            return Rubles.GetHashCode() + Penny.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Rubles}.{Penny}₽";
        }

    }
}
