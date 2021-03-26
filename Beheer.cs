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

        public static void CreateAccount()
        {
            string naam = Input("Wat is je naam?: ");
            int Leetijd = int.Parse(Input("Wat is je leeftijd?: "));

            Console.WriteLine($"Naam {naam} leeftijd: {Leetijd}");
        }
    }
}
