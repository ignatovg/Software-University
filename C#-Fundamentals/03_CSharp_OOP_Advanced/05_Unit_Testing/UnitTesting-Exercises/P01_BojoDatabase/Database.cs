using System;

namespace P01_BojoDatabase
{
    public class Database
    {
        private const int defauldCapacity = 16;

        private int[] values;
        private int currentIndex;

        private Database()
        {
            this.values = new int[defauldCapacity];
        }
        public Database(params int[] values):this()
        {
            this.InitializeValues(values);
            this.currentIndex = 0;
        }

        private void InitializeValues(int[] inputValues)
        {
            try
            {
                Array.Copy(inputValues, this.values, inputValues.Length);
                this.currentIndex = inputValues.Length;
            }
            catch (ArgumentException e)
            {
                throw new InvalidOperationException("Array is full!");
            }
        }

        public void Add(int elemnt)
        {
            if (this.currentIndex >= defauldCapacity)
            {
                throw new InvalidOperationException("Array is full!");
            }

            this.values[this.currentIndex] = elemnt;
            this.currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Array is empty!");
            }
            currentIndex--;
            this.values[this.currentIndex] = default(int);
        }

        public int[] Fetch()
        {
            int[] newArray = new int[this.currentIndex];
            Array.Copy(this.values,newArray,currentIndex);

            return newArray;
        }
    }
}
