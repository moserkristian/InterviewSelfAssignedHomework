using BestPractices.Classes;

namespace BestPractices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please select a method to execute:");
                Console.WriteLine("1, Parallel Programming Demo ( ExecuteParallelSum )");
                Console.WriteLine("2, Span Usage Demo ( DemonstrateSpanUsage )");
                Console.WriteLine("3, ThreadPool Demo ( ExecuteThreadPoolTasks )");

                Console.WriteLine("0, Exit");
                Console.Write("Enter your choice as number (1) : ");

                // Read user input
                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 0:
                            Console.WriteLine("Exiting...");
                            return;
                        case 1:
                            ParallelDemo.ExecuteParallelSum();
                            break;
                        case 2:
                            SpanDemo.DemonstrateSpanUsage();
                            break;
                        case 3:
                            ThreadPoolDemo.ExecuteThreadPoolTasks();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
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
