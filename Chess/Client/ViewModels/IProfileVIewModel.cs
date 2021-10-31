using System.Threading.Tasks;


namespace Chess.Client.ViewModels
{
    public interface IProfileVIewModel
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Signal { get; set; }
        
        public string ProfilePictureUrl { get; set; }
        
        public Task UpdateProfile();
        public Task GetProfile();
    }
}