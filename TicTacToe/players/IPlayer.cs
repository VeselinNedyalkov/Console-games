using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public interface IPlayer
    {
        public char Simbol { get;}
        public void PlayTurn(int row, int col, Board board);

        public int[] ReadCordinates(List<Position> AIcorinates);
    }
}
