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

                while (!match.finish)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.board);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position origin = Screen.readPositionChess().toPosition();
                    bool[,] posPosition = match.board.piece(origin).possibleMovements();

                    Console.Clear();
                    Screen.PrintBoard(match.board, posPosition);


                    Console.Write("Destino: ");
                    Position destination = Screen.readPositionChess().toPosition();

                    match.PerformMoviment(origin, destination);

                }

                Screen.PrintBoard(match.board);
            }
            catch (BoardException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}