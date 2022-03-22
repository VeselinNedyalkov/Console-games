using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.players
{
    public class SmartAI
    {
        private char simbol;

        public SmartAI(char simbol)
        {
            this.simbol = simbol;
        }

        public char Simbol { get => simbol; }

        public void PlayTurn(int row, int col, Board board)
        {
            board.PlayerMove(row, col, Simbol);
        }

        public int[] ReadCordinates(List<Position> AIcorinates)
        {
            int[] balabla = new int[2] { 1, 1 };
            //to do recursion
            return balabla;
        }
    }
}
