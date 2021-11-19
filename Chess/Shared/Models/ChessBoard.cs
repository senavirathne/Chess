using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Shared.Models
{
    public class ChessBoard
    {
        public Dictionary<int, Piece> Board { get; set; } = new();
        private static int ToCoordinate(int x, int y)
        {
            return int.Parse($"{x}{y}");
        }

        public ChessBoard() : this("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR")
        {
            
        }
        

        public ChessBoard(string fen)
        {
            BoardSet(fen);
        }
        
        public void BoardSet(string fen)
        {
    
            var i = 1;
            var j = 8;
            foreach (var letter in fen)
            {
                if (letter == 47 || i == 9) //"/"
                {
                    i = 1;
                    j -= 1;
                }
                else if (letter < 58) //empty
                {
                    for (var k = 1; k <= letter - 48; k++)
                    {
                        SetPiece(ToCoordinate(i, j), new Piece());
                        i++;
                    }
                }

                else if (letter < 83) //white
                {
                    var piece = $"w{letter.ToString().ToLower()}";
                    var type = Enum.Parse<PieceType>(piece);
                    SetPiece(ToCoordinate(i, j), new WhitePiece(type));
                    i++;
                }
                else if (letter < 115) // black
                {
                    var piece = $"b{letter.ToString()}";
                    var type = Enum.Parse<PieceType>(piece);
                    SetPiece(ToCoordinate(i, j), new BlackPiece(type));
                    i++;
                }
            }
   
        }

        private void SetPiece(int key, Piece piece)
        {
            if (Board.ContainsKey(key))
            {
                Board[key] = piece;
            }
            else
            {
                Board.Add(key,piece);
            }
        }
        public override string ToString()
        {
            var boardString = new StringBuilder();
            var emptySquareCount = 0;
            var i = 1;
                    
            foreach (var value in Board.Values) // without considering key order
            {
                var piece = "";
                if (i == 9) 
                {
                    i = 1;
                    emptySquareCount = 0;
                    piece = "/";
                    boardString.Append(piece);
                }
                if (value.Color != null)
                {
                    i++;
                    emptySquareCount = 0;
                    piece = value.Color.Value ? value.Type.ToString().Remove(0,1).ToUpper() : value.Type.ToString().Remove(0,1);
                    boardString.Append(piece);
                            
                }
                else
                {
                            
                            
                            
                    if (emptySquareCount > 0)
                    {
                        emptySquareCount++;
                        boardString.Remove(boardString.Length -1, 1).Append(emptySquareCount);
                                
                    }
                    else
                    {
                        emptySquareCount++;
                        boardString.Append(emptySquareCount);
                    }
                    i++;


                }
                        
            }

            return boardString.ToString();
            
        }
    }
}