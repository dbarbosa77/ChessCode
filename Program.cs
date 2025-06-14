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
                ChessMatch match = new ChessMatch();

                Screen.PrintBoard(match.board);
            }
            catch (BoardException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}