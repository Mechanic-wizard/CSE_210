/*
 * ============================================
 * EXCEEDING REQUIREMENTS – Creativity Report
 * ============================================
 * 
 * 1. STRETCH CHALLENGE – Only hide visible words:
 *    The Scripture.HideRandomWords() method selects only from the words
 *    that are not yet hidden. This avoids the core requirement's allowance
 *    of picking already-hidden words and makes the memorization experience
 *    more efficient.
 * 
 * 2. SCRIPTURE LIBRARY FROM A FILE:
 *    The program loads multiple scriptures from a file named "scriptures.txt"
 *    (one per line, format: "Reference|Text"). It picks one at random each
 *    time. If the file is missing, it uses a built-in fallback scripture.
 *    This turns the app into a personal memorization tool that can grow over time.
 * 
 * 3. DYNAMIC HIDING RATE:
 *    Instead of hiding a fixed number of words each step, the program hides
 *    about 10% of the *remaining visible* words (minimum 1). This ensures
 *    the challenge stays proportional and never attempts to hide more words
 *    than are left.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Attempt to load scriptures from file; fallback to default if file not found.
        List<(Reference reference, string text)> scriptures = LoadScriptures();

        // Pick a random scripture
        Random rand = new Random();
        var (reference, text) = scriptures[rand.Next(scriptures.Count)];

        Scripture scripture = new Scripture(reference, text);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");

            string input = Console.ReadLine()?.Trim().ToLower();
            if (input == "quit")
                return;

            // Only hide words if the user pressed Enter (empty input)
            if (!string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input. Please press Enter to hide words or type 'quit'.");
                Console.ReadKey();
                continue;
            }

            // Determine how many words to hide: ~10% of remaining visible, at least 1
            int visible = scripture.VisibleWordCount();
            if (visible == 0)
                break; // safety guard

            int wordsToHide = Math.Max(1, visible / 10);
            scripture.HideRandomWords(wordsToHide);
        }

        // Final display (all hidden)
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden. Good job memorizing!");
    }

    /// <summary>
    /// Loads scriptures from a file "scriptures.txt".
    /// Each line format: "Book Chapter:Verse[-EndVerse]|Scripture text"
    /// Example: "Proverbs 3:5-6|Trust in the Lord with all your heart..."
    /// If the file is missing, a default scripture is used.
    /// </summary>
    static List<(Reference, string)> LoadScriptures()
    {
        var scriptures = new List<(Reference, string)>();
        string filePath = "scriptures.txt";

        try
        {
            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadAllLines(filePath))
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parts = line.Split('|');
                    if (parts.Length != 2)
                        continue;

                    string refString = parts[0].Trim();
                    string text = parts[1].Trim();

                    // Skip empty scripture text
                    if (string.IsNullOrWhiteSpace(text))
                        continue;

                    Reference reference = ParseReference(refString);
                    if (reference != null)
                        scriptures.Add((reference, text));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading scripture file: {ex.Message}. Using default.");
        }

        // Fallback default scripture if none loaded
        if (scriptures.Count == 0)
        {
            scriptures.Add((
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."
            ));
        }

        return scriptures;
    }

    /// <summary>
    /// Parses a reference string like "Proverbs 3:5-6" into a Reference object.
    /// </summary>
    static Reference ParseReference(string refString)
    {
        try
        {
            // Split on last space to separate book from chapter:verse
            int lastSpace = refString.LastIndexOf(' ');
            if (lastSpace < 0) return null;

            string book = refString.Substring(0, lastSpace).Trim();
            string chapterVerse = refString.Substring(lastSpace + 1).Trim();

            string[] cvParts = chapterVerse.Split(':');
            if (cvParts.Length != 2) return null;

            int chapter = int.Parse(cvParts[0]);
            string versePart = cvParts[1];

            if (versePart.Contains('-'))
            {
                string[] verses = versePart.Split('-');
                int start = int.Parse(verses[0]);
                int end = int.Parse(verses[1]);
                return new Reference(book, chapter, start, end);
            }
            else
            {
                int verse = int.Parse(versePart);
                return new Reference(book, chapter, verse);
            }
        }
        catch
        {
            return null;
        }
    }
}