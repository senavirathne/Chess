using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Chess.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace Chess.Client
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;

        public CustomAuthenticationStateProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            User currentUser = await _httpClient.GetFromJsonAsync<User>("user/getcurrentuser");

            if (currentUser != null && currentUser.EmailAddress != null)
            {
                //create a claim
                var claimEmailAddress = new Claim(ClaimTypes.Name, currentUser.EmailAddress);
                var claimNameIdentifier = new Claim(ClaimTypes.NameIdentifier, currentUser.UserId.ToString());
                // var firstName = new Claim(ClaimTypes.NameIdentifier, currentUser.FirstName);
                //create claimsIdentity
                var claimsIdentity = new ClaimsIdentity(new[] {claimEmailAddress, claimNameIdentifier}, "serverAuth");
                //create claimsPrincipal
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                return new AuthenticationState(claimsPrincipal);
            }

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }
}