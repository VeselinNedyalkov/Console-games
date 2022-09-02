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
    public class HardRandomAI : IPlayer
    {
        char defaultChar = '*';
        List<Positions> freePositions;

        public IPosition GivePositionToBoard(Board board)
        {
            var emtpyPositions = board.TakeAllFreePositions();
            freePositions = board.TakeAllFreePositions();
            char currentChar = 'O';
            char AiPlayer = 'O';
            

            int bestMoveIndex = int.MinValue;
            IPosition bestPsn = null;

            foreach (var bestMove in emtpyPositions)
            {

                int value = CalculateBestPosition(board, AiPlayer ,  currentChar == 'X' ? currentChar = 'O' : currentChar = 'X');

                if (value > bestMoveIndex)
                {
                    value = bestMoveIndex;
                    bestPsn = bestMove;
                }
            }

            return bestPsn;
        }

        private int CalculateBestPosition( Board board, char AiPlayer,  char currentChar)
        {
            board.PrintBoard();

            if (board.IsPlayerWin(currentChar) || board.NumberFreePositions == 0)
            {
                char winner = currentChar;

                if (board.NumberFreePositions == 0)
                    return 0;

                if (winner == AiPlayer)
                    return 1;

                return -1;
            }

            currentChar = currentChar == 'O' ?  'X' :  'O';

            var bestVale = AiPlayer == currentChar ? -100 : 100;
            

            foreach (var freePsn in freePositions)
            {
                
                board.AddCharToBoard(freePsn , currentChar);
                var value  = CalculateBestPosition(board, AiPlayer, currentChar );
                board.PrintBoard();
                board.ReturtDefaultCharForHardAI(freePsn, defaultChar);

                bestVale = currentChar == AiPlayer ? Math.Max(bestVale, value) : Math.Min(bestVale, value);
            }

            return bestVale;
        }
    }
} 
