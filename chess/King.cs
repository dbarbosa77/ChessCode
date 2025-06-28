using ChessCode.board;

namespace ChessCode.chess
{
    class King : Piece
    {

        private ChessMatch match;
        public King(Board board, Color color, ChessMatch match) : base( board, color)
        {
            this.match = match;
        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != this.color;
        }

        private bool RoqueTowerTest(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p is Tower && p.color == this.color && p.qtyMovements == 0;
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


            //#Jogadaespecial roque
            if(qtyMovements == 0 && !match.Check)
            {
                //#jogadaespecial roque pequeno
                Position posT1 = new Position(position.line, position.column + 3);
                if (RoqueTowerTest(posT1))
                {
                    Position p1 = new Position(position.line, position.column + 1);
                    Position p2 = new Position(position.line, position.column + 2);
                    if (board.piece(p1) == null && board.piece(p2) == null)
                    {
                        mat[position.line, position.column + 2] = true;
                    }
                }
                //#jogadaespecial roque grande
                Position posT2 = new Position(position.line, position.column - 4);
                if (RoqueTowerTest(posT2))
                {
                    Position p1 = new Position(position.line, position.column - 1);
                    Position p2 = new Position(position.line, position.column - 2);
                    Position p3 = new Position(position.line, position.column - 3);
                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null)
                    {
                        mat[position.line, position.column - 2] = true;
                    }
                }
            }

            return mat;

        }


        

        public override string ToString()
        {
            return "K"; // K = King
        }

    }
}
