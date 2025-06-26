using ChessCode.board;


namespace ChessCode.chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base (board, color) 
        {

        }

        public override string ToString()
        {
            return "B";
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

            //Noroeste
            pos.defineValue(position.line - 1, position.column - 1);
            while (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if(board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.defineValue(pos.line - 1, pos.column + 1);
            }

            //Nordeste
            pos.defineValue(position.line - 1, position.column + 1);
            while (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.defineValue(pos.line - 1, pos.column + 1);
            }

            //Sudeste
            pos.defineValue(position.line + 1, position.column + 1);
            while (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.defineValue(pos.line + 1, pos.column + 1);
            }

            //Sudoeste
            pos.defineValue(position.line + 1, position.column - 1);
            while (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.defineValue(pos.line + 1, pos.column - 1);
            }
            return mat;
        }
    }
}
