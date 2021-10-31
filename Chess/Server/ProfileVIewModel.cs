using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Chess.Server.Models;
using Chess.Shared.Models;

namespace Chess.Client.ViewModels
{
    public class ProfileVIewModel : IProfileVIewModel
    {
        private readonly HttpClient _httpClient;
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Signal { get; set; }
        
        public string ProfilePictureUrl { get; set; }


        public static implicit operator User(ProfileVIewModel profileViewModel)
        {
            return new()
            {
                FirstName = profileViewModel.FirstName,
                LastName = profileViewModel.LastName,
                EmailAddress = profileViewModel.EmailAddress,
                UserId = profileViewModel.UserId,
                ProfilePictureUrl = profileViewModel.ProfilePictureUrl
            };
        }

        public static implicit operator ProfileVIewModel(User user)
        {
            return new()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                UserId = user.UserId,
                ProfilePictureUrl = user.ProfilePictureUrl
            };
        }

        public ProfileVIewModel()
        {
        }

        public ProfileVIewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task UpdateProfile()
        {
            User user = this;
            await _httpClient.PutAsJsonAsync("profile/updateprofile/" + UserId, user);
            Signal = "Profile updated successfully";
        }

        public async Task GetProfile()
        {
            var user = await _httpClient.GetFromJsonAsync<User>("profile/getprofile/" + UserId);
            LoadCurrentObject(user);
            Signal = "Profile loaded successfully";
        }

        private void LoadCurrentObject(ProfileVIewModel profileVIewModel)
        {
            FirstName = profileVIewModel.FirstName;
            LastName = profileVIewModel.LastName;
            EmailAddress = profileVIewModel.EmailAddress;
            UserId = profileVIewModel.UserId;
            ProfilePictureUrl = profileVIewModel.ProfilePictureUrl;
        }
    }
}