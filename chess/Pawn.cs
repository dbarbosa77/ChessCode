using ChessCode.board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCode.chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color) 
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existsEnemy(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p.color != this.color;
        }

        private bool free(Position pos)
        {
            return board.piece(pos) == null;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            if(color == Color.White)
            {
                pos.defineValue(position.line - 1, position.column);
                if(board.ValidPosition(pos) && free(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValue(position.line - 2, position.column);
                if (board.ValidPosition(pos) && free(pos) && qtyMovements == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValue(position.line - 1, position.column - 1);
                if (board.ValidPosition(pos) && existsEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValue(position.line - 1, position.column + 1);
                if (board.ValidPosition(pos) && existsEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
            }
            else
            {
                pos.defineValue(position.line + 1, position.column);
                if (board.ValidPosition(pos) && free(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValue(position.line + 2, position.column);
                if (board.ValidPosition(pos) && free(pos) && qtyMovements == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValue(position.line + 1, position.column - 1);
                if (board.ValidPosition(pos) && existsEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValue(position.line + 1, position.column + 1);
                if (board.ValidPosition(pos) && existsEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
            }
            return mat;
        }
    }
}
