using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    /// <summary>
    /// all methods needed for the board
    /// DrawBoard() - draw the board
    /// IsPsnEmpty() - check if is possible to place the simbol
    /// PlayerMove() - when you place simbol remove the cordinates from the list
    /// HaveAnyEmptyPsn() - if all psn are full game end
    /// HasWiner() - if one of the players won
    /// </summary>
    public class Board
    {
        private List<Position> emptyPsn;
        private char[,] ticTackTowBoard;
        public Board()
        {
            ticTackTowBoard = new char[3, 3];
            emptyPsn = new List<Position>();

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Position empty = new Position(row, col);
                    emptyPsn.Add(empty);
                    ticTackTowBoard[row, col] = '*';
                }
            }
        }

        public int EmptyPsn { get => emptyPsn.Count; }
        public List<Position> AIcorinates { get => emptyPsn; }

        
        public void DrawBoard()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(ticTackTowBoard[row,col]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

       

        public void IsPsnEmpty(Position psn)
        {
            if (!AIcorinates.Any(x => x.Row == psn.Row && x.Column == psn.Column))
            {
                throw new IndexOutOfRangeException("Cordinates are out of range or already player use this position!");
            }
            
            
        }

        public void PlayerMove(Position psn, char simbol)
        {
            Position delete = emptyPsn.Single(x => x.Row == psn.Row && x.Column == psn.Column);
            emptyPsn.Remove(delete);
            ticTackTowBoard[psn.Row, psn.Column] = simbol;
        }

        public bool HaveAnyEmptyPsn()
        {
            bool isGameOver = false;
            if (emptyPsn.Count == 0)
            {
                isGameOver = true;
            }
            return isGameOver;
        }

        public bool HasWiner(char simbol)
        {
            bool haveWiner = false;
            int counter = 0;

            for (int row = 0; row < 3; row++)
            {
                counter = 0;
                for (int col = 0; col < 3; col++)
                {
                    if (ticTackTowBoard[row,col] != simbol)
                    {
                        counter = 0;
                        continue;
                    }
                    else
                    {
                        counter++;
                        if (counter == 3)
                        {
                            haveWiner = true;

                        }
                    }
                }              
            }

            
            for (int col = 0; col < 3; col++)
            {
                counter = 0;
                for (int row = 0; row < 3; row++)
                {
                    if (ticTackTowBoard[row, col] != simbol)
                    {
                        counter = 0;
                        continue;
                    }
                    else
                    {
                        counter++;
                        if (counter == 3)
                        {
                            haveWiner = true;

                        }
                    }
                }
            }

            
            for (int row = 0; row < 3; row++)
            {
                counter = 0;
                for (int col = 0; col < 3; col++)
                {
                    if (row == col)
                    {
                        if (ticTackTowBoard[row, col] != simbol)
                        {
                            counter = 0;
                            continue;
                        }
                        else
                        {
                            counter++;
                            if (counter == 3)
                            {
                                haveWiner = true;

                            }
                        }
                    }
                }
            }

            counter = 0;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 3; col >= 0; col--)
                {
                    if (row == col)
                    {
                        if (ticTackTowBoard[row, col] != simbol)
                        {
                            counter = 0;
                            continue;
                        }
                        else
                        {
                            counter++;
                            if (counter == 3)
                            {
                                haveWiner = true;

                            }
                        }
                    }
                }
            }

            counter = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ticTackTowBoard[i, 3 - i - 1] != simbol)
                {
                    break;
                }
                else
                {
                    counter++;
                    if (counter == 3)
                    {
                        haveWiner = true;

                    }
                }
            }

            return haveWiner;
        }
    }
}
