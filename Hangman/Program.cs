using System;
using System.Text;

namespace Hangman
{   /// <summary>
    /// Hangman game
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordsArr = { "avenue", "bikini", "crypt", "duplex",
                "equip", "flexible", "galaxy", "icebox", "jogging", "kilobyte" };

            string[] rightGuesses;
            StringBuilder wrongGuess;
            string secretWord = "";
            bool gameIsOn = true;
            int maxGuesses = 10;
            int guessCount = 0;

            secretWord = chooseASecretWord(wordsArr);

            rightGuesses = new string[secretWord.Length];
            wrongGuess = new StringBuilder();

            populateSecretWordArray(rightGuesses);

            Console.WriteLine("The secret word to be guessed is:\n" + secretWord);
            Console.WriteLine("\nYou have 10 guessing chances");

            while (gameIsOn)
            {
                guessCount++;
                Console.WriteLine("\n\nMake guess " + guessCount);

                string guessedChar = Console.ReadLine().ToLower();

                if (!(guessedChar.Length == 1) && guessCount < 10)
                {
                    Console.WriteLine("Try again! Enter characters only\n");
                    guessedChar = Console.ReadLine().ToLower();
                }

                checkPlayerGuess(secretWord, guessedChar, rightGuesses, wrongGuess);

                foreach (string str in rightGuesses)
                    Console.Write(str);

                if (wordIsGuessed(rightGuesses))
                {
                    string rightGuessResult = String.Concat(rightGuesses);
                    Console.WriteLine("\nYour won");
                    Console.WriteLine("Your guessed word is " + rightGuessResult);
                    gameIsOn = false;
                }
                else if (guessCount == maxGuesses)
                {
                    Console.WriteLine("\nYour lost");
                    Console.WriteLine("Your guesses are " + wrongGuess);
                    gameIsOn = false;
                }
            }
        }


        static string chooseASecretWord(string[] _wordsArr)
        {
            Random rnd = new Random();
            return _wordsArr[rnd.Next(_wordsArr.Length)].ToLower();
        }

        static void populateSecretWordArray(string[] secretWordArr)
        {
            for (int i = 0; i < secretWordArr.Length; i++)
                secretWordArr[i] = "_";
        }

        static void checkPlayerGuess(string _secretWord, string _guessedChar, string[] _rightGuesses, StringBuilder _wrongGuess)
        {
            for (int i = 0; i < _secretWord.Length; i++)
            {
                if (_guessedChar.Contains(_secretWord[i]) && _guessedChar.Length == 1)
                    _rightGuesses[i] = _guessedChar;
                else
                    _wrongGuess.Append(_guessedChar);
            }
        }

        static bool wordIsGuessed(string[] _rightGuesses)
        {
            for (int i = 0; i < _rightGuesses.Length; i++)
                if (_rightGuesses[i].Equals("_"))
                    return false;
            return true;
        }
    }
}