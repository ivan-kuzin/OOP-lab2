using System;
using System.Text;

namespace OOP_LAB
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            DateTime now = DateTime.Now;

            Console.WriteLine("Тест одиночных платежей");
            Person person1 = new Person("Василий", "Пупкин", new Money(3000, 0), now);
            Console.WriteLine(person1);

            Payment payment = new Payment(new Money(100, 0));

            person1.Pay(payment);
            Console.WriteLine(person1);

            Person person2 = new Person("Пётр", "Ерохин", new Money(1000, 0), now);
            Console.WriteLine(person2);

            Payment bonus = new Payment(new Money(350, 0), PaymentType.adding);

            person2.Pay(bonus);
            Console.WriteLine(person2);

            Console.WriteLine("Тест ежедневных платежей");
            MonthlySubscription netflix = new MonthlySubscription(new Money(300));
            DailySubscription relif = new DailySubscription(new Money(50), PaymentType.adding);
            uint person1_relif = person1.AddSubscription(relif);
            uint person2_relif = person2.AddSubscription(relif);
            for (int i = 0; i < 2; i++)
            {
                now = now.AddDays(1);
                person1.MoveInTime(now);
                person2.MoveInTime(now);
                Console.WriteLine(person1);
                Console.WriteLine(person2);
            }
            Console.WriteLine("Тест ежемесячных платежей");
            uint person1_netflix = person1.AddSubscription(netflix);
            person1.MoveInTime(now);
            Console.WriteLine(person1);
            Console.WriteLine(person2);
            for (int i = 0;i < 2;i++)
            {
                now = now.AddDays(30);
                person1.MoveInTime(now);
                person2.MoveInTime(now);
                Console.WriteLine(person1);
                Console.WriteLine(person2);
            }
            uint person2_netflix = person2.AddSubscription(netflix);
            for (int i = 0; i < 2; i++)
            {
                now = now.AddDays(30);
                person1.MoveInTime(now);
                person2.MoveInTime(now);
                Console.WriteLine(person1);
                Console.WriteLine(person2);
            }
            Console.WriteLine("Тест зарплаты");
            Salary person1_salary = new Salary(new Money(10000));
            Salary person2_salary = new Salary(new Money(30000));
            person1.RemoveSubscription(person1_relif);
            person1.AddSubscription(person1_salary);
            person2.RemoveSubscription(person2_relif);
            person2.AddSubscription(person2_salary);
            for (int i = 0; i < 15; i++)
            {
                now = now.AddDays(30);
                person1.MoveInTime(now);
                person2.MoveInTime(now);
                if (i > 0 && (i + 1) % 12 == 0)
                {
                    Console.WriteLine("Здесь должна быть 13 зарплата!");
                }
                Console.WriteLine(person1);
                Console.WriteLine(person2);
            }
        }
    }
}
