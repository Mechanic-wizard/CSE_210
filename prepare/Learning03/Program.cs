// Header Comment with name and description of the program 
// All varribles in the program have initals ehich are PB_ for the prefix of each varrible
// and test all code is working


// Assignment Instructions
// For this assignment, you will complete another assignment that you did previously in CSE 110, but in this case, write the program in C#:

// Program Specification
// Here are the instructions that you saw previously in CSE 110 that we will use as our program specification:

// Overview
// In the Guess My Number game the computer picks a magic number, and then the user tries to guess it. After each guess, the computer tells the user to guess "higher" or "lower" until they guess the magic number.

// This assignment is a little tricky, because it brings together many of the concepts you've learned in this course including loops and if statements.

// Core Requirements
// Work through these core requirements step-by-step to complete the program. Please don't skip ahead and do the whole thing at once, because many people benefit from seeing the program built up step by step.

// Start by asking the user for the magic number. (In future steps, we will change this to have the computer generate a random number, but to get started, we'll just let the user decide what it is.)

// Ask the user for a guess.

// Using an if statement, determine if the user needs to guess higher or lower next time, or tell them if they guessed it.

// At this point, you won't have any loops.

// The following shows the expected output at this point:


//   What is the magic number? 6
//   What is your guess? 4
//   Higher


//   What is the magic number? 6 
//   What is your guess? 7
//   Lower


//   What is the magic number? 6
//   What is your guess? 6
//   You guessed it!

// Add a loop that keeps looping as long as the guess does not match the magic number.

// At this point, the user should be able to keep playing until they get the correct answer.

// The following shows the expected output at this point:


//   What is the magic number? 18
//   What is your guess? 5
//   Higher
//   What is your guess? 6
//   Higher
//   What is your guess? 7
//   Higher
//   What is your guess? 20
//   Lower
//   What is your guess? 19
//   Lower
//   What is your guess? 18
//   You guessed it!

// Instead of having the user supply the magic number, generate a random number from 1 to 100.

// Play the game and make sure it works!

// Stretch Challenge
// Keep track of how many guesses the user has made and inform them of it at the end of the game.

// After the game is over, ask the user if they want to play again. Then, loop back and play the whole game again and continue this loop as long as they keep saying "yes".

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int magic = random.Next(1, 101);

        int guess = -1;

        while (guess != magic)
        {
            Console.Write("What is your guess? ");
            guess = Convert.ToInt32(Console.ReadLine());

            if (guess < magic)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magic)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}