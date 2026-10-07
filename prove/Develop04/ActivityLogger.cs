using System;
using System.Collections.Generic;
using System.IO;

static class ActivityLogger
{
    private static Dictionary<string, int> _counts = new Dictionary<string, int>();
    private static readonly string _logFile = "activity_log.txt";

    public static void LoadLog()
    {
        if (File.Exists(_logFile))
        {
            string[] lines = File.ReadAllLines(_logFile);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[1], out int count))
                {
                    _counts[parts[0]] = count;
                }
            }
        }
    }

    public static void SaveLog()
    {
        List<string> lines = new List<string>();
        foreach (var kvp in _counts)
        {
            lines.Add($"{kvp.Key},{kvp.Value}");
        }
        File.WriteAllLines(_logFile, lines);
    }

    public static void LogActivity(string name)
    {
        if (_counts.ContainsKey(name))
            _counts[name]++;
        else
            _counts[name] = 1;
    }

    public static void DisplayStats()
    {
        Console.WriteLine("\nActivity summary (all sessions):");
        if (_counts.Count == 0)
            Console.WriteLine("No activities recorded yet.");
        else
            foreach (var kvp in _counts)
                Console.WriteLine($"  {kvp.Key}: {kvp.Value} time(s)");
        Console.WriteLine();
    }
}