using NUnit.Framework;
using System;

namespace BankProject.SOLID
{
    interface ICustomer
    {
        string name { get; set; }
        int age { set; get; }
        string productName { get; set; }
        decimal calculateDiscount();
    }

    interface ICustomerWithInterest : ICustomer
    {
        void calculateInterest();
    }

    public abstract class Customer : ICustomer, ICustomerWithInterest
    {
        string ICustomer.name { get; set; }
        int ICustomer.age { get; set; }
        string ICustomer.productName { get; set; }

        public abstract decimal calculateDiscount();

        public abstract void calculateInterest();
    }

    public class GoldCustomer : Customer
    {

        public override decimal calculateDiscount()
        {
            Console.WriteLine("Discount on gold products is 5%");
            return 5;
        }

        public override void calculateInterest()
        {
            Console.WriteLine("Interest on gold products is 11%");
        }
    }


    public class SilverCustomer : Customer
    {
        public override decimal calculateDiscount()
        {
            Console.WriteLine("Discount on silver products is 10%");
            return 10;
        }

        public override void calculateInterest()
        {
            Console.WriteLine("Interest on silver products is 9%");
        }
    }

    public class ImpConcepts
    {
        [Test]
        public void Imp()
        {
            ICustomer gc = new GoldCustomer();
            ICustomer sc = new SilverCustomer();
            gc.name = "manasa";
            gc.age = 30;
            sc.name = "nagamani";
            sc.age = 58;
            gc.calculateDiscount();
            Console.WriteLine(gc.name);
            Console.WriteLine(gc.age);
            sc.calculateDiscount();
            Console.WriteLine(sc.name);
            Console.WriteLine(sc.age);
            ICustomerWithInterest gc_interest = new GoldCustomer();
            gc_interest.calculateInterest();
        }
    }
}
