using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace P02._1.CommandInterpreter
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputLine = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                string[] cmdTokens = command.Split(' ');
                string cmdName = cmdTokens[0];

                switch (cmdName)
                {
                    case "reverse":
                        Reverse(inputLine, cmdTokens);
                        break;
                    case "sort":
                        Sort(inputLine, cmdTokens);
                        break;
                    case "rollLeft":
                        RollLeft(inputLine, cmdTokens);
                        break;
                    case "rollRight":
                        RollRight(inputLine, cmdTokens);
                        break;
                }
            }
            Console.WriteLine($"[{string.Join(", ",inputLine)}]");
        }

        private static void RollRight(string[] inputLine, string[] cmdTokens)
        {
            int count = int.Parse(cmdTokens[1]);

            var list = inputLine.ToList();
           
            for (int i = 0; i < count; i++)
            {
                var lastElement = list[list.Count - 1];
                list.Insert(0,lastElement);    
                list.RemoveAt(list.Count-1);
            }

            for (int i = 0; i < inputLine.Length; i++)
            {
                inputLine[i] = list[i];
            }
        }

        private static void RollLeft(string[] inputLine, string[] cmdTokens)
        {
            int count = int.Parse(cmdTokens[1]);

            var list = inputLine.ToList();

            for (int i = 0; i < count; i++)
            {
                var firstElement = list[0];
                list.Insert(list.Count, firstElement);
                list.RemoveAt(0);
            }

            for (int i = 0; i < inputLine.Length; i++)
            {
                inputLine[i] = list[i];
            }
        }

        private static void Sort(string[] inputLine, string[] cmdTokens)
        {
            int startIndex = int.Parse(cmdTokens[2]);
            int count = int.Parse(cmdTokens[4]);

            int endIndex = startIndex + count - 1;

            if (count < 0
                || startIndex < 0
                || startIndex > inputLine.Length - 1
                || startIndex + count  >= inputLine.Length - 1)
            {
                Console.WriteLine("Invalid input parameters.");
            }
            else
            {
                var innerArr = inputLine
                    .Skip(startIndex)
                    .Take(count)
                    .OrderBy(a=>a)
                    .ToArray();

                int index = 0;
                for (int i = startIndex; i <= endIndex; i++)
                {
                    inputLine[i] = innerArr[index++];
                }
            }
        }

        private static void Reverse(string[] inputLine, string[] cmdTokens)
        {
            int startIndex = int.Parse(cmdTokens[2]);
            int count = int.Parse(cmdTokens[4]);

            int endIndex = startIndex + count - 1;

            if (count < 0 
                || startIndex < 0 
                || startIndex > inputLine.Length - 1
                || startIndex + count  >= inputLine.Length - 1)
            {
                Console.WriteLine("Invalid input parameters.");
            }
            else
            {
                while (startIndex < endIndex)
                {
                    string temp = inputLine[startIndex];
                    inputLine[startIndex] = inputLine[endIndex];
                    inputLine[endIndex] = temp;
                    startIndex++;
                    endIndex--;
                }
            }
        }
    }
}
