namespace Ovning2.Helpers
{
    public static class Util
    {
        // Ask the user for a non-empty string
        public static string AskForString(string prompt)
        {
            while (true) // Loop until valid input is given
            {
                Console.Write($"{prompt}: ");
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();

                Console.WriteLine($"Du måste ange ett giltigt värde för {prompt}.\n");
            }
        }

        // Ask the user for an integer within an optional 
        public static int AskForInt(string prompt, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            while (true) // Loop until a valid integer within the range is entered
            {
                string input = AskForString(prompt);

                if (int.TryParse(input, out int result) && result >= minValue && result <= maxValue)
                    return result;

                Console.WriteLine($"Ange ett giltigt heltal (minst {minValue}). Försök igen.\n");
            }
        }

        // Ask the user for a double within an optional range
        public static double AskForDouble(string prompt, double minValue = double.MinValue, double maxValue = double.MaxValue)
        {
            while (true) // Loop until a valid number within the range is entered
            {
                string input = AskForString(prompt);

                if (double.TryParse(input, out double result) && result >= minValue && result <= maxValue)
                    return result;

                Console.WriteLine($"Ange ett giltigt tal (minst {minValue}). Försök igen.\n");
            }
        }
    }
}

