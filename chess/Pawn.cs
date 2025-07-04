﻿using ChessCode.board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCode.chess
{
    class Pawn : Piece
    {
        private ChessMatch match;
        public Pawn(Board board, Color color, ChessMatch match) : base(board, color) 
        {
            this.match = match;
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

                //#jogadaespecial en passant
                if (position.line == 3)
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (board.ValidPosition(left) && existsEnemy(left) && board.piece(left) == match.vulnerableEnPassant)
                    {
                        mat[left.line - 1, left.column] = true;
                    }
                    Position right = new Position(position.line, position.column + 1);
                    if (board.ValidPosition(right) && existsEnemy(right) && board.piece(right) == match.vulnerableEnPassant)
                    {
                        mat[right.line - 1, right.column] = true;
                    }
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
                //#jogadaespecial en passant
                if (position.line == 4)
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (board.ValidPosition(left) && existsEnemy(left) && board.piece(left) == match.vulnerableEnPassant)
                    {
                        mat[left.line + 1, left.column] = true;
                    }
                    Position right = new Position(position.line, position.column + 1);
                    if (board.ValidPosition(right) && existsEnemy(right) && board.piece(right) == match.vulnerableEnPassant)
                    {
                        mat[right.line + 1, right.column] = true;
                    }
                }
            }
            return mat;
        }
    }
}
