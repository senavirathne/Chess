using System.Collections.Generic;

namespace Chess.Shared.Models
{
    public class BoardStringSignal
    {
        public string ToUserId { get; set; }
        public int LastMoveNo { get; set; }

        public string BoardString { get; set; }
        public List<string> BoardStrings { get; set; }

        public BoardStringSignal(string toUserId)
        {
            ToUserId = toUserId;
            
        }
    }
}