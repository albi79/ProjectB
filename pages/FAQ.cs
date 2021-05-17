using System;
namespace ProjectB.pages
{
    class FAQ
    {
        public static void faq()
        {
            Console.WriteLine("VEELGESTELD VRAGEN\n\n");

            Console.WriteLine("Wat is de cappiciteit van de zalen?\n- Wij beschikken over 3 zalen. De eerste zaal heeft een cappiciteit van 150 personen, de tweede van 300 en tot slot de derde zaal met een cappiciteit van 500 personen.\n\n");

            Console.WriteLine("Kan er geparkeerd worden bij de cinema?\n- Uiteraard! Wij beschikken over een eigen garage waar u uw auto kunt parkeren voor maar €1,- per uur.\n\n");

            Console.WriteLine("Kan ik met een groep mensen een film kijken?\n- Dat is mogelijk. U kunt tickets bestellen t/m 10 personen.\n\n");

            Console.WriteLine("Kan ik een eigen zaal huren?\n- Dit is helaas niet mogelijk.\n\n");

            string antwoord = "";

            while(antwoord != "b")
            {
                antwoord = Beheer.Input("Druk b om terug te gaan: ");
                if (antwoord == "b")
                {
                    Console.Clear();
                    ConsoleMenu.consoleMenu();
                }
                Console.WriteLine("\nEr ging iets mis.");
            }

        }
    }
}
