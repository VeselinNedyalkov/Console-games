using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Contracts;
using TicTacToe.Models.PlayBoard;
using TicTacToe.Models.Player.Contract;
using TicTacToe.Models.Position;
using TicTacToe.Models.Position.Contract;

namespace TicTacToe.Models.Player
{
    public class UserPlayer : IPlayer
    {
        public IPosition GivePositionToBoard(Board board)
        {
            Console.Write("Chose position (Example 3 2):");
            string[] position = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int numOne;
            int numTwo;

            if (!int.TryParse(position[0], out numOne) || !int.TryParse(position[1], out numTwo))
            {
                throw new ArgumentException("The cordinates are not in proper format!");
            }

            numOne = int.Parse(position[0]);
            numTwo = int.Parse(position[1]);

            return new Positions(numOne, numTwo);
        }
    }
}
