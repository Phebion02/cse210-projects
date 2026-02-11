// added track usage count
using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    // Track usage count for each activity
    private static Dictionary<string, int> _activityCounts = new Dictionary<string, int>();

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;

        if (!_activityCounts.ContainsKey(name))
        {
            _activityCounts[name] = 0;
        }
    }

    public void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine(_description);

        Console.Write("\nHow long, in seconds, would you like? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nPrepare to begin...");
        ShowSpinner(3);
    }

    public void EndMessage()
    {
        // Record completion
        _activityCounts[_name]++;

        Console.WriteLine("\nWell done!");
        ShowSpinner(2);

        Console.WriteLine($"\nYou completed {_duration} seconds of the {_name} Activity.");

        Console.WriteLine("\nSession Summary:");
        foreach (var activity in _activityCounts)
        {
            Console.WriteLine($"{activity.Key}: {activity.Value}");
        }

        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i = (i + 1) % spinner.Length;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}