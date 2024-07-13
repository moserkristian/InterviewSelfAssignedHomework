using BestPractices.Classes;

namespace BestPractices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IDemo> demos = new List<IDemo>
            {
                new ParallelDemo(),
                new SpanDemo(),
                new ThreadPoolDemo(),
                new Inheritance()
                // Add new demos here
            };

            while (true)
            {
                Console.WriteLine("Please select a method to execute:");
                for (int i = 0; i < demos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}, {demos[i].Description}");
                }
                Console.WriteLine("0, Exit");
                Console.Write("Enter your choice as number (1): ");

                // Read user input
                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    if (choice == 0)
                    {
                        Console.WriteLine("Exiting...");
                        return;
                    }

                    if (choice > 0 && choice <= demos.Count)
                    {
                        demos[choice - 1].Execute();
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                Console.WriteLine($"\n{new string('-', 100)}\n"); // Add for better readability
            }
        }
    }
}
