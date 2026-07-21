using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.System.FileSystem.VFS;
using Sys = Cosmos.System;

namespace DestinyOS
{
    public class Kernel : Sys.Kernel
    {
        public class VeRsii
        {
            public static int page = 1;
            public const string vere = "0.5";
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
                Console.WriteLine("The program should have beeped");
                Console.WriteLine("Only works on windows drivers");
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
            else if (input == "shutdown")
            {
                Cosmos.System.Power.Shutdown();
            }
            else if (input == "reboot")
            {
                Cosmos.System.Power.Reboot();
            }
            else if (input == "cpuinf")
            {
                string vendorr = Cosmos.Core.CPU.GetCPUVendorName();
                string bradns = Cosmos.Core.CPU.GetCPUBrandString();
                string speed = Cosmos.Core.CPU.GetCPUCycleSpeed().ToString();
                Console.WriteLine("CPU Vendor: " + vendorr);
                Console.WriteLine("CPU Brand:  " + bradns);
                Console.WriteLine("CPU Speed: " + speed);
            }
            else if (input == "tune")
            {
                int[] notes = { 262, 294, 330, 349, 392, 440, 494, 523 };
                int duration = 300;
                foreach (int note in notes)
                {
                    Console.Beep(note, duration);
                    System.Threading.Thread.Sleep(50);
                }
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
                Console.WriteLine("next - Next page of commands");
                Console.WriteLine("prev - Previous page of commands");
                return "";
            }
            else if (page == 2)
            {
                Console.WriteLine($"Help for DestinyOS V{vers}");
                Console.WriteLine("Page 2");
                Console.WriteLine("shutdown - Shuts down the system");
                Console.WriteLine("reboot - Reboots the system");
                Console.WriteLine("cpuinf - Gets info about the CPU");
                Console.WriteLine("tune - A tune to test speakers! (only works with windows drivers)");
                return "";
            }
            else if (page == 3)
            {
                Console.WriteLine("page 3");
                return "";
            }
            else
            {
                Console.WriteLine("Not a page! Please go back to the last page");
                return "";
            }
        }
    }
}