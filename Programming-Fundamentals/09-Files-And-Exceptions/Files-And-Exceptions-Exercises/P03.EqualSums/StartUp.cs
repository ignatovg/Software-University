using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.EqualSums
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var tokens = File.ReadAllText("input.txt").Split(' ').Select(int.Parse).ToArray();
            bool isMatch = false;
            int index = 0;
            for (int i = 0; i < tokens.Length; i++)
            {
                int[] leftElements = tokens.Take(i).ToArray();
                int[] rightElements=tokens.Skip(i+1).ToArray();

                

                int leftSum = leftElements.Sum();
                int rightSum=rightElements.Sum();

                if (leftSum == rightSum)
                {
                    isMatch = true;
                    index = i;
                
                }

            }

            File.WriteAllText("output.txt",string.Empty);
            if (isMatch)
            {
                File.AppendAllText("output.txt",index.ToString());
             
            }
            else
            {
                File.AppendAllText("output.txt","no");
            
            }
        }
    }
}
