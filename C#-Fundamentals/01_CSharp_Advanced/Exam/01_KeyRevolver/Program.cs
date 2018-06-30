using System;
using System.Collections.Generic;
using System.Linq;


namespace _01_KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            long priceOfBullet = long.Parse(Console.ReadLine());
            long sizeOfGunBarrel = long.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
           Queue<int> locks = new Queue<int>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            long intelligenceValue = long.Parse(Console.ReadLine());

            long maxBullets = bullets.Count;

            //After Sam receives all of his information and gear (input), he starts to shoot the locks front-to-back, while going through the bullets back-to-front.

            bool isLockedSafe = false;

            while (bullets.Count > 0 && !isLockedSafe)
            {
             
                for (long i = 0; i < sizeOfGunBarrel; i++)
                {

                    if (locks.Count == 0)
                    {
                        isLockedSafe = true;
                        break;
                    }
                    long bullet = bullets.Pop();

                    long lockk = locks.Peek();

                    if (bullet <= lockk)
                    {
                        Console.WriteLine("Bang!");
                        locks.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }
                }
                if (isLockedSafe || bullets.Count==0)
                {
                    break;
                }
                Console.WriteLine("Reloading!");
                
            }

            long bulletCost = (maxBullets - bullets.Count) * priceOfBullet;
            long earned = intelligenceValue - bulletCost;
            if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${earned}");
            }

        }
    }
}
