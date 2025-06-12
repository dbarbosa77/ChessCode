using ChessCode.board;

namespace ChessCode.chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base( board, color)
        {
        }

        public override string ToString()
        {
            return "R"; // Rei = King
        }

    }
}
