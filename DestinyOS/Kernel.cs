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
            public const string vere = "0.7";
            public const string col = "Green";
        }
        public static ConsoleColor SystemColor;

        private static Dictionary<string, CommandDefinition> CommandDefinitions = new Dictionary<string, CommandDefinition>();

        public class CommandDefinition
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Syntax { get; set; }
            public string Example { get; set; }
            public Action<string> Execute { get; set; }

            public CommandDefinition(string name, string description, string syntax, string example, Action<string> execute)
            {
                Name = name;
                Description = description;
                Syntax = syntax;
                Example = example;
                Execute = execute;
            }
        }

        protected override void BeforeRun()
        {
            SystemColor = ParseColor(VeRsii.col);
            InitializeCommands();

            string vers = VeRsii.vere;
            Console.Clear();
            Console.ForegroundColor = SystemColor;
            Console.WriteLine("  _____            _   _              ____   _____ ");
            Console.WriteLine(" |  __ \\          | | (_)            / __ \\ / ____|");
            Console.WriteLine(" | |  | | ___  ___| |_ _ _ __  _   _| |  | | (___  ");
            Console.WriteLine(" | |  | |/ _ \\/ __| __| | '_ \\| | | | |  | |\\___ \\");
            Console.WriteLine(" | |__| |  __/\\__ \\ |_| | | | | |_| | |__| |____) |");
            Console.WriteLine(" |_____/ \\___||___/\\__|_|_| |_|\\__, |\\____/|_____/ ");
            Console.WriteLine("                                __/ |              ");
            Console.WriteLine("                               |___/               ");
            Console.WriteLine($"Welcome to DestinyOS! V{vers}");
            Console.WriteLine("Type help and press enter for help!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void InitializeCommands()
        {
            RegisterCommand("clear", "Clears the console", "clear or clr", "clear", (args) => {
                Console.Clear();
            });

            RegisterCommand("clr", "Clears the console", "clear or clr", "clr", (args) => {
                Console.Clear();
            });
            RegisterCommand("about", "Shows info about DestinyOS", "about", "about", (arg) =>
            {
                string vers = VeRsii.vere;
                Console.WriteLine("DestinyOS");
                Console.WriteLine("Created by LazerKat");
                Console.WriteLine("Built on the CosmosOS kernal");
                Console.WriteLine($"Version {vers}");
                Console.WriteLine("Please check out my GitHub at betelguesestudios :)");
                Console.WriteLine("Made during Stardance");
                Console.WriteLine("There are easter eggs!");
            });
            RegisterCommand("hectarelitre", "hectarelitre", "hectarelitre", "hectarelitre", (arg) =>
            {
                Console.WriteLine("hectarelitre");
                Console.WriteLine("austin");
                Console.WriteLine(arg);
                Console.WriteLine("potential?");
            });
            
            RegisterCommand("echo", "Repeats anything you put after it", "echo <text>", "echo hi!", (arg) =>
            {
                Console.WriteLine(arg);
            });
            RegisterCommand("wow", "Gives inspirational quotes", "wow", "wow", (args) => {
                Random rnd = new Random();
                int randomNumber = rnd.Next(11);
                if (randomNumber == 0)
                {
                    Console.WriteLine("The only impossible journey is the one you never begin. - Tony Robbins");
                }
                else if (randomNumber == 1)
                {
                    Console.WriteLine("The most difficult thing is the decision to act, the rest is merely tenacity. - Amelia Earhart");
                }
                else if (randomNumber == 2)
                {
                    Console.WriteLine("Only I can change my life. No one can do it for me. - Carol Burnett");
                }
                else if (randomNumber == 3)
                {
                    Console.WriteLine("A good plan violently executed now is better than a perfect plan executed next week. - George S. Patton");
                }
                else if (randomNumber == 4)
                {
                    Console.WriteLine("Either you run the day or the day runs you. - Jim Rohn");
                }
                else if (randomNumber == 5)
                {
                    Console.WriteLine("Failure will never overtake me if my determination to succeed is strong enough. - Og Mandino");
                }
                else if (randomNumber == 6)
                {
                    Console.WriteLine("Aim for the moon. If you miss, you may hit a star. - W. Clement Stone");
                }
                else if (randomNumber == 7)
                {
                    Console.WriteLine("I ended up being airborne for over 5 minutes, that's how I got the nickname Ross. - Ross Federman");
                }
                else if (randomNumber == 8)
                {
                    Console.WriteLine("Expect problems and eat them for breakfast. - Alfred A. Montapert");
                }
                else if (randomNumber == 9)
                {
                    Console.WriteLine("Change your life today. Don't gamble on the future, act now, without delay. - Simone de Beauvoir");
                }
                else if (randomNumber == 10)
                {
                    Console.WriteLine("egghead is sigma - LazerKat");
                }
                else
                {
                    Console.WriteLine("Error! Something happened and randomness dosen't work!");
                }
            });

            RegisterCommand("test", "Tests system functionality and beep", "test", "test", (args) => {
                Console.ForegroundColor = SystemColor;
                Console.WriteLine("This is a test!");

                try
                {
                    Console.Beep();
                    Console.WriteLine("The system beeped successfully!");
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Beep not supported on this system!");
                }

                Console.ForegroundColor = SystemColor;
                Console.WriteLine("Only works on Windows drivers");
                Console.ForegroundColor = ConsoleColor.White;
            });

            RegisterCommand("help", "Shows this help menu", "help", "help", (args) => {
                VeRsii.page = 1;
                ShowHelp(VeRsii.page);
            });

            RegisterCommand("next", "Shows next page of help", "next", "next", (args) => {
                VeRsii.page++;
                ShowHelp(VeRsii.page);
            });

            RegisterCommand("prev", "Shows previous page of help", "prev", "prev", (args) => {
                VeRsii.page--;
                ShowHelp(VeRsii.page);
            });

            RegisterCommand("shutdown", "Shuts down the system", "shutdown", "shutdown", (args) => {
                Cosmos.System.Power.Shutdown();
            });

            RegisterCommand("reboot", "Reboots the system", "reboot", "reboot", (args) => {
                Cosmos.System.Power.Reboot();
            });

            RegisterCommand("cpuinf", "Displays CPU information", "cpuinf", "cpuinf", (args) => {
                Console.ForegroundColor = SystemColor;
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
            });

            RegisterCommand("raminf", "Displays RAM information", "raminf", "raminf", (args) => {
                Console.ForegroundColor = SystemColor;
                uint amount = Cosmos.Core.CPU.GetAmountOfRAM();
                Console.WriteLine("RAM Amount (in MB): " + (amount + 2).ToString());
                Console.ForegroundColor = ConsoleColor.White;
            });

            RegisterCommand("tune", "Plays a cool tune", "tune", "tune", (args) => {
                Console.ForegroundColor = SystemColor;
                Console.WriteLine("Playing tune...");

                int[] notes = { 262, 294, 330, 349, 392, 440, 494, 523 };
                int duration = 300;

                try
                {
                    foreach (int note in notes)
                    {
                        Console.Beep(note, duration);
                        System.Threading.Thread.Sleep(50);
                    }
                    Console.WriteLine("Tune completed!");
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Beep not supported on this system!");
                }

                Console.ForegroundColor = ConsoleColor.White;
            });

            RegisterCommand("stscr", "Displays the startup screen", "stscr", "stscr", (args) => {
                Console.ForegroundColor = SystemColor;
                Console.WriteLine("  _____            _   _              ____   _____ ");
                Console.WriteLine(" |  __ \\          | | (_)            / __ \\ / ____|");
                Console.WriteLine(" | |  | | ___  ___| |_ _ _ __  _   _| |  | | (___  ");
                Console.WriteLine(" | |  | |/ _ \\/ __| __| | '_ \\| | | | |  | |\\___ \\");
                Console.WriteLine(" | |__| |  __/\\__ \\ |_| | | | | |_| | |__| |____) |");
                Console.WriteLine(" |_____/ \\___||___/\\__|_|_| |_|\\__, |\\____/|_____/ ");
                Console.WriteLine("                                __/ |              ");
                Console.WriteLine("                               |___/               ");
                Console.WriteLine($"Welcome to DestinyOS! V{VeRsii.vere}");
                Console.WriteLine("Type help and press enter for help!");
                Console.ForegroundColor = ConsoleColor.White;
            });

            RegisterCommand("concol", "Changes console color", "concol [color] or concol", "concol green", (args) => {
                if (!string.IsNullOrEmpty(args))
                {
                    ConsoleColor newColor = ParseColor(args);

                    if (newColor != ConsoleColor.White || args.ToLower().Trim() == "white")
                    {
                        SystemColor = newColor;
                        Console.ForegroundColor = SystemColor;
                        Console.WriteLine($"System color changed to {args}!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid color name! Try: Black, Blue, Green, Red, Yellow, White, etc.");
                    }
                }
                else
                {
                    Console.ForegroundColor = SystemColor;
                    Console.Write("Enter color name: ");
                    Console.ForegroundColor = ConsoleColor.White;

                    string colo = Console.ReadLine();

                    Console.ForegroundColor = SystemColor;

                    if (!string.IsNullOrEmpty(colo))
                    {
                        ConsoleColor newColor = ParseColor(colo);

                        if (newColor != ConsoleColor.White || colo.ToLower().Trim() == "white")
                        {
                            SystemColor = newColor;
                            Console.WriteLine($"System color changed to {colo}!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid color name! Try: Black, Blue, Green, Red, Yellow, White, etc.");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No color entered!");
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
            });

            RegisterCommand("helpc", "Shows detailed help for a specific command", "helpc <command>", "helpc clear", (args) => {
                if (string.IsNullOrEmpty(args))
                {
                    Console.ForegroundColor = SystemColor;
                    Console.WriteLine("Usage: helpc <command>");
                    Console.WriteLine("Example: helpc clear");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                string cmdName = args.ToLower().Trim();
                if (CommandDefinitions.ContainsKey(cmdName))
                {
                    var cmd = CommandDefinitions[cmdName];
                    Console.ForegroundColor = SystemColor;
                    Console.WriteLine($"=== Command: {cmd.Name} ===");
                    Console.WriteLine($"Description: {cmd.Description}");
                    Console.WriteLine($"Syntax: {cmd.Syntax}");
                    Console.WriteLine($"Example: {cmd.Example}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Command '{args}' not found!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            });
        }

        private void RegisterCommand(string name, string description, string syntax, string example, Action<string> execute)
        {
            CommandDefinitions[name.ToLower()] = new CommandDefinition(name, description, syntax, example, execute);
        }

        protected override void Run()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("home:/");
            Console.ForegroundColor = ConsoleColor.White;
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            if (input.Contains("&&"))
            {
                string[] commands = input.Split(new string[] { "&&" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string cmd in commands)
                {
                    string trimmedCmd = cmd.Trim();
                    if (!string.IsNullOrEmpty(trimmedCmd))
                    {
                        ExecuteCommand(trimmedCmd);
                    }
                }
            }
            else
            {
                ExecuteCommand(input);
            }
        }

        private void ExecuteCommand(string input)
        {
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = parts[0].ToLower();
            string arguments = parts.Length > 1 ? string.Join(" ", parts, 1, parts.Length - 1) : "";

            if (CommandDefinitions.ContainsKey(command))
            {
                CommandDefinitions[command].Execute(arguments);
            }
            else
            {
                Console.ForegroundColor = SystemColor;
                Console.Write("Command not found: ");
                Console.WriteLine(input);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static ConsoleColor ParseColor(string colorName)
        {
            if (string.IsNullOrEmpty(colorName))
                return ConsoleColor.White;

            string lowerColor = colorName.ToLower().Trim();

            switch (lowerColor)
            {
                case "black": return ConsoleColor.Black;
                case "darkblue": return ConsoleColor.DarkBlue;
                case "darkgreen": return ConsoleColor.DarkGreen;
                case "darkcyan": return ConsoleColor.DarkCyan;
                case "darkred": return ConsoleColor.DarkRed;
                case "darkmagenta": return ConsoleColor.DarkMagenta;
                case "darkyellow": return ConsoleColor.DarkYellow;
                case "gray": return ConsoleColor.Gray;
                case "darkgray": return ConsoleColor.DarkGray;
                case "blue": return ConsoleColor.Blue;
                case "green": return ConsoleColor.Green;
                case "cyan": return ConsoleColor.Cyan;
                case "red": return ConsoleColor.Red;
                case "magenta": return ConsoleColor.Magenta;
                case "yellow": return ConsoleColor.Yellow;
                case "white": return ConsoleColor.White;
                default:
                    return ConsoleColor.White;
            }
        }

        public static string ShowHelp(int page)
        {
            Console.ForegroundColor = SystemColor;
            string vers = VeRsii.vere;

            if (page == 1)
            {
                Console.WriteLine($"Help for DestinyOS V{vers}");
                Console.WriteLine("Page 1");
                Console.WriteLine("helpc - Get help on a certain command (can run helpc <command>)");
                Console.WriteLine("test - TEST (try beep)");
                Console.WriteLine("clear or clr - Clears console");
                Console.WriteLine("help - This page");
                Console.WriteLine("next - Next page of commands");
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
            else if (page == 2)
            {
                Console.WriteLine($"Help for DestinyOS V{vers}");
                Console.WriteLine("Page 2");
                Console.WriteLine("prev - Previous page of commands");
                Console.WriteLine("shutdown - Shuts down the system");
                Console.WriteLine("reboot - Reboots the system");
                Console.WriteLine("cpuinf - Gets info about the CPU");
                Console.WriteLine("tune - A tune to test speakers! (may not work)");
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
            else if (page == 3)
            {
                Console.WriteLine($"Help for DestinyOS V{vers}");
                Console.WriteLine("Page 3");
                Console.WriteLine("stscr - Displays the screen that appears on boot");
                Console.WriteLine("raminf - Gets info about the RAM");
                Console.WriteLine("concol - Sets console color (can also run concol <color>)");
                Console.WriteLine("&& - Run two or more commands at once eg. stscr && cpuinf");
                Console.WriteLine("wow - Words Of Wisdom");
                
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
            else if (page == 4)
            {
                Console.WriteLine($"Help for DestinyOS V{vers}");
                Console.WriteLine("Page 4");
                Console.WriteLine("echo - Repeats the text input");
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