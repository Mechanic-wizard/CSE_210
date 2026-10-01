SCRIPTURE MEMORIZER DESIGN

Classes:
Reference
- Stores book, chapter, verse(s).
- GetDisplayText()

Word
- Stores text and hidden status.
- Hide(), Show(), IsHidden(), GetDisplayText()

Scripture
- Stores Reference and List<Word>.
- GetDisplayText(), HideRandomWords(int), IsCompletelyHidden()

Program
- Runs main loop and handles user input.

Class Diagram:
Program -> Scripture
Scripture -> Reference
Scripture -> Word (many)

Program Flow:
1. Create Reference and Scripture.
2. While not all words are hidden:
   - Clear screen and display scripture.
   - Ask: Enter to continue or type "quit".
   - If "quit", stop.
   - Hide random words.
3. End when all words are hidden or user quits.
4. Display final scripture.

Pseudo-code:
Reference ref = new Reference("John", 3, 16);
Scripture scripture = new Scripture(ref, "For God so loved the world...");

while (!scripture.IsCompletelyHidden())
{
    Console.Clear();
    Console.WriteLine(scripture.GetDisplayText());
    Console.WriteLine("Press Enter or type 'quit'.");

    string input = Console.ReadLine();

    if (input?.ToLower() == "quit")
        break;

    scripture.HideRandomWords(3);
}

Console.Clear();
Console.WriteLine(scripture.GetDisplayText());