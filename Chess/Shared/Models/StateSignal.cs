namespace Chess.Shared.Models
{
    public class StateSignal : ISignal
    {
        public string ToUserId { get; set; }
        public string FromUserId { get; set; }
        public bool IsOnline { get; set; }
       
    }
}