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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome to DestinyOS! V{vers}");
            Console.WriteLine("Type help and press enter for help!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        protected override void Run()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("home:/");
            Console.ForegroundColor = ConsoleColor.White;
            var input = Console.ReadLine();
            if (input == "clear" || input == "clr")
            {
                Console.Clear();
            }
            else if (input == "test")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("This is a test!");
                Console.Beep();
                Console.WriteLine("The program should have beeped");
                Console.WriteLine("Only works on windows drivers");
                Console.ForegroundColor = ConsoleColor.White;
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
                Console.ForegroundColor = ConsoleColor.Green;
                string vendorr = Cosmos.Core.CPU.GetCPUVendorName();
                string bradns = Cosmos.Core.CPU.GetCPUBrandString();

                string speedDisplay = "Unknown";

                if (bradns != null && bradns.Contains("@"))
                {
                    string rawSpeedPart = bradns.Split('@')[1];

                    speedDisplay = rawSpeedPart.Trim();
                }

                Console.WriteLine("CPU Vendor: " + vendorr);
                Console.WriteLine("CPU Brand:  " + bradns);
                Console.WriteLine("CPU Speed:  " + speedDisplay);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (input == "raminf")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                uint amount = Cosmos.Core.CPU.GetAmountOfRAM();
                Console.WriteLine("RAM Amount (in MB): " + (amount + 2).ToString());

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
            else if (input == "stscr")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Welcome to DestinyOS! V{VeRsii.vere}");
                Console.WriteLine("Type help and press enter for help!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Command not found: ");
                Console.WriteLine(input);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static string SHowhelp(int page)
        {
            Console.ForegroundColor = ConsoleColor.Green;
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
                Console.ForegroundColor = ConsoleColor.White;
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
                Console.WriteLine("stscr - Displays the screen that appears on boot");
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
            else if (page == 3)
            {
                Console.WriteLine($"Help for DestinyOS V{vers}");
                Console.WriteLine("Page 3");
                Console.WriteLine("raminf - Gets info about the RAM");
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
            else
            {
                Console.WriteLine("Not a page! Please go back to the last page");
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
            
        }
    }
}