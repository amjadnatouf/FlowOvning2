using Ovning2.Helpers;

namespace Ovning2
{
    internal class Menu
    {
        private bool running = true;

        public void Start()
        {
            while (running)
            {
                ShowMainMenu();
                string? userInput = Console.ReadLine()?.Trim();

                // Use MenuHelpers constants to determine which action to perform
                // Util methods are called within each action to handle input validation
                switch (userInput)
                {
                    case MenuHelpers.ControlPrice:
                        CheckTicketPrice();
                        break;
                    case MenuHelpers.CalculateTotal:
                        CalculateGroupPrice();
                        break;
                    case MenuHelpers.RepeatTen:
                        RepeatTextTenTimes();
                        break;
                    case MenuHelpers.ShowThird:
                        ShowThirdWord();
                        break;
                    case MenuHelpers.Quit:
                        Console.WriteLine("Avslutar programmet...");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.\n");
                        break;
                }
            }
        }

        private void ShowMainMenu()
        {
            Console.WriteLine("\n------- Huvudmeny -------");
            Console.WriteLine("1. Kontrollera biljettpris för en person");
            Console.WriteLine("2. Beräkna pris för hela sällskapet");
            Console.WriteLine("3. Upprepa text tio gånger");
            Console.WriteLine("4. Visa tredje ordet");
            Console.WriteLine("0. Avsluta programmet");
            Console.Write("Ditt val: ");
        }

        private void CheckTicketPrice()
        {
            Console.WriteLine("\n--- Kontrollera biljettpris ---");
            double age = Util.AskForDouble("Ange ålder (kan vara t.ex. 15.5)", minValue: 0);
            int price = GetTicketPrice(age);
            Console.WriteLine($"Biljettpris: {price}kr\n");
        }

        private void CalculateGroupPrice()
        {
            Console.WriteLine("\n--- Beräkna pris för sällskap ---");
            int numberOfPeople = Util.AskForInt("Hur många personer är ni?", minValue: 1);

            int totalCost = 0;
            for (int i = 1; i <= numberOfPeople; i++)
            {
                double age = Util.AskForDouble($"Ange ålder för person {i}", minValue: 0);
                totalCost += GetTicketPrice(age);
            }

            // Show summary of total cost
            Console.WriteLine("\n=== Sammanfattning ===");
            Console.WriteLine($"Antal personer: {numberOfPeople}");
            Console.WriteLine($"Totalkostnad: {totalCost}kr\n");
        }

        private void RepeatTextTenTimes()
        {
            Console.WriteLine("\n--- Upprepa text tio gånger ---");
            string text = Util.AskForString("Ange en text");

            Console.WriteLine();
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{i}.{text}");
                if (i < 10)
                    Console.Write(", ");
            }
            Console.WriteLine();
        }

        private void ShowThirdWord()
        {
            Console.WriteLine("\n--- Visa tredje ordet ---");
            string sentence = Util.AskForString("Ange en mening med minst tre ord");
            string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (words.Length < 3)
            {
                Console.WriteLine("Du måste ange minst tre ord.\n");
                return;
            }

            Console.WriteLine($"Det tredje ordet är: {words[2]}\n");
        }

        // Determine ticket price based on
        private int GetTicketPrice(double age)
        {
            if (age < 5)
                return 0;
            if (age < 20)
                return 80;
            if (age > 100)
                return 0;
            if (age > 64)
                return 90;
            return 120;
        }
    }
}
