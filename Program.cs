using System;
using System.Threading.Tasks;

namespace ExamTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int.TryParse(Console.ReadLine(), out var size);
            var queue = new FIFO(size);
            Task.Run(() => Enqueue(queue));
            Task.Run(() => Dequeue(queue));
            Task.Run(() => EnqueueAndDequeue(queue));
            Task.Run(() => EnqueueAndDequeue(queue));
            Console.ReadLine();
            Console.WriteLine(queue.Count());
            Console.ReadLine();
        }

        private static void Enqueue(FIFO queue)
        {
            for (int i = 0; i < queue.Length; i++)
            {
                Console.WriteLine("Enqueue");
                queue.Enqueue(i);
            }
        }

        private static void Dequeue(FIFO queue)
        {
            while (true)
            {
                var temp = 0;
                if (queue.TryDequeue(out temp))
                {
                    Console.WriteLine("Dequeued: " + temp);
                }
            }
        }

        private static void EnqueueAndDequeue(FIFO queue)
        {
            for (int i = 0; i < queue.Length; i++)
            {
                Console.WriteLine("Enqueue");
                queue.Enqueue(i);
                var temp = 0;
                if (queue.TryDequeue(out temp))
                {
                    Console.WriteLine("Dequeued: " + temp);
                }
            }
        }

    }
}
