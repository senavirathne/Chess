using System.Collections.Generic;
using System.Threading.Tasks;
using Chess.Shared.Models;
using Microsoft.AspNetCore.SignalR;

namespace Chess.Server.Hubs
{
    public interface IState
    {
        Task ReceiveSignal(StateSignal stateSignal);
    }
    public class StateHub : Hub<IState>
    {
        public async Task SendSignal(StateSignal stateSignal)
        {
            var users = new [] {stateSignal.ToUserId,stateSignal.FromUserId };
            await Clients.Users(users).ReceiveSignal(stateSignal);
            // await Clients.All.SendAsync("ReceiveSignal", message);
        }
        
    }
}