using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Position;
using TicTacToe.Models.Position.Contract;

namespace TicTacToe.Models.Contracts
{
    public interface IBoard
    {
        private  void FullTheBoard() { }

        public void AddCharToBoard(IPosition psn, char playersSimbol);

        public bool IsPositionEmpty(IPosition psn);

        public void PrintBoard();

        public void ReturtDefaultCharForHardAI(IPosition psn, char playersSimbol);

        public bool IsPlayerWin(char currentChar);

    }
}
