using System;
using System.IO;
using System.Text;

namespace WritingTextToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Кирилица";
            var filiStream = new FileStream("log.txt",FileMode.Create);

            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                filiStream.Write(bytes,0,bytes.Length);
            }
            finally
            {
                filiStream.Close();
            }
        }
    }
}
