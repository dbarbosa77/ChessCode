using ChessCode.board;
using System;
using System.Reflection.PortableExecutable;

namespace ChessCode.chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int round { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finish { get; private set; }

        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;


        public ChessMatch()
        {
            board = new Board(8, 8);
            round = 1;
            currentPlayer = Color.White;
            finish = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();

            SetPieces();
        }

        public void PerformMoviment(Position origin, Position destination)
        {
            Piece p = board.RemovePiece(origin);
            p.IncrementQtymovements();
            Piece PieceObtain = board.RemovePiece(destination);
            board.InsertPiece(p, destination);
            if(PieceObtain != null)
            {
                captured.Add(PieceObtain);
            }
        }

        public void PerformPlay(Position origin, Position destination)
        {
            PerformMoviment(origin, destination);
            round++;
            changePlayer();
        }

        public void ValidateOriginPosition(Position pos)
        {
            if(board.piece(pos) == null)
            {
                throw new BoardException("Não existe peça na posição de origem informada!");
            }
            if(currentPlayer != board.piece(pos).color)
            {
                throw new BoardException("A peça de origem escolhida não é sua!");
            }
            if (!board.piece(pos).existsPossibleMovements())
            {
                throw new BoardException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            if (!board.piece(origin).canMoveTo(destination))
            {
                throw new BoardException("Posição de destino inválida!");
            }
        }

        private void changePlayer() 
        {
            if(currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
        }

        public HashSet<Piece> PiecesObtained(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in captured)
            {
                if(x.color== color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PiecesObtained(color));
            return aux;
        }

        public void placeNewPiece(char column, int line, Piece piece)
        {
            board.InsertPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void SetPieces() 
        {
            placeNewPiece('c', 1, new Tower(board, Color.White));
            placeNewPiece('c', 2, new Tower(board, Color.White));
            placeNewPiece('d', 2, new Tower(board, Color.White));
            placeNewPiece('e', 2, new Tower(board, Color.White));
            placeNewPiece('e', 1, new Tower(board, Color.White));
            placeNewPiece('d', 1, new King(board, Color.White));


            placeNewPiece('c', 7, new Tower(board, Color.Black));
            placeNewPiece('c', 8, new Tower(board, Color.Black));
            placeNewPiece('d', 7, new Tower(board, Color.Black));
            placeNewPiece('e', 7, new Tower(board, Color.Black));
            placeNewPiece('e', 8, new Tower(board, Color.Black));
            placeNewPiece('d', 8, new King(board, Color.Black));
        }
    }
}
