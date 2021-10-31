namespace Chess.Shared.Models
{
    public interface ISignal
    {
        public string ToUserId { get; set; }
        public string FromUserId { get; set; }
    }
}