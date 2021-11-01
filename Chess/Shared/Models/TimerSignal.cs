namespace Chess.Shared.Models
{
    public class TimerSignal : ISignal
    {
        public string ToUserId { get; set; }
        public string FromUserId { get; set; }
        public bool IsTimerRunning { get; set; }

        public TimerSignal()
        {
            IsTimerRunning = false;
        }
    }
}