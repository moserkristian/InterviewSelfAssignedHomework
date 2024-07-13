using System.Runtime.InteropServices;

namespace BestPractices.Classes
{
    public class ParallelDemo
    {
        [DllImport("kernel32.dll")]
        private static extern nint GetCurrentThread();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int GetThreadIdealProcessorEx(nint hThread, ref PROCESSOR_NUMBER lpIdealProcessor);

        [StructLayout(LayoutKind.Sequential)]
        private struct PROCESSOR_NUMBER
        {
            public ushort Group;
            public byte Number;
            public byte Reserved;
        }

        /* Parallel programming is used to perform CPU-bound tasks concurrently. 
         * It involves dividing a task into subtasks and executing them simultaneously on multiple processors. 
         * This can significantly speed up computation-heavy operations by taking advantage of multi-core processors.
         */

        public static void ExecuteParallelSum()
        {
            int[] numbers = new int[10];

            // Initializing the array
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }

            long sum = 0;

            // Using Parallel.For to sum the array in parallel
            System.Threading.Tasks.
            Parallel.For(0, numbers.Length, () => 0L, (i, loopState, localSum) =>
            {
                PROCESSOR_NUMBER procNumber = new PROCESSOR_NUMBER();
                nint threadHandle = GetCurrentThread();
                GetThreadIdealProcessorEx(threadHandle, ref procNumber);

                Console.WriteLine($"Iteration {i} is being executed by thread {Thread.CurrentThread.ManagedThreadId} | isThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread} | CPU core {procNumber.Number}.");

                localSum += numbers[i];
                return localSum;
            },
            localSum => Interlocked.Add(ref sum, localSum));

            Console.WriteLine("Sum: " + sum);
        }
    }
}
