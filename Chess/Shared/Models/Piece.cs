using System;
using System.ComponentModel;

namespace Chess.Shared.Models
{
    public class Piece
    {
        public bool? Color { get; set; } //empty square is a piece and it's color is null
        public PieceType Type { get; set; } //empty square is a piece 

        public Piece()
        {
            Type = PieceType.mt;
        }
    }

    public class WhitePiece : Piece
    {
        public WhitePiece()
        {
            Color = true;
        }

        public WhitePiece(PieceType type) : this()
        {
            if (type is PieceType.wr or PieceType.wn or PieceType.wb or PieceType.wq or PieceType.wk or PieceType.wp)
            {
                Type = type;
            }
            else
            {
                throw new Exception("whitePiece is not assigned white piece type");
            }
                
        }
    }

    public class BlackPiece : Piece
    {
        public BlackPiece()
        {
            Color = false;
        }


        public BlackPiece(PieceType type) : this()
        {
            if (type is PieceType.br or PieceType.bn or PieceType.bb or PieceType.bq or PieceType.bk or PieceType.bp)
            {
                Type = type;
            }
            else
            {
                throw new Exception("blackPiece is not assigned black piece type");
            }
        }
    }


    // }
    // public class Square
    // {
    //     public int Xcoordinate { get; set; }
    //     public int Ycoordinate { get; set; }
    //
    //     public Square(int x, int y)
    //     {
    //         Xcoordinate = x;
    //         Ycoordinate = y;
    //     }
    //
    //     
    // }

    public enum PieceType
    {
        wr,
        wn,
        wb,
        wq,
        wk,
        wp,
        bp,
        br,
        bn,
        bb,
        bq,
        bk,
        mt
    }
}