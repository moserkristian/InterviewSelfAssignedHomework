using System.Runtime.InteropServices;

namespace BestPractices.Classes
{
    public class ThreadPoolDemo : IDemo
    {
        public string Description => "ThreadPool Demo ( ExecuteThreadPoolTasks )";

        public void Execute()
        {
            ExecuteThreadPoolTasks();
        }

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

        /* The thread pool in C# is a pool of worker threads maintained by the .NET runtime.
         * These threads are used to perform tasks in the background, 
         * which helps improve application performance by reusing existing threads rather than creating new ones each time a task needs to be executed. 
         * This reuse reduces the overhead associated with thread creation and destruction.
         */

        private static void ExecuteThreadPoolTasks()
        {
            // Queue multiple tasks to the thread pool
            for (int i = 0; i < 10; i++)
            {
                int taskNumber = i;
                
                ThreadPool.QueueUserWorkItem(Task, taskNumber);
            }

            // Give some time for the tasks to complete
            Thread.Sleep(3000);
            Console.WriteLine("Main thread exits.");
        }

        private static void Task(object? state)
        {
            if (state == null) throw new NullReferenceException();

            int taskNumber = (int)state;

            WriteWorkingStatus(taskNumber, "starting");

            // Simulate some work with a delay
            Thread.Sleep(1000);

            WriteWorkingStatus(taskNumber, "completed");
        }

        private static void WriteWorkingStatus(int taskNumber, string status)
        {
            PROCESSOR_NUMBER procNumber = new PROCESSOR_NUMBER();
            nint threadHandle = GetCurrentThread();
            GetThreadIdealProcessorEx(threadHandle, ref procNumber);
            Console.WriteLine($"Task {taskNumber} is {status} on thread {Thread.CurrentThread.ManagedThreadId} | isThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread} | CPU core {procNumber.Number}.");
        }
    }
}
