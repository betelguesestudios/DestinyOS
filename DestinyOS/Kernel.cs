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
            public static string vere = "0.2";
        }
        protected override void BeforeRun()
        {
            string vers = VeRsii.vere;
            Console.Clear();
            Console.WriteLine($"Welcome to DestinyOS! V{vers}");
        }

        protected override void Run()
        {
            string vers = VeRsii.vere;
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
                Console.WriteLine($"Help for DestinyOS V{vers}");
            }
            else
            {
                Console.Write("Command not found: ");
                Console.WriteLine(input);
            }
        }
    }
}
