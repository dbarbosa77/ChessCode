using ChessCode.board;

namespace ChessCode.chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base( board, color)
        {
        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != this.color;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);
            //acima do rei
            pos.defineValue(position.line - 1, position.column);
            if (board.ValidPosition(pos) && canMove(pos)) 
            {
                mat[pos.line, pos.column] = true;
            }

            //nordeste do rei
            pos.defineValue(position.line - 1, position.column + 1);
            if (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            //direita do rei
            pos.defineValue(position.line, position.column + 1);
            if (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            //esquerda do rei
            pos.defineValue(position.line, position.column - 1);
            if (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            //sudeste do rei
            pos.defineValue(position.line + 1, position.column + 1);
            if (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            //abaixo do rei
            pos.defineValue(position.line + 1, position.column);
            if (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            //sudoeste do rei
            pos.defineValue(position.line + 1, position.column - 1);
            if (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            //noroeste do rei
            pos.defineValue(position.line - 1, position.column - 1);
            if (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            return mat;

        }

        public override string ToString()
        {
            return "R"; // Rei = King
        }

    }
}
