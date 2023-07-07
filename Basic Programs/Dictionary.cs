using System;
using System.Collections.Generic;

namespace BankProject.Basic_Programs
{
    internal class Dictionary
    {
        static void Main(string[] args)
        {
            // Creating a new dictionary
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            // Add key-value pairs
            dictionary.Add("Jharkhand", "Ranchi");
            dictionary.Add("Bihar", "Patna");
            dictionary.Add("Rajasthan", "Jaipur");
            dictionary.Add("Gujrat", "Gandhinagar");
            dictionary.Add("Maharashtra", "Mumbai");

            //printing the key and values
            foreach (KeyValuePair<string, string> item in dictionary)
            {
                Console.WriteLine("The value at key {0} is {1}", item.Key, item.Value);
            }
        }
    }
} 