using ChessCode.board;
using ChessCode.chess;
using System;

namespace ChessCode
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);
                board.InsertPiece(new Tower(board, Color.Black), new Position(0, 0));
                board.InsertPiece(new Tower(board, Color.Black), new Position(1, 3));
                board.InsertPiece(new King(board, Color.Black), new Position(2, 4));

                Screen.PrintBoard(board);
            }
            catch (BoardException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}