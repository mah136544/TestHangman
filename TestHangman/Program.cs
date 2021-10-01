using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestHangman
{
  
        class Program
        {
            static void Main(string[] args)
            {
                Random random = new Random((int)DateTime.Now.Ticks);

                string[] wordWon = { "Brun", "Syster", "Guld", "Himmel", "spel" };

                string wordThink = wordWon[random.Next(0, wordWon.Length)];
                string wordThinkUppercase = wordThink.ToUpper();

                StringBuilder displayToPlayer = new StringBuilder(wordThink.Length);
                for (int i = 0; i < wordThink.Length; i++)
                    displayToPlayer.Append('_');

                List<char> rightGuesses = new List<char>();
                List<char> wrongGuesses = new List<char>();

                int lives = 10;
                bool won = false;
                int lettersRevealed = 0;
                string input;
                char guess;

                while (!won && lives > 0)
                {
                    Console.Write("write a letter: ");

                    input = Console.ReadLine().ToUpper();
                    guess = input[0];

                    if (rightGuesses.Contains(guess))
                    {
                        Console.WriteLine("You've already tried '{0}', and that`s correct!", guess);
                        continue;
                    }
                    else if (wrongGuesses.Contains(guess))
                    {
                        Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                        continue;
                    }

                    if (wordThinkUppercase.Contains(guess))
                    {
                        rightGuesses.Add(guess);

                        for (int i = 0; i < wordThink.Length; i++)
                        {
                            if (wordThinkUppercase[i] == guess)
                            {
                                displayToPlayer[i] = wordThink[i];
                                lettersRevealed++;
                            }
                        }

                        if (lettersRevealed == wordThink.Length)
                            won = true;
                    }
                    else
                    {
                        wrongGuesses.Add(guess);

                        Console.WriteLine("sorry, there's no '{0}' in it!", guess);
                        lives--;
                    }

                    Console.WriteLine(displayToPlayer.ToString());
                }

                if (won)
                    Console.WriteLine("Congratulations, You won!");
                else
                    Console.WriteLine("Sorry you lost! It was '{0}'", wordThink);

                Console.Write("Press ENTER to exit...");
                Console.ReadLine();
            }
        }
    }



