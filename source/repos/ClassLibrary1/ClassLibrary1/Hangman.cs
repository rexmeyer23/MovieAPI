using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Hangman
    {
        private readonly List<string> phrases = new List<string>();
        private readonly List<char> guessedLetters = new List<char>();
        private int guessesLeft = 7;

        public void InitializePhrases()
        {
            phrases.Add("Xylophone");
            phrases.Add("Jazz");
            phrases.Add("Inchworm");
            phrases.Add("Hovercraft");
            phrases.Add("Fortress");
            phrases.Add("Caviar");
            phrases.Add("Interference");
            phrases.Add("Acoustics");
            phrases.Add("Pneumonoultramicroscopicsilicovolcanoconiosis");
        }

        public string Setup()
        {
            guessedLetters.Clear();
            Random random = new Random();
            string word = phrases[random.Next(0, 9)];
            return word;
        }

        // method to display the word with the correctly guessed letters
        // i.e. _ _ L _ O P _ O _ E (word is XYLOPHONE, guessed leters are L, O, P, E)
        //Capture guess and save it to collections or right and wrong letters

        public void showWord(string word)
        {
            string wordBlanks = "";
            foreach (char letter in word)
            {
                foreach (char guess in guessedLetters)
                {
                    if (letter.ToString().ToUpper() == guess.ToString().ToUpper())
                    {
                        wordBlanks = wordBlanks + letter + " ";
                    }
                    else
                    {
                        wordBlanks = wordBlanks + "__ ";
                    }
                    // guessed: L O H
                    // Output: __ __ L O __ H O __ __ 
                }
            }
            Console.WriteLine(wordBlanks);
        }

        // keep track of all guessed letters, and show which have been guessed already
        // also show how many incorrect guesses user has left

        public void ShowGuesses()
        {
            string guessedLettersString = "";
            foreach(char guess in guessedLetters)
            {
                guessedLettersString = guessedLettersString + guess + " ";
            }
            Console.WriteLine($"Guessed Letters: {guessedLettersString}");
            Console.WriteLine($"Incorrect Guesses Remaining: {guessesLeft}");
        }

        // ask user if they want to guess one letter or the full word
        // readkey for one letter, readline for full word
        // if letter, tell user if they already guessed that letter and have them guess a new letter

        public string Guess()
        {
            string guess = " ";
            Console.WriteLine("Would you like to guess a single letter, or the full word? \n" +
                "1: Single Letter \n" +
                "2: Full Word");
            switch (Int32.Parse(Console.ReadLine()))
            {
                case 1:
                    guess = Console.ReadKey().ToString();
                    break;
                case 2:
                    guess = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Could not understand your input. Please try again.");
                    break;
            }

            return guess;
        }

        // if word is guessed correctly, display congratulations screen
        // if user runs out of guesses, show game over screen and reveal what the word was
        // in both cases, ask if user wants to play again or exit the program
        // return a boolean, return false if they choose to exit. true otherwise

        public bool CheckGuess(string guess, string word)
        {
            bool isAlreadyGuessed = false;
            bool gameWon = false;

            if (guess.Length > 1)
            {
                if (guess.ToUpper() == word.ToUpper())
                {
                    gameWon = true;
                }
                else
                {
                    Console.WriteLine("That was not the correct word. You have lost one guess");
                    guessesLeft -= 1;
                }
                return gameWon;
            }

            foreach (char letter in guessedLetters)
            {
                if (guess.ToUpper() == letter.ToString().ToUpper())
                {
                    isAlreadyGuessed = true;
                }
            }

            if (isAlreadyGuessed)
            {
                Console.WriteLine("You have already guessed this letter! Please try again");
            }
            else
            {
                guessedLetters.Add(char.Parse(guess));
                bool correctGuess = false;
                foreach (char letter in word)
                {
                    if (guess.ToUpper() == letter.ToString().ToUpper())
                    {
                        correctGuess = true;
                    }
                }

                if (correctGuess)
                {
                    Console.WriteLine("That letter is in the word.");
                    int correctLetters = 0;
                    foreach(char guesses in guessedLetters)
                    {
                        foreach(char letters in word)
                        {
                            if(guesses.ToString().ToUpper() == letters.ToString().ToUpper())
                            {
                                correctLetters++;
                            }
                        }
                    }

                    if(correctLetters == word.Length)
                    {
                        gameWon = true;
                        return gameWon;
                    }
                }
                else
                {
                    Console.WriteLine("That letter is not in the word.");
                    guessesLeft--;
                }
            }
            return gameWon;
        }

        public bool EndCheck(bool gameWon, string word)
        {
            bool gameEnd = false;
            
            if (gameWon)
            {
                Console.WriteLine($"Congratulations! You guessed the word! The word was {word}");
                gameEnd = true;
                return gameEnd;
            }
            else if(guessesLeft <= 0)
            {
                Console.WriteLine($"You have run out of guesses. The correct word was {word}");
                gameEnd = true;
                return gameEnd;
            }

            return gameEnd;
        }

        public bool ContinueCheck()
        {
            bool correctInput = false;
            bool continueCheck = false;
            string input = "3";
            while (!correctInput)
            {
                correctInput = true;
                Console.WriteLine("Would you like to play again? \n" +
                "1: Play Again \n" +
                "2: Exit Program");
                input = Console.ReadLine();
                try
                {
                    Int32.Parse(input);
                }
                catch
                {
                    correctInput = false;
                    Console.WriteLine("Could not read your input. Please input one of the accepted values.");
                }

                if (correctInput)
                {
                    if (Int32.Parse(input) != 1 && Int32.Parse(input) != 2)
                    {
                        correctInput = false;
                        Console.WriteLine("That is not an accepted value. Please input an accepted value.");
                    }
                }
            }

            switch (Int32.Parse(input))
            {
                case 1:
                    continueCheck = true;
                    break;
                case 2:
                    continueCheck = false;
                    Console.WriteLine("Thank you for playing.");
                    Console.ReadLine();
                    break;
                default:
                    continueCheck = false;
                    Console.WriteLine("Something went wrong. Exiting the program.");
                    Console.ReadLine();
                    break;
            }

            return continueCheck;
        }
    }
}




//class library - classes for things to build the game
//Program- call main method to begin the game
//Console - for program class and UI
//One method to hold all classes in repo "math showing work"
//ProgramUI- interacting with user - allowing guesses and taking in answers
//Repo- collection of tools