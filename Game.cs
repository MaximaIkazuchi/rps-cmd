using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rockpaperscissor
{
    internal class Game
    {
        private String playerName;
        private int playerScore = 0;
        public enum Choice { Rock, Paper, Scissor };

        public Game()
        {
            playerName = CreatePlayer();
        }

        public String PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        public int PlayerScore
        {
            get { return playerScore; }
            set { playerScore = value; }
        }

        private String CreatePlayer()
        {
            Console.WriteLine("\nInsert your name: ");
            Console.Write(">> ");

            int i = 0;
            while (true)
            {
                if (i > 0) Console.Write("\n>> ");

                String inputName = Console.ReadLine();
                if (!String.IsNullOrEmpty(inputName) && !String.IsNullOrWhiteSpace(inputName))
                {
                    return inputName;
                }
                Console.WriteLine("\nInput can't be empty!");
                i++;
            }
        }

        private Choice PlayerChoice()
        {
            Console.WriteLine("\nInsert your Choice: \n1. Rock\n2. Paper\n3. Scissor");
            Console.Write("\n>> ");
            Choice playerChoice;

            int i = 0;
            while (true)
            {
                if (i > 0) Console.Write("\n>> ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                char keyPressed = keyInfo.KeyChar;

                if (keyPressed == '1')
                {
                    playerChoice = Choice.Rock;
                    break;
                }
                else if (keyPressed == '2')
                {
                    playerChoice = Choice.Paper;
                    break;
                }
                else if (keyPressed == '3')
                {
                    playerChoice = Choice.Scissor;
                    break;
                }
                Console.WriteLine("\nInvalid Choice!");
                i++;
            }
            return playerChoice;
        }

        private Choice ComputerChoice()
        {
            Random rand = new Random();
            return (Choice)rand.Next(3);
        }

        public void Play()
        {
            while (true)
            {
                while (true)
                {
                    Choice player = PlayerChoice();
                    Choice cpu = ComputerChoice();

                    // Draw
                    if (player == cpu)
                    {
                        Console.WriteLine("\n" + playerName + " picked: " + player + "\nCPU picked: " + cpu);
                        Console.WriteLine("\nDraw!");
                        break;
                    }
                    // Win
                    else if (player == Choice.Rock && cpu == Choice.Scissor ||
                        player == Choice.Paper && cpu == Choice.Rock ||
                        player == Choice.Scissor && cpu == Choice.Paper)
                    {
                        Console.WriteLine("\n" + playerName + " picked: " + player + "\nCPU picked: " + cpu);
                        Console.WriteLine("\nYou Win!");
                        break;
                    }
                    // Lose
                    else
                    {
                        Console.WriteLine("\n" + playerName + " picked: " + player + "\nCPU picked: " + cpu);
                        Console.WriteLine("\nYou Lose!");
                        break;
                    }
                }
                Console.WriteLine("Do you want to play again? (y/n)");
                Console.Write("\n>> ");

                ConsoleKeyInfo inputPlayAgain = Console.ReadKey();
                char playAgain = inputPlayAgain.KeyChar;
                if (playAgain == 'y')
                {
                    continue;
                } else if (playAgain == 'n')
                {
                    break;
                }
            }
            Console.WriteLine("\nThanks for playing!");
        }
    }
}