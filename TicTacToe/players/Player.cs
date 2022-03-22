using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    internal class Player : IPlayer
    {
        private char simbol ;

        public Player(char simbol)
        {
            this.simbol = simbol;
        }

        public char Simbol { get => simbol; }

        public void PlayTurn(int row , int col, Board board)
        {
            while (true)
            {
                if (board.IsPsnEmpty(row,col))
                {
                    board.PlayerMove(row, col, Simbol);
                    break;
                }
                else
                {
                    throw new Exception("Wrong cordinates! Try Again");
                }
            }
           
        }

        public int[] ReadCordinates(List<Position> AIcorinates)
        {
            int[] cordsSimbol = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            return cordsSimbol;
        }
    }
}
