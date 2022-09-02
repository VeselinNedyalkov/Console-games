using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Contracts;
using TicTacToe.Models.PlayBoard;
using TicTacToe.Models.Position;
using TicTacToe.Models.Position.Contract;

namespace TicTacToe.Models.Player.Contract
{
    public class RandomAI : IPlayer
    {
        Random randomNum;

        public RandomAI()
        {
            randomNum = new Random();
        }

        public IPosition GivePositionToBoard(Board board)
        {
            int row = randomNum.Next(0, 3);
            int col = randomNum.Next(0, 3);

            IPosition position = new Positions(row, col);
            return position;
        }
    }
}
