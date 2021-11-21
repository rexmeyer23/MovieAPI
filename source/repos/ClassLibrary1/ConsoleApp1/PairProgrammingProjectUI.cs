using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class PairProgrammingProjectUI
    {
        // set up all of the needed methods in a loop that runs until user indicates that they don't want to continue
        // controlled by boolean from method in Hangman class at the end

        // ask user if they want to guess one letter or the full word
        // readkey for one letter, readline for full word
        // if letter, tell user if they already guessed that letter and have them guess a new letter
        public void StartUpMenu()
        {
            Hangman hangman = new Hangman();
            hangman.InitializePhrases();
            bool gameCheck = true;
            bool endCheck = false;
            bool winCheck = false;
            string word = "";
            string guess = "";

            while (gameCheck)
            {
                word = hangman.Setup();

                while (!endCheck)
                {
                    hangman.showWord(word);
                    hangman.ShowGuesses();
                    guess = hangman.Guess();
                    winCheck = hangman.CheckGuess(guess, word);
                    endCheck = hangman.EndCheck(winCheck, word);
                }

                gameCheck = hangman.ContinueCheck();
            }
        }
    }
}
