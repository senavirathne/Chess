using System;

namespace Chess.Shared.Models
{
    public class SelectCoordinateSignal : Signal
    {
        public SelectCoordinateSignal(int coordinate)
        {
            Coordinate = coordinate;
        }

        public string ToUserId { get; set; }
        public string FromUserId { get; set; }
        public int Coordinate { get; set; }
        public bool IsFirstSquare { get; set; }
    }
}