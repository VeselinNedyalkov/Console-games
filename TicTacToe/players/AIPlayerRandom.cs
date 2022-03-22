using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.players
{
    public class AIPlayerRandom : IPlayer
    {
        private char simbol ;

        public AIPlayerRandom(char simbol)
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
            int[] aiCordinatesChoise = new int[2];
            Random r = new Random();
            var random = AIcorinates[r.Next(0, AIcorinates.Count)];
            aiCordinatesChoise[0] = random.Row;
            aiCordinatesChoise[1] = random.Column;
            return aiCordinatesChoise;
        }
    }
}
