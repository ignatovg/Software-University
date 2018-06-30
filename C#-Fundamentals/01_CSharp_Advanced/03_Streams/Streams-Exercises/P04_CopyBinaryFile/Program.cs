using System;
using System.IO;

namespace P04_CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new byte[2048];
            using (var source = new FileStream("../copyMe.png", FileMode.Open))
            {
                using (var destination = new FileStream("coppyMe-coppy.jpg", FileMode.Create))
                {
                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        destination.Write(buffer,0,readBytes);
                    }
                }
            }
        }
    }
}
