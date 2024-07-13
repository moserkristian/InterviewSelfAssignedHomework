namespace BestPractices.Classes
{
    public class SpanDemo : IDemo
    {
        public string Description => "Span Usage Demo ( DemonstrateSpanUsage )";

        public void Execute()
        {
            DemonstrateSpanUsage();
        }

        /* In C# .NET 6, Span<T> is a stack-only type that allows you to work with contiguous memory regions in a safe and efficient manner. 
         * Span<T> provides a way to handle slices of arrays or unmanaged memory without allocations, enabling high-performance, low-level access to memory.
         */

        private static void DemonstrateSpanUsage()
        {
            // Creating a span from an array
            int[] array = { 1, 2, 3, 4, 5 };
            Span<int> span = array;

            // Accessing elements
            Console.WriteLine("Original span:");
            foreach (var item in span)
            {
                Console.WriteLine(item);
            }

            // Slicing the span
            Span<int> slice = span.Slice(1, 3);
            Console.WriteLine("\nSliced span:");
            foreach (var item in slice)
            {
                Console.WriteLine(item);
            }

            // Modifying the span affects the original array
            slice[0] = 42;
            Console.WriteLine("\nModified array:");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
