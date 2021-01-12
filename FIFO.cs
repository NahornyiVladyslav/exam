namespace ExamTask
{
    public class FIFO
    {
        private object locker = new object();
        private int[] array;
        private int length;
        public FIFO(int size)
        {
            array = new int[size];
        }

        public int Count()
        {
            return length;
        }

        public int Length
        {
            get
            {
                return array.Length;
            }
        }

        public bool TryDequeue(out int value)
        {
            lock (locker)
            {
                if (length > array.Length || length == 0)
                {
                    value = default;
                    return false;
                }
                else
                {
                    value = array[length - 1];
                    array[length - 1] = 0;
                    length--;
                    return true;
                }
            }
        }

        public void Enqueue(int item)
        {
            lock (locker)
            {
                if (length != array.Length)
                {
                    for (int i = length - 1; i >= 0; i--)
                    {
                        array[i + 1] = array[i];
                    }
                    array[0] = item;
                    length++;
                }
            }
        }
    }
}
