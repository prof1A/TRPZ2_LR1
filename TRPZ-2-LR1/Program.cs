using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;

namespace TRPZ_2_LR1
{
    class Program
    {
        static void Main(string[] args)
        {
            Train train = new Train();
            train.Passengers.AddRange(
                    new List<Passenger>()
                    {
                        new Passenger{Name = "John Doe"},
                        new Passenger{Name = "Tyler Durden"},
                        new Passenger{Name = "John Travolta"},
                        new Passenger{Name = "Mukuta"},
                        new Passenger{Name = "Arthur Glack"},
                        new Passenger{Name = "Andrey Patau"}
                    }
                );

            int selectedCommand = 1;
            while (true)
            {
                if (train.Running)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("train is moving");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("train is standing");
                    Console.ResetColor();
                }

                Console.WriteLine($"Speed: {train.Speed}");
                Console.WriteLine($"Stops: {train.StopsCount}");
                Console.WriteLine($"Passengers amount: {train.Passengers.Count}");
                Console.WriteLine();
                if (train.Running)
                {
                    if (selectedCommand == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Increase speed");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Increase speed");
                    }

                    if (selectedCommand == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Decrease speed");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Decrease speed");
                    }

                    if (selectedCommand == 3)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Stop train");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Stop train");
                    }
                    
                }
                else
                {
                    if (selectedCommand == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Add passengers");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Add passengers");
                    }

                    if (selectedCommand == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Remove passengers");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Remove passengers");
                    }

                    if (selectedCommand == 3)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Run train");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Run train");
                    }
                }

                var key = Console.ReadKey();
                Console.Clear();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (selectedCommand < 3)
                    {
                        selectedCommand++;
                    }
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (selectedCommand > 1)
                    {
                        selectedCommand--;
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    try
                    {
                        if (train.Running)
                        {
                            switch (selectedCommand)
                            {
                                case 1:
                                    Console.WriteLine("Enter speed you want to increase: ");
                                    var amountincr = Convert.ToInt32(Console.ReadLine());
                                    train.IncreaseSpeed(amountincr);
                                    break;
                                case 2:
                                    Console.WriteLine("Enter speed you want to decrease: ");
                                    var amountdecr = Convert.ToInt32(Console.ReadLine());
                                    train.DecreaseSpeed(amountdecr);
                                    break;
                                case 3:
                                    train.Stop();
                                    break;
                            }
                        }
                        else
                        {
                            switch (selectedCommand)
                            {
                                case 1:
                                    Console.WriteLine("Enter passenger's count you want to add: ");
                                    var amountPass = Convert.ToInt32(Console.ReadLine());
                                    train.AddPassengers(amountPass);
                                    break;
                                case 2:
                                    Console.WriteLine("Enter speed you want to decrease: ");
                                    var amountPassDel = Convert.ToInt32(Console.ReadLine());
                                    train.RemovePassengers(amountPassDel);
                                    break;
                                case 3:
                                    train.Run();
                                    break;
                            }
                        }

                        Console.Clear();
                    }
                    catch (TrainException ex)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                        Thread.Sleep(5000);
                    }
                }
            }
        }
    }
}
