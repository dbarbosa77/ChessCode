using ChessCode.board;

namespace ChessCode.chess
{
    class Tower : Piece
    {
        public Tower(Board board, Color color) : base(board, color)
        {
        }


        private bool canMove(Position pos) //testa se na casa está livre ou tem adversário
        {
            Piece p = board.piece(pos);
            return p == null || p.color != this.color;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);
            //acima da torre
            pos.defineValue(position.line - 1, position.column);
            while (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.line = pos.line - 1;
            }

            //abaixo da torre
            pos.defineValue(position.line + 1, position.column);
            while (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.line = pos.line + 1;
            }

            //direita da torre
            pos.defineValue(position.line, position.column + 1);
            while (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.column = pos.column + 1;
            }

            //esquerda da torre
            pos.defineValue(position.line, position.column - 1);
            while (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.column = pos.column - 1;
            }

            return mat;

        }

        public override string ToString()
        {
            return "T"; // Torre = Tower
        }

    }
}
