using ChessCode.board;
using ChessCode.chess;
using System;
using System.ComponentModel;

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
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);
                        Console.WriteLine();

                        Console.Write("Origem: ");
                        Position origin = Screen.readPositionChess().toPosition();
                        match.ValidateOriginPosition(origin);

                        bool[,] posPosition = match.board.piece(origin).possibleMovements();

                        Console.Clear();
                        Screen.PrintBoard(match.board, posPosition);


                        Console.Write("Destino: ");
                        Position destination = Screen.readPositionChess().toPosition();
                        match.ValidateDestinationPosition(origin, destination);

                        match.PerformPlay(origin, destination);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintBoard(match.board);
            }
            catch (BoardException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}