using TicTacToe.Models.PlayBoard;
using TicTacToe.Models.Position.Contract;

namespace TicTacToe.Models.Player.Contract
{
    public interface IPlayer
    {
        public IPosition GivePositionToBoard(Board board);
    }
}
