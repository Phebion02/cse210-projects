using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    

    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main(string[] args)
    {
        // EXCEEDING REQUIREMENTS:
        // 1. Added leveling system (every 1000 points = level up)
        // 2. Added player titles based on level
        // 3. Clean UI formatting
        // 4. Infinity symbol for eternal goals

        while (true)
        {
            DisplayPlayerInfo();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");

            Console.Write("Select choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": return;
            }
        }
    }

    static void DisplayPlayerInfo()
    {
        int level = score / 1000 + 1;
        string title = GetTitle(level);

        Console.WriteLine($"\n⭐ Score: {score} | Level: {level} | Title: {title}");
    }

    static string GetTitle(int level)
    {
        if (level >= 5) return "Master";
        if (level >= 3) return "Disciple";
        return "Seeker";
    }

    static void CreateGoal()
    {
        Console.WriteLine("Select Goal Type:");
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");
        Console.WriteLine("3. Checklist");

        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
            goals.Add(new SimpleGoal(name, desc, points));

        else if (type == "2")
            goals.Add(new EternalGoal(name, desc, points));

        else if (type == "3")
        {
            Console.Write("Target Count: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());

            goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    static void ListGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }
    }

    static void RecordEvent()
    {
        ListGoals();
        Console.Write("Select goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        int earned = goals[index].RecordEvent();
        score += earned;

        Console.WriteLine($"You earned {earned} points!");
    }

    static void SaveGoals()
    {
        Console.Write("Filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(score);
            foreach (Goal g in goals)
                writer.WriteLine(g.GetSaveString());
        }
    }

    static void LoadGoals()
    {
        Console.Write("Filename: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
            return;

        string[] lines = File.ReadAllLines(filename);

        score = int.Parse(lines[0]);
        goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            if (parts[0] == "Simple")
                goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));

            else if (parts[0] == "Eternal")
                goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));

            else if (parts[0] == "Checklist")
                goals.Add(new ChecklistGoal(parts[1], parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[5]),
                    int.Parse(parts[4]),
                    int.Parse(parts[6])));
        }
    }
} 
