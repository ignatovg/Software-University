using System;
using System.IO;

namespace CopyingFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var source = new FileStream("success.jpg",FileMode.Open))
            {
                using (var destination = new FileStream("newImg.jpg",FileMode.Create))
                {
                    while (true)
                    {
                       
                    }
                }
            }
        }
    }
}
