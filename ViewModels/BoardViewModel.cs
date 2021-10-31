using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Chess.Shared.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace Chess.Client.ViewModels
{
    public class BoardViewModel : IBoardViewModel
    {
        public bool IsAllowToMove { get; set; }
        public bool IsMyColorWhite { get; set; }
        public Piece MovingPiece { get; set; }
        public int FromSquare { get; set; }
        public int ToSquare { get; set; }
        public string HighLightedSquare1 { get; set; }
        public string HighLightedSquare2 { get; set; }
        public MoveSignal MoveSignal { get; set; }
        public Dictionary<int, Piece> ChessBoard { get; set; }
        public string Flipped { get; set; }
        public StateSignal MyState { get; set; }
        public bool ToUserState { get; set; }
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}