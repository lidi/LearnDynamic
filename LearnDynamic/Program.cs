using System;
using System.Collections.Generic;

namespace LearnDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo1();
            Demo2();
            //Demo3();
            Demo4();
            Console.Read();
        }

        public static void Demo1()
        {
            dynamic items = new List<string> { "First", "Second", "Third" };
            dynamic valueToAdd = "!";
            foreach (dynamic item in items)
            {
                string result = item + valueToAdd;
                Console.WriteLine(result);
            }
        }

        public static void Demo2()
        {
            dynamic items = new List<string> { "First", "Second", "Third" };
            dynamic valueToAdd = 2;
            foreach (dynamic item in items)
            {
                string result = item + valueToAdd;
                Console.WriteLine(result);
            }
        }

        public static void Demo3()
        {
            dynamic items = new List<int> { 1, 2, 3 };
            dynamic valueToAdd = 4;
            foreach (dynamic item in items)
            {
                string result = item + valueToAdd;
                Console.WriteLine(result);
            }
        }

        public static void Demo4()
        {
            dynamic items = new List<int> { 1, 2, 3 };
            dynamic valueToAdd = 4;
            foreach (dynamic item in items)
            {
                Console.WriteLine(item + valueToAdd);
            }
        }

        public static void Demo5()
        {
            string str = "string hello"; // Strongly typed
            string uStr = str.ToUpper(); // Statically types

            var vStr = "var hello";           // Strongly typed
            string vUpperStr = str.ToUpper(); // Statically typed

            object oStr = "object hello";   // Weakly typed
            // No intellisense and doesn't compile
            string oUpperStr = oStr.ToUpper(); // Statically typed

            dynamic dStr = "dynamic hello"; // Weakly typed
            // No intellisense but compiler is happy
            string dUpperString = dStr.ToUpper(); // Dynamically typed
        }
    }
}
