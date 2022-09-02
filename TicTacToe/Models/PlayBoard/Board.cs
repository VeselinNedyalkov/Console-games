using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Contracts;
using TicTacToe.Models.Position;
using TicTacToe.Models.Position.Contract;

namespace TicTacToe.Models.PlayBoard
{
    public class Board : IBoard
    {
        private char[,] board;
        private int numberFreePositions;

        public Board()
        {
            board = new char[3, 3];
            FullTheBoard();
            numberFreePositions = 9;
        }

        public int NumberFreePositions => numberFreePositions;

        private void FullTheBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = '*';
                }
            }
        }
       
        public void AddCharToBoard(IPosition psn, char playersSimbol)
        {
            if (IsPositionEmpty(psn))
            {
                board[psn.Row, psn.Col] = playersSimbol;
            }
            else
            {
                throw new InvalidOperationException("Position is already used!");
            }

            numberFreePositions--;
        }

        public void ReturtDefaultCharForHardAI(IPosition psn, char playersSimbol)
        {
            board[psn.Row, psn.Col] = playersSimbol;
            numberFreePositions++;
        }

        public void PrintBoard()
        {
            Console.Clear();

            for (int row = 0; row < 3; row++)
            {
                Console.WriteLine();
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if(board[row, col] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(board[row, col]);
                    Console.Write(" ");
                }
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        public bool IsPositionEmpty(IPosition psn)
        {
          return board[psn.Row , psn.Col] == '*';
        }

        public List<Positions> TakeAllFreePositions()
        {
            List<Positions> result = new List<Positions>();

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(0); col++)
                {
                    if (board[row,col] == '*')
                    {
                        result.Add(new Positions(row, col));
                    }
                }
            }

            return result;
        }

        public bool IsPlayerWin(char currentChar)
        {
            bool isPlayerWin = false;
            int indexRow = 0;

            //check rows for win
            for (int row = 0; row < board.GetLength(0); row++)
            {
                if (board[row , indexRow] == currentChar && board[row, indexRow + 1] == currentChar &&
                    board[row, indexRow + 2] == currentChar)
                {
                    isPlayerWin = true;
                }
            }

            int indexCol = 0;

            //check cols for win
            for (int col = 0; col < board.GetLength(0); col++)
            {
                if (board[indexCol, col] == currentChar && board[indexCol + 1, col] == currentChar &&
                    board[indexCol + 2, col] == currentChar)
                {
                    isPlayerWin = true;
                }
            }

            //left to right diagonal
            int index = 0;

            if (board[index , index] == currentChar && board[index + 1 , index + 1] == currentChar && 
                board[index + 2, index + 2] == currentChar)
            {
                isPlayerWin = true;
            }

            //right to left diagonal
            int indexTop = 2;

            if (board[index , indexTop] == currentChar && board[index + 1 , indexTop - 1] == currentChar && 
                board[index + 2 , indexTop - 2] == currentChar)
            {
                isPlayerWin = true;
            }

            return isPlayerWin;
        }
    }
}
