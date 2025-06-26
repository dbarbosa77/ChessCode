using ChessCode.board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCode.chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color) 
        {
        }
        public override string ToString()
        {
            return "Q";
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
            //acima
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

            //abaixo
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

            //direita
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

            //esquerda
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

            //Noroeste
            pos.defineValue(position.line - 1, position.column - 1);
            while (board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
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
