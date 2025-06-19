using System;
using System.Net.NetworkInformation;
using System.Threading.Channels;
using ChessCode.board;
using ChessCode.chess;

namespace ChessCode
{
    class Screen
    {

        public static void PrintMatch(ChessMatch match)
        { 
            PrintBoard(match.board);
            Console.WriteLine();
            PrintObtainedPieces(match);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Turno: " + match.round);
            Console.WriteLine("Aguardando jogada: " + match.currentPlayer);
        }

        public static void PrintObtainedPieces(ChessMatch match)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            PrintSet(match.PiecesObtained(Color.White));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(match.PiecesObtained(Color.Black));
            Console.ForegroundColor = aux;
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach(Piece x in set)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    PrintPiece(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor AlternativeBackground = ConsoleColor.DarkGray;


            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = AlternativeBackground;

                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(board.piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static ChessPosition readPositionChess()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }

        public static void PrintPiece(Piece piece)
        {
            if(piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
