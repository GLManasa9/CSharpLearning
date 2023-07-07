using NUnit.Framework;
using System;
using System.Collections;

namespace BankProject.Basic_Programs
{
    internal class HashTable
    {
        [Test]
        public void HashProgram()
        {
            // Creating a new hash table
            Hashtable hashtable = new Hashtable();

            // Add key-value pairs
            hashtable.Add("Jharkhand", "Ranchi");
            hashtable.Add("Bihar", "Patna");
            hashtable.Add("Rajasthan", "Jaipur");
            hashtable.Add("Gujrat", "Gandhinagar");
            hashtable.Add("Maharashtra", "Mumbai");

            //printing the key and values
            foreach (DictionaryEntry element in hashtable)
            {
                Console.WriteLine($"The value at key {element.Key} is {element.Value}");
            }
        }
    }
}
