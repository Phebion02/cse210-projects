using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are your personal strengths?",
        "What are things that make you happy?"
    };

    public ListingActivity()
        : base("Listing",
        "This activity helps you list positive things in your life.")
    {
    }

    public void Run()
    {
        StartMessage();

        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine($"\nList as many responses as you can to:");
        Console.WriteLine($"--- {prompt} ---");
        ShowSpinner(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items!");
        EndMessage();
    }
}