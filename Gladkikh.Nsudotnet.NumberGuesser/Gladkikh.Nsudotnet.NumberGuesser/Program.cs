using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladkikh.Nsudotnet.NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter you name, bitch");
            String name = Console.ReadLine();
            Console.WriteLine("Hi, " + name);
            Random random = new Random();
            int unknownNumber = random.Next(0, 101);
            bool guessed = false;
            List<String> history = new List<string>(1000);
            String[] message =
            {
                "You miserable little puke",
                "You are guaranteed hemorrhoids",
                "You’re Stoneball",
                "Get the fuck out of here before I break your jaw"
            };
            Stopwatch time = new Stopwatch();
            time.Start();
            int count = 0;
            Console.WriteLine("Input number, bitch");
            while (!guessed)
            {
                for (var i = 0; i < 4; i++)
                {
                    String answer = Console.ReadLine();
                    if (answer.Contains("q"))
                    {
                        Console.WriteLine("Sorry, " + name);
                        guessed = true;
                        Environment.Exit(0);
                    }
                    else
                    {
                        int userNumber = int.Parse(answer);
                        count++;
                        if (userNumber < unknownNumber)
                        {
                            Console.WriteLine("Your number is less than the specified");
                            history.Add(userNumber + " less");
                        }
                        else
                        {
                            if (userNumber > unknownNumber)
                            {
                                Console.WriteLine("Your number is greater than the specified");
                                history.Add(userNumber + " greater");
                            }
                            else
                            {
                                guessed = true;
                                time.Stop();
                                history.Add(userNumber + " that number was guessed");
                                Console.WriteLine("NOT BAD, " + name + "\n" + "The number of attempts: " + count + "\n" + "Your time: " + time.Elapsed.Minutes);
                                int size = history.Count;
                                for (var j = 0; j < size; j++)
                                {
                                    Console.WriteLine(history.First());
                                    history.RemoveAt(0);
                                }
                                break;
                            }
                        }
                    }
                }
                if (!guessed)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine(message[random.Next(0, 4)] + ", " + name);
                }

            }
            Console.ReadLine();
        }
    }
}
