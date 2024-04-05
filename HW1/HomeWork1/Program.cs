using System;
using System.Diagnostics;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my C# program");
            Console.WriteLine("This is my first homework\n");

            int input;

            do
            {
                Console.WriteLine("What do you want to do? Enter a number:");
                Console.WriteLine("1. Run a specific process\nmspaint مثلا");
                Console.WriteLine("2. List all processes");
                Console.WriteLine("3. Kill a process");
                Console.WriteLine("4. Display process handles");
                Console.WriteLine("0. Exit");

                
                input = Convert.ToInt32(Console.ReadLine());

                
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Enter the name of the process you want to run:");
                        string processName = Console.ReadLine();
                        Process.Start(processName);
                        break;
                    case 2:
                        Process[] processList = Process.GetProcesses();
                        foreach (Process p in processList)
                        {
                            Console.WriteLine(p.Id + "\t" + p.ProcessName);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter the ID of the process you want to kill:");
                        int pid = Convert.ToInt32(Console.ReadLine());
                        Process.GetProcessById(pid).Kill();
                        break;
                    case 4:
                        Console.WriteLine("Please enter process name:");
                        string procName = Console.ReadLine();
                        Process[] processes = Process.GetProcessesByName(procName);
                        foreach(Process process in processes)
                        {
                            Console.WriteLine($"{process.Handle}");
                        }
                        break;
                    case 0:
                        Console.WriteLine("Exiting program...");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a number between 0 and 4.");
                        break;
                }

                
                Console.WriteLine();
            }
            while (input != 0); 
        }
    }
}
