// Assignment Instructions
// For this assignment, you will complete another assignment that you did previously in CSE 110, but in this case, write the program in C#:

// Program Specification
// Here are the instructions that you saw previously in CSE 110 that we will use as our program specification:

// Assignment
// Ask the user for a series of numbers, and append each one to a list. Stop when they enter 0.

// Once you have a list, have your program do the following:

// Core Requirements
// Work through these core requirements step-by-step to complete the program. Please don't skip ahead and do the whole thing at once, because others on your team may benefit from building the program up slowly.

// Compute the sum, or total, of the numbers in the list.

// Compute the average of the numbers in the list.

// Find the maximum, or largest, number in the list.

// The following shows the expected output:


//   Enter a list of numbers, type 0 when finished.
//   Enter number: 18
//   Enter number: 36
//   Enter number: 2
//   Enter number: 48
//   Enter number: 6
//   Enter number: 12
//   Enter number: 9
//   Enter number: 0
//   The sum is: 131
//   The average is: 18.714285714285715
//   The largest number is: 48
  
// Stretch Challenge
// Have the user enter both positive and negative numbers, then find the smallest positive number (the positive number that is closest to zero).

// Sort the numbers in the list and display the new, sorted list. Hint: There are C# libraries that can help you here, try searching the internet for them.

// The following shows the expected output after completing the stretch challenges:


//   Enter a list of numbers, type 0 when finished.
//   Enter number: 3
//   Enter number: 5
//   Enter number: 7
//   Enter number: 3
//   Enter number: 2
//   Enter number: -1
//   Enter number: -4
//   Enter number: -8
//   Enter number: 0
//   The sum is: 7
//   The average is: 0.875
//   The largest number is: 7
//   The smallest positive number is: 2
//   The sorted list is:
//   -8
//   -4
//   -1
//   2
//   3
//   3
//   5
//   7


using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);
            
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}