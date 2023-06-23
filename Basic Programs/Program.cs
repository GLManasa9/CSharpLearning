using NUnit.Framework;
using System;

namespace BankProject
{
    public class Program
    {
        [Test]
        public void Test1()
        {
            var a = 9;
            var b = 10;
            Console.WriteLine("result:"+(a+b));
        }

        [Test]
        public void Test2()
        {
            String s = "Manasa";
            Console.WriteLine("Length of string:{0}",s.Length);
            Console.WriteLine("Upper:{0}", s.ToUpper());
            Console.WriteLine("Lower:{0}", s.ToLower());

        }

        [Test]
        public void Test3()
        {
            String s = "Manasa";
            int i = 0;
            while (i < s.Length) {
                Console.WriteLine("HI");
                i++;
            }

            for (int j = 0; j < s.Length; j++)
            {
                Console.WriteLine("Hello");
            }
        }
    }
}
