using System;
namespace ProjectB.pages
{
    class FAQ
    {
        public static void faq(string gebruikersnaam)
        {
            // Veel gestelde vragen worden hier geschreven en getoond
            Console.WriteLine("VEELGESTELD VRAGEN\n\n");

            Console.WriteLine("Wat is de cappiciteit van de zalen?\n- Wij beschikken over 3 zalen. De eerste zaal heeft een cappiciteit van 150 personen, de tweede van 300 en tot slot de derde zaal met een cappiciteit van 500 personen.\n\n");

            Console.WriteLine("Kan er geparkeerd worden bij de cinema?\n- Uiteraard! Wij beschikken over een eigen garage waar u uw auto kunt parkeren voor maar €1,- per uur.\n\n");

            Console.WriteLine("Kan ik met een groep mensen een film kijken?\n- Dat is mogelijk. U kunt tickets bestellen t/m 10 personen.\n\n");

            Console.WriteLine("Kan ik een eigen zaal huren?\n- Dit is helaas niet mogelijk.\n\n");

            string antwoord = "";

            // Er is alleen een optie om terug te gaan met "b"
            while (antwoord != "b")
            {
                antwoord = Beheer.Input("Druk b om terug te gaan: ");
                if (antwoord == "b")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    // Melding na het verlaten van de pagina
                    Console.WriteLine("Dank u wel voor het bezoeken van onze FAQ pagina!\nHeeft u nog vragen? Neem direct contact met ons op via 0999289@hr.nl\n");
                    Console.ResetColor();
                    ConsoleMenu.consoleMenu(gebruikersnaam);
                }
                // foutmeldingen in Rood
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEr ging iets mis.");
                Console.ResetColor();
            }

        }
    }
}
