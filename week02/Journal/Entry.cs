using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Entry 
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }

    public string ToFileString()
    {
        return $"{Date}~|~{Prompt}~|~{Response}";
    }

    public static Entry FromFileString(string fileLine)
    {
        string[] parts = fileLine.Split("~|~");
        if (parts.Length == 3)
        {
            return new Entry(parts[0], parts[1], parts[2]);
        }
        return null;
    }
}
