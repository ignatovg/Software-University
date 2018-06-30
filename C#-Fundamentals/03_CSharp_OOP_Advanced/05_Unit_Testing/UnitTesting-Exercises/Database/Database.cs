using System;

namespace P01_Database
{

    public class Database
    {
        private const int capacity = 5;

        private int currentIndex = 0;
        private int[] array;

        public Database(params int[] integers)
        {
            CheckCapacity(integers);
            this.array = new int[capacity];
            CoppyIntegersInArray(integers);
            this.currentIndex = integers.Length;
        }

        private void CoppyIntegersInArray(int[] integers)
        {
            for (int i = 0; i < integers.Length; i++)
            {
                this.array[i] = integers[i];
            }
        }

        private void CheckCapacity(int[] integers)
        {
            if (integers.Length > capacity)
            {
                throw new InvalidOperationException("Capacity is bigger then 16 symbols.");
            }
        }

        public void Add(int element)
        {
            if (this.currentIndex >= 5)
            {
                throw new InvalidOperationException("Index out of range!");
            }

            this.array[this.currentIndex] = element;
            this.currentIndex++;
        }

        public void Remove()
        {
            this.currentIndex--;
            if (this.currentIndex == -1)
            {
                throw new InvalidOperationException("Array is empty!");
            }
            this.array[this.currentIndex] = 0;
           
        }

        public int[] Fetch()
        {
            return this.array;
        }
    }

}
