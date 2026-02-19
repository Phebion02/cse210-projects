using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
    {
        // EXCEEDING REQUIREMENTS:
        // 1. User selects from multiple scriptures.
        // 2. Random number (1-5) of words hidden each round.
        // 3. Console color formatting added.
        // 4. Clean screen between rounds.
        // 5. Strong encapsulation (each class handles its own responsibility).

        List<Scripture> scriptures = new List<Scripture>();

        scriptures.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life."
        ));

        scriptures.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart and lean not unto thine own understanding in all thy ways acknowledge him and he shall direct thy paths."
        ));

        scriptures.Add(new Scripture(
            new Reference("Philippians", 4, 13),
            "I can do all things through Christ which strengtheneth me."
        ));

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcome to Scripture Memorizer!");
        Console.ResetColor();

        Console.WriteLine("\nChoose a scripture to memorize:");

        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Scripture {i + 1}");
        }

        int choice = int.Parse(Console.ReadLine());
        Scripture selectedScripture = scriptures[choice - 1];

        Random random = new Random();

        while (true)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.ResetColor();

            if (selectedScripture.AllWordsHidden())
            {
                Console.WriteLine("\nAll words are hidden. Great job!");
                break;
            }

            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            int numberToHide = random.Next(1, 6); // hides 1–5 words
            selectedScripture.HideRandomWords(numberToHide);
        }

        Console.WriteLine("\nProgram ended. Keep practicing!");
    }
}
    }

