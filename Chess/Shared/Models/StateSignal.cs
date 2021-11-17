namespace Chess.Shared.Models
{
    public class StateSignal 
    {

        public int LastMoveNo { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }



        public StateSignal(int lastMoveNo,string fromUserId, string toUserId)
        {
            LastMoveNo = lastMoveNo;
            FromUserId = fromUserId;
            ToUserId = toUserId;
        }

        
    }
}