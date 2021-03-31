using System;
namespace ProjectB
{
    public class Beheer
    {
        public static string Input(string vraag = null)
        {
            if (vraag != null)
            {
                Console.Write(vraag);
            }

            return Console.ReadLine();
        }
    }
}
