using ChessCode.board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCode.chess
{
    class Horse : Piece
    {
        public Horse(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "H";
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

            pos.defineValue(position.line - 1, position.column - 2);
            if(board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.defineValue(position.line - 2, position.column - 1);
            if(board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.defineValue(position.line - 2, position.column + 1);
            if(board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.defineValue(position.line - 1, position.column + 2);
            if (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.defineValue(position.line + 1, position.column + 2);
            if (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.defineValue(position.line + 2, position.column + 1);
            if (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.defineValue(position.line + 2, position.column - 1);
            if (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.defineValue(position.line + 1, position.column - 2);
            if (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            return mat;
        }
    }
}
