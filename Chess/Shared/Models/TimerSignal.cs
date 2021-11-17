namespace Chess.Shared.Models
{
    public class TimerSignal : Signal
    {
        public string ToUserId { get; set; }
        public string FromUserId { get; set; }
    }
}