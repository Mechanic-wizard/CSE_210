public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int? _endVerse; // null for single verse

    // Single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = null;
    }

    // Verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_endVerse.HasValue)
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse.Value}";
        else
            return $"{_book} {_chapter}:{_startVerse}";
    }
}