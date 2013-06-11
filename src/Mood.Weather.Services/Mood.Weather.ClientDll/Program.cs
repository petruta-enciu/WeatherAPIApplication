using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mood.Weather.ClientDll
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome MoodWeatherClient, type help to get some help!");
            while (true)
            {
                Console.Write("> ");

                string input = Console.ReadLine();

                int commandEndIndex = input.IndexOf(' ');

                string command;
                string commandParameters = string.Empty;

                if (commandEndIndex > -1)
                {
                    command = input.Substring(0, commandEndIndex);
                    commandParameters = input.Substring(commandEndIndex + 1, input.Length - commandEndIndex - 1);
                }
                else
                {
                    command = input;
                }

                command = command.ToUpper();

                switch (command)
                {
                    case "EXIT":
                        {
                            return;
                        }
                    case "HELP":
                        {
                            Console.WriteLine("- enter EXIT to exit this application");
                            Console.WriteLine("- enter CLS to clear the screen");
                            Console.WriteLine( "- enter WEATHER<countrycode/cityname> to get  weather condition (ex:WEATHER France/Paris) ");
                            break;
                        }
                    case "CLS":
                        {
                            Console.Clear();
                            break;
                        }

                    case "WEATHER":
                        {
                            try
                            {
                                Console.WriteLine(commandParameters.Split());
                            }
                            catch
                            {
                                Console.WriteLine("!!! Parameter not valid");
                            }

                            break;
                        }
                  
                    default:
                        {
                            Console.WriteLine("!!! Bad command");
                            break;
                        }
                }
            }
        }
    }
}