using System;

namespace TicTacToe
{
    /// <summary>
    /// Game logic
    /// the turn that one player make 
    /// also when the game finish newGame() ask for restart of the game
    /// </summary>
    public class GameLogic
    {
        bool isGameEnded = false;
        public void Play(IPlayer playerFirst, IPlayer playerSecond)
        {
            Board board = new Board();
            IPlayer currentPlayer = playerFirst;

            while (true)
            {
                board.DrawBoard();
                Console.WriteLine(new string('-', 10));
                Console.WriteLine("Psn are numbers from 0 - 2");
                Console.Write("Insert your cordinates (row,col):");


                try
                {
                    int[] cordsSimbol = currentPlayer.ReadCordinates(board.AIcorinates);
                    currentPlayer.PlayTurn(cordsSimbol[0], cordsSimbol[1], board);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }


                if (board.HasWiner(currentPlayer.Simbol))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"The winer is {currentPlayer.Simbol}");
                    Console.ForegroundColor = ConsoleColor.White;
                    board.DrawBoard();
                    isGameEnded = true; 
                }

                if (board.HaveAnyEmptyPsn())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("No winer");
                    Console.ForegroundColor = ConsoleColor.White;
                    isGameEnded = true;
                }

                if (isGameEnded == true)
                {
                    bool newGameStart = newGame();

                    if (newGameStart == true)
                    {
                        board = new Board();
                        isGameEnded = false;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Game over!");
                        return; 
                    }
                }
               

                if (currentPlayer.Simbol == 'X')
                {
                    currentPlayer = playerSecond;
                }
                else
                {
                    currentPlayer = playerFirst;
                }

                Console.Clear();
            }
        }

        private bool newGame()
        {
            bool startNewGame = false;
            Console.WriteLine("Start new game ? Y/N:");

            while (true)
            {
                string newGame = Console.ReadLine();

                if (newGame.ToLower() == "y")
                {
                    startNewGame = true;
                    break;
                }
                else if (newGame.ToLower() == "n")
                {
                    startNewGame = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Enter Y or N");
                }
            }
            
            return startNewGame;
        }
    }
}
