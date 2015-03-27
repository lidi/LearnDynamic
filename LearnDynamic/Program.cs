using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;


namespace LearnDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo1();
            //Demo2();
            //Demo3();
            //Demo4();
            //DemoExcelWithCasting();
            //DemoExcelWithConversionNoCasting();
            //DemoExcelPurelyDynamic();
            IronPythonExample();
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
            string vUpperStr = vStr.ToUpper(); // Statically typed

            object oStr = "object hello";   // Weakly typed
            // No intellisense and doesn't compile
            //string oUpperStr = oStr.ToUpper(); // Statically typed

            dynamic dStr = "dynamic hello"; // Weakly typed
            // No intellisense but compiler is happy
            string dUpperString = dStr.ToUpper(); // Dynamically typed
        }

        //With the primary interop assembly set to embed the required types into your own
        //binary, all of these examples become dynamic. With the implicit conversion from
        //dynamic to other types, you can remove all the casts, as shown in the following listing
        public static void DemoExcelWithConversionNoCasting() {
            var app = new Application { Visible = true };
            app.Workbooks.Add();
            Worksheet worksheet = app.ActiveSheet;
            Range start = worksheet.Cells[1, 1];
            Range end = worksheet.Cells[1, 20];
            worksheet.Range[start, end].Value = Enumerable.Range(1, 20).ToArray();
        }

        public static void DemoExcelWithCasting()
        {
            var app = new Application { Visible = true };
            app.Workbooks.Add();
            Worksheet worksheet = (Worksheet) app.ActiveSheet;
            Range start = (Range) worksheet.Cells[1, 1];
            Range end = (Range) worksheet.Cells[1, 20];
            //Range middle = worksheet.
            worksheet.Range[start, end].Value = Enumerable.Range(1, 20).ToArray();
        }

        //Pros: 
        //no need to work out which particular type you
        //expect; you can just use the value, and as long as all the necessary operations are supported,
        //you’re okay
        //Cons:
        //No intellisense
        public static void DemoExcelPurelyDynamic()
        {
            var app = new Application { Visible = true };
            app.Workbooks.Add();
            dynamic worksheet = app.ActiveSheet;
            dynamic start = worksheet.Cells[1, 1];
            dynamic end = worksheet.Cells[1, 20];
            //dynamic middle = worksheet.
            worksheet.Range[start, end].Value = Enumerable.Range(1, 20).ToArray();
        }

        public static void IronPythonExample() {
            var options = new Dictionary<string, object>();
            options["Frames"] = true;
            options["FullFrames"] = true;
            ScriptEngine engine = Python.CreateEngine(options);
            var paths = engine.GetSearchPaths();
            paths.Add("C:/Users/lidi/Documents/Visual Studio 2013/Projects/IronPythonDemo/IronPythonDemo/env/Lib");
            engine.SetSearchPaths(paths);
            engine.ExecuteFile("GithubDemo.py");
        }
    }
}
