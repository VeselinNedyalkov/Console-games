using System;
using TicTacToe.players;

namespace TicTacToe
{
    public class Program
    {
        /// <summary>
        /// Game menu and start the game - Play()
        /// </summary>
        static void Main()
        {
            GameLogic gameLogic = new GameLogic();
            IPlayer firstPLayer = new Player('X'); 
            IPlayer secondPLayer = new Player('O');
            int coiseGame = 1; ;

            while (true)
            {
                Console.WriteLine("Select game:");
                Console.WriteLine("1 - Player vs Player");
                Console.WriteLine("2 - Player vs AI");
                Console.WriteLine("3 - AI vs Player");
                Console.WriteLine("4 - AI vs AI");
                Console.Write("Select option:");
                try
                {
                    coiseGame = int.Parse(Console.ReadLine());

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                if (coiseGame == 1)
                {
                    firstPLayer = new Player('X');
                    secondPLayer = new Player('O');
                    break;
                }
                else if (coiseGame == 2)
                {
                    firstPLayer = new Player('X');
                    secondPLayer = new AIPlayerRandom('O');
                    break;
                }
                else if (coiseGame == 3)
                {
                    firstPLayer = new AIPlayerRandom('X');
                    secondPLayer = new Player('O');
                    break;
                }
                else if (coiseGame == 4)
                {
                    firstPLayer = new AIPlayerRandom('X');
                    secondPLayer = new AIPlayerRandom('O');
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong entry");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
            }
            Console.Clear();
            gameLogic.Play(firstPLayer, secondPLayer);
        }
    }
}
