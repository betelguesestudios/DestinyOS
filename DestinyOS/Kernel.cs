using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace DestinyOS
{
    public class Kernel : Sys.Kernel
    {
        public class VeRsii
        {
            public static int page = 1;
            public const string vere = "0.2";
        }
        protected override void BeforeRun()
        {
            string vers = VeRsii.vere;
            Console.Clear();
            Console.WriteLine($"Welcome to DestinyOS! V{vers}");
            Console.WriteLine("Type help and press enter for help!");
        }

        protected override void Run()
        {
            Console.Write("home:/");
            var input = Console.ReadLine();
            if (input == "clear" || input == "clr")
            {
                Console.Clear();
            }
            else if (input == "test")
            {
                Console.WriteLine("This is a test!");
                Console.Beep();
            }
            else if (input == "help")
            {
                VeRsii.page = 1;
                SHowhelp(VeRsii.page);
            }
            else if (input == "next")
            {
                VeRsii.page++;
                SHowhelp(VeRsii.page);
            }
            else if (input == "prev")
            {
                VeRsii.page--;
                SHowhelp(VeRsii.page);
            }
            else
            {
                Console.Write("Command not found: ");
                Console.WriteLine(input);
            }
        }
        public static string SHowhelp(int page)
        {
            string vers = VeRsii.vere;
            if (page == 1)
            {
                Console.WriteLine($"Help for DestinyOS V{vers}");
                Console.WriteLine("Page 1");
                Console.WriteLine("test - TEST");
                Console.WriteLine("clear or clr - Clears console");
                Console.WriteLine("help - This page");
                return "";
            }
            else if (page == 2)
            {
                Console.WriteLine("page 2");
                return "";
            }
            else if (page == 3)
            {
                Console.WriteLine("page 3");
                return "";
            }
            else
            {
                Console.WriteLine("not a page!");
                return "";
            }
        }
    }
}
