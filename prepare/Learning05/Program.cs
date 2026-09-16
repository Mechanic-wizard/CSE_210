// Assignment Instructions
// For this assignment, write a C# program that has several simple functions:

// DisplayWelcome - Displays the message, "Welcome to the Program!"
// PromptUserName - Asks for and returns the user's name (as a string)
// PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
// PromtUserBirthYear - Accepts out integer parameter and prompts the user for the year they were born. The out parameter is set to their birth year. This function does not return a value. The user's birth year is given back from the function via the out parameter.
// SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer)
// DisplayResult - Accepts the user's name, the squared number, and the user's birth year. Display the user's name and squared number. Calculate hold many years old they will turn this year and display that.
// Your Main function should then call each of these functions saving the return values and passing data to them as necessary.

// Sample output of the program could look as follows:


// Welcome to the program!
// Please enter your name: Brother Burton
// Please enter your favorite number: 42
// Please enter the year you were born: 1990
// Brother Burton, the square of your number is 1764
// Brother Burton, you will turn 35 this year.
// Write and Test the program
// Write and test the program as described above.
// Make sure to use the same project template that you did for the previous activities. However, this time, you should add your code in Program.cs file in the the Prep 5 project.

using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int birthYear;
        PromtUserBirthYear(out birthYear);
        int squared = SquareNumber(number);
        DisplayResult(name, squared, birthYear);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    static void PromtUserBirthYear(out int birthYear)
    {
        Console.Write("Please enter the year you were born: ");
        birthYear = Convert.ToInt32(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int squared, int birthYear)
    {
        Console.WriteLine($"{name}, the square of your number is {squared}");
        Console.WriteLine($"{name}, you will turn {DateTime.Now.Year - birthYear} this year.");
    }
}  

