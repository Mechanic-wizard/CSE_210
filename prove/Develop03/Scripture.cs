using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        // FIX: Remove empty entries caused by multiple spaces
        _words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(w => new Word(w))
                     .ToList();
        _random = new Random();
    }

    public void HideRandomWords(int count)
    {
        // Get indices of words that are still visible
        var visibleIndices = _words
            .Select((word, index) => new { word, index })
            .Where(x => !x.word.IsHidden())
            .Select(x => x.index)
            .ToList();

        // Hide up to 'count' randomly chosen visible words
        int wordsToHide = Math.Min(count, visibleIndices.Count);
        
        // Shuffle the visible indices and take the first 'wordsToHide'
        var indicesToHide = visibleIndices
            .OrderBy(x => _random.Next())
            .Take(wordsToHide)
            .ToList();

        foreach (int idx in indicesToHide)
            _words[idx].Hide();
    }

    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        string wordsText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{referenceText}\n{wordsText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    // Helper to know how many words remain visible
    public int VisibleWordCount()
    {
        return _words.Count(w => !w.IsHidden());
    }
}