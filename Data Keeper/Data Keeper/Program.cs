using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Keeper
{
    class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            {
                try
                {
                    Code();
                }

                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Whoops, something went wrong!");
                    Console.WriteLine(e);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }

        public static void Code()
        {
            Console.WriteLine("Welcome to the Data Keeper!");
            Console.WriteLine(" Type 'r' to read currently kept data.\n Type 'c' to create new data.\n Type 'd' to delete all data.");

            for (; ; )
            {
                switch (Input())
                {
                    case "r":
                        if (File.Exists("data.txt"))
                        {
                            string[] data = File.ReadAllLines("data.txt");
                            Line();
                            foreach (string s in data)
                            {
                                Console.WriteLine(s);
                            }
                            Line();
                        }
                        else
                            Console.WriteLine(" No data is stored. Start NOW!");
                        break;

                    case "c":
                        Console.WriteLine(" Please input the data you want to keep.");
                        File.AppendAllText("data.txt", Input() + "\n");
                        Console.WriteLine(" Successfully added to data file.");
                        break;

                    case "d":
                        if (File.Exists("data.txt"))
                        {
                            Console.WriteLine(" Are you sure you want to delete all the data you have saved? (y/n)");
                            if (Input() == "y")
                            {
                                Console.WriteLine(" Your data saved before it all vanishes:");
                                string[] data = File.ReadAllLines("data.txt");
                                Line();
                                foreach (string s in data)
                                {
                                    Console.WriteLine(s);
                                }
                                Line();

                                File.Delete("data.txt");
                                Console.WriteLine(" Your data has vanished into thin air.");
                            }
                            else
                                Console.WriteLine(" You data still exists.");
                        }
                        else
                        {
                            Console.WriteLine(" You have no data. Start NOW!");
                        }

                        break;

                    default:
                        Console.WriteLine(" Type 'r' to read currently kept data.\n Type 'c' to create new data.\n Type 'd' to delete all data.");
                        break;
                }
            }
        }

        public static string Input()
        {
            Console.Write("> ");
            return Console.ReadLine();
        }

        public static void Line()
        {
            for (int i = 1; i < Console.WindowWidth; i++)
                Console.Write("-");
            Console.WriteLine();
        }
    }
}
