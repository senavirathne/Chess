using System.Threading.Tasks;

namespace Chess.Client.ViewModels
{
    // is this nessessry 
    public interface ISetUpViewModel
    {
        public bool IsMyColorWhite { get; set; }
        public string OpponentId { get; set; }
        public bool IsTimerSet { get; set; }
        public string TimeOut { get; set; }
        public string IncrementTimerBy { get; set; }

        


    }
}