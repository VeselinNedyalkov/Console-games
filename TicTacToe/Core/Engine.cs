using System;
using TicTacToe.Core.Contract;
using TicTacToe.Models.PlayBoard;
using TicTacToe.Models.Player;
using TicTacToe.Models.Player.Contract;
using TicTacToe.Models.Position.Contract;

namespace TicTacToe.Core
{
    public class Engine : IEngine
    {
        Board board;
        public IPlayer playerOne;
        public IPlayer playerTwo;
        private char currentChar;
        public Engine()
        {
            board = new Board();
        }
        public void Run()
        {
            StartMenu();

            IPlayer currentPlayer = playerOne;
            int turns = 0;


            while (true)
            {
                if (turns % 2 == 0)
                {
                    currentPlayer = playerOne;
                    currentChar = 'X';
                }
                else
                {
                    currentPlayer = playerTwo;
                    currentChar = 'O';
                }


                try
                {
                    board.PrintBoard();
                    IPosition position = currentPlayer.GivePositionToBoard(board);
                    board.AddCharToBoard(position , currentChar);

                    if (board.IsPlayerWin(currentChar))
                    {
                        Console.Clear();
                        board.PrintBoard();


                        if (currentChar == 'O')
                        Console.ForegroundColor = ConsoleColor.Green;

                        if(currentChar == 'X')
                            Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine($"{currentChar} is the winner!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                turns++;

                if (board.NumberFreePositions == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("No one win!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                }
            }
        }

        private void StartMenu()
        {
            bool pickAGameMode = false;

            while (!pickAGameMode)
            {
                Console.WriteLine("The game modes are:");
                Console.WriteLine("Press 1 for Player vs Player:");
                Console.WriteLine("Press 2 for Player vs AI:");
                //Console.WriteLine("Press 3 for Player vs HardAI:");
                Console.Write("Chose a game mode:");
                string inputGameMode = Console.ReadLine();

                switch (inputGameMode)
                {
                    case "1":
                        playerOne = new UserPlayer();
                        playerTwo = new UserPlayer();
                        pickAGameMode = true;
                        break;

                    case "2":
                        playerOne = new UserPlayer();
                        playerTwo = new RandomAI();
                        pickAGameMode = true;
                        break;

                    //case "3":
                    //    playerOne = new UserPlayer();
                    //    playerTwo = new HardRandomAI();
                    //    pickAGameMode = true;
                    //    break;

                    default:
                        break;
                }
            }
        }
    }
}

