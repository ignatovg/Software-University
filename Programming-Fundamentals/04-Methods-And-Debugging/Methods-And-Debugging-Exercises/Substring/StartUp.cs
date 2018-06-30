using System;

public class StartUp
{
    public static void Main()
    {
        string text = Console.ReadLine();
        int jump = int.Parse(Console.ReadLine());

        const char Search = 'p';
        bool hasMatch = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == Search)
            {
                hasMatch = true;

                int endIndex = jump;

                if (endIndex > text.Length)
                {
                    endIndex = text.Length-1;
                }
                string matchedString = "";

                if (text.Length - i > endIndex+1)
                {
                    matchedString = text.Substring(i, endIndex + 1);
                }
                else
                {
                    matchedString = text.Substring(i);
                }
               
                Console.WriteLine(matchedString);
                i += jump;
            }
        }

        if (!hasMatch)
        {
            Console.WriteLine("no");
        }
    }
}
