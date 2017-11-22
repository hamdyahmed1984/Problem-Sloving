using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Moderate
{
    /// <summary>
    /// 16.4 Tic Tac Win: Design an algorithm to figure out if someone has won a game of tic-tac-toe.
    /// </summary>
    class TicTacToe_Win
    {
        public void Test()
        {
            Piece[][] board = new Piece[3][]
            {
                new Piece[3]{Piece.Empty,Piece.O,Piece.X},
                new Piece[3]{Piece.Empty,Piece.X,Piece.Empty},
                new Piece[3]{Piece.X,Piece.O,Piece.O}
            };
            Piece winner = HasWon_3x3(board);
            winner = HasWon_NxN(board);
        }
        enum Piece
        {
            Empty, X, O
        }

        Piece HasWon_3x3(Piece[][] board)
        {
            if (board.Length == 0 || board[0].Length != board.Length) return Piece.Empty;

            int size = board.Length;
            for(int i = 0; i < size; i++)
            {
                //Check row
                if (HasWinner_3x3(board[i][0], board[i][1], board[i][2]))
                    return board[i][0];

                //Check column
                if (HasWinner_3x3(board[0][i], board[1][i], board[2][i]))
                    return board[0][i];                
            }
            //Check normal diagonal
            if (HasWinner_3x3(board[0][0], board[1][1], board[2][2]))
                return board[0][0];

            //Check reverse diagonal
            if (HasWinner_3x3(board[0][2], board[1][1], board[2][0]))
                return board[0][2];

            return Piece.Empty;
        }

        private bool HasWinner_3x3(Piece piece1, Piece piece2, Piece piece3)
        {
            if (piece1 == Piece.Empty) return false;
            return piece1 == piece2 && piece2 == piece3;
        }

        private Piece HasWon_NxN(Piece[][] board)
        {
            if (board.Length == 0 || board[0].Length != board.Length) return Piece.Empty;

            int size = board.Length;
            Piece first;

            //Check rows
            for(int i = 0; i < size; i ++)
            {
                first = board[i][0];
                if (first == Piece.Empty) continue;
                for(int j = 1;  j < size; j++)
                {
                    if (board[i][j] != first) break;
                    if (j == size - 1)//Reached the end of row and all previous columns are equal to the first column
                        return first;
                }
            }

            //Check columns
            for(int i = 0; i < size; i++)
            {
                first = board[0][i];
                if (first == Piece.Empty) continue;
                for(int j = 1; j < size; j++)
                {
                    if (board[j][i] != first) break;
                    if (j == size - 1)//Reached the end of row and all previous columns are equal to the first column
                        return first;
                }
            }

            //Check normal diagonal
            first = board[0][0];
            if (first != Piece.Empty)
            {
                for (int i = 1; i < size; i++)
                {
                    if (board[i][i] != first) break;
                    if (i == size - 1)//Reached the end of normal diagonal and all previous cells of the diagonal are equal to the first cell
                        return first;
                }
            }

            //Check reverse normal diagonal
            first = board[0][2];
            if (first != Piece.Empty)
            {
                for (int i = 1; i < size; i++)
                {
                    if (board[i][size - 1 - i] != first) break;
                    if (i == size - 1)//Reached the end of reverse diagonal(row = 0) and all previous cells of the diagonal are equal to the first cell
                        return first;
                }
            }

            return Piece.Empty;
        }
    }
}
