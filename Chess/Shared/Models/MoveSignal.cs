namespace Chess.Shared.Models
{
    public class MoveSignal : ISignal
    {
        public int FromSquare { get; set; }
        public int ToSquare { get; set; }
       
        public Piece MovingPiece { get; set; }

        public string ToUserId { get; set; }
        public string FromUserId { get; set; }

        public MoveSignal()
        {
        }

        public MoveSignal(int fromSquare, int toSquare, Piece movingPiece)
        {
            FromSquare = fromSquare;
            ToSquare = toSquare;
            MovingPiece = movingPiece;
        }
    }
}