



using System.Net.NetworkInformation;

namespace ChessCode.board
{
    class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines, columns];
        }

        public Piece piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece piece(Position pos)
        {
            return pieces[pos.line, pos.column];
        }

        public void InsertPiece(Piece p, Position pos)
        {
            if (ExistsPiece(pos))
            {
                throw new BoardException("Já existe uma peça nessa posição!");
            }
            pieces[pos.line, pos.column] = p;
            p.position = pos;
        }

        public Piece RemovePiece(Position pos)
        {
            if(piece(pos) == null)
            {
                return null;
            }
            Piece aux = piece(pos);
            aux.position = null;
            pieces[pos.line, pos.column] = null;
            return aux;
        }





        public bool ExistsPiece(Position pos)
        {
            ValidatePosition(pos);
            return piece(pos) != null;
        }






        public bool ValidPosition(Position pos) 
        {
            if (pos.line < 0 || pos.line > lines | pos.column < 0 || pos.column > columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new BoardException("Posição inválida");
            }
        }

    }
}
