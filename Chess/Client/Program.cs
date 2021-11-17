using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Chess.Client.ViewModels;
using Chess.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;



namespace Chess.Client
{
    public class Program
    {
        
        public static async Task Main(string[] args)
        {
            
            
            
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            // builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddHttpClient<IProfileVIewModel, ProfileVIewModel>(
                "GameChessClient",client =>client.BaseAddress =new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddHttpClient<ILoginViewModel, LoginViewModel>(
                "GameChessClient",client =>client.BaseAddress =new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthenticationStateProvider>();
            builder.Services.AddScoped<ISetUpViewModel,SetUpViewModel>();
            builder.Services.AddSingleton<ClipboardService>();
            builder.Services.AddBlazoredLocalStorage();

            await builder.Build().RunAsync();
        }
    }
}
