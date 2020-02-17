using System;
using System.Collections.Generic;

namespace MarsRover
{
    class Program
    {
        private static List<Rover> rovers;
        static void Main(string[] args)
        {
            rovers = new List<Rover>();
            while (true)
            {
                try
                {
                    Console.WriteLine("1. Add a new Rover \n" +
                                      "2. Update a Rover \n" +
                                      "3. Delete a Rover \n" +
                                      "4. Run Rovers \n" +
                                      "5. Show Results \n" +
                                      "6. Exit");

                    Console.Write("Please make a choise: ");
                    int selection = Convert.ToInt32(Console.ReadLine());

                    switch (selection)
                    {
                        case 1:
                            AddRover();
                            break;
                        case 2:
                            if (rovers.Count > 0)
                                UpdateRover();
                            break;
                        case 3:
                            if (rovers.Count > 0)
                                DeleteRover();
                            break;
                        case 4:
                            if (rovers.Count > 0)
                                RunCommands();
                            break;
                        case 5:
                            if (rovers.Count > 0)
                                ShowResults();
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("You made the wrong choice, try again.");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("On error occured.");
                    continue;
                }
            }
        }

        /// <summary>
        /// Add a new rover
        /// </summary>
        static void AddRover()
        {
            try
            {
                Console.Write("Add a new rover with X,Y Direction, for example 1,2 N : ");
                string roverParams = Console.ReadLine();
                string[] paramsContainer = roverParams.Split(' ');
                string[] coordinates = paramsContainer[0].Split(',');
                rovers.Add(new Rover(Convert.ToByte(coordinates[0]), Convert.ToByte(coordinates[1]), Enum.Parse<Direction>(paramsContainer[1])));
                Console.WriteLine("Rover added succesfully");
            }
            catch
            {
                Console.WriteLine("On error occured. Try again.");
            }
        }

        /// <summary>
        /// Update a rover
        /// </summary>
        static void UpdateRover()
        {
            try
            {
                int index = ListRovers();
                Console.Write("Update a rover with X,Y Direction, for example 1,2 N : ");
                string roverParams = Console.ReadLine();
                string[] paramsContainer = roverParams.Split(' ');
                string[] coordinates = paramsContainer[0].Split(',');
                rovers[index].pointX = Convert.ToByte(coordinates[0]);
                rovers[index].pointY = Convert.ToByte(coordinates[1]);
                rovers[index].facing = Enum.Parse<Direction>(paramsContainer[1]);
                Console.WriteLine("Rover updated succesfully");
            }
            catch
            {
                Console.WriteLine("On error occured. Try again.");
            }
        }

        /// <summary>
        /// Delete a rover
        /// </summary>
        static void DeleteRover()
        {
            try
            {
                int index = ListRovers();
                rovers.RemoveAt(index);
                Console.WriteLine("Rover deleted succesfully");
            }
            catch
            {
                Console.WriteLine("On error occured. Try again.");
            }
        }

        /// <summary>
        /// List all rover and select a one rover return rover index.
        /// </summary>
        /// <returns></returns>
        static int ListRovers()
        {
            foreach (Rover item in rovers)
            {
                Console.WriteLine($"{rovers.IndexOf(item)}. Rover {item.roverId.ToString().Substring(0, 6)}: {item.pointX},{item.pointY} {item.facing.ToString()}");
            }
            Console.Write("Select a Rover: ");
            int index = Convert.ToInt32(Console.ReadLine());
            return index;
        }

        /// <summary>
        /// Run a command each rover.
        /// </summary>
        static void RunCommands()
        {
            foreach (Rover item in rovers)
            {
                Console.Write($"Enter a command pattern for Rover {item.roverId.ToString().Substring(0, 6)}: ");
                string command = Console.ReadLine();
                item.RunCommand(command);
            }
        }

        /// <summary>
        /// Show all rovers result
        /// </summary>
        static void ShowResults()
        {
            Console.WriteLine("----- Results -----");
            foreach (Rover item in rovers)
            {
                Console.WriteLine($"Rover {item.roverId.ToString().Substring(0, 6)}: {item.pointX},{item.pointY} {item.facing.ToString()}");
            }

            Console.WriteLine("Press any key and continue...");
            Console.ReadKey();
        }
    }
}
