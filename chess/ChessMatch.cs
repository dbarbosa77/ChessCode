using ChessCode.board;
using System;

namespace ChessCode.chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        private int round;
        private Color currentPlayer;
        public bool finish { get; private set; }


        public ChessMatch()
        {
            board = new Board(8, 8);
            round = 1;
            currentPlayer = Color.White;
            finish = false;
            SetPieces();
        }

        public void PerformMoviment(Position origin, Position destination)
        {
            Piece p = board.RemovePiece(origin);
            p.IncrementQtymovements();
            Piece PieceObtain = board.RemovePiece(destination);
            board.InsertPiece(p, destination);
        }

        private void SetPieces() 
        {
            board.InsertPiece(new Tower(board, Color.White), new ChessPosition('c',1).toPosition());
            board.InsertPiece(new Tower(board, Color.White), new ChessPosition('c', 2).toPosition());
            board.InsertPiece(new Tower(board, Color.White), new ChessPosition('d', 2).toPosition());
            board.InsertPiece(new Tower(board, Color.White), new ChessPosition('e', 2).toPosition());
            board.InsertPiece(new Tower(board, Color.White), new ChessPosition('e', 1).toPosition());
            board.InsertPiece(new King(board, Color.White), new ChessPosition('d', 1).toPosition());

            board.InsertPiece(new Tower(board, Color.Black), new ChessPosition('c', 7).toPosition());
            board.InsertPiece(new Tower(board, Color.Black), new ChessPosition('c', 8).toPosition());
            board.InsertPiece(new Tower(board, Color.Black), new ChessPosition('d', 7).toPosition());
            board.InsertPiece(new Tower(board, Color.Black), new ChessPosition('e', 7).toPosition());
            board.InsertPiece(new Tower(board, Color.Black), new ChessPosition('e', 8).toPosition());
            board.InsertPiece(new King(board, Color.Black), new ChessPosition('d', 8).toPosition());
        }
    }
}
