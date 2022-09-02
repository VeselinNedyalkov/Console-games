using System;
using TicTacToe.Core;

namespace TicTacToe
{
    public class Program : EndGameMenu
    {
        static void Main(string[] args)
        {
            EndGameMenu end = new EndGameMenu();
            Engine engine = new Engine();
           
            engine.Run();
            end.EndMenu(engine);
        }
    }
}
