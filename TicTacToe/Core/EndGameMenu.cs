using System;

namespace TicTacToe.Core
{
    public class EndGameMenu
    {

        public  void EndMenu(Engine engine)
        {
            Console.WriteLine("If you want to start the game again press Y");
            Console.WriteLine("To close press any key");

            string gameProceed = Console.ReadLine();

            switch (gameProceed)
            {
                case "y":
                    engine.Run();
                    break;
                default:
                    break;
            }
        }
    }
}