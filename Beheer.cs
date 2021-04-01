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

        public static string ControlEmpty(string var)
        {
            while (string.IsNullOrEmpty(var))
            {
                Console.WriteLine($"Dit veld kan niet leeg gelaten worden, probeer het nogmaals. Vul in: ");
                var = Console.ReadLine();
            }
            return var;
        } 
    }
}
