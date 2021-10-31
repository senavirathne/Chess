using System.Collections.Generic;
using System.Threading.Tasks;
using Chess.Shared.Models;
using Microsoft.AspNetCore.SignalR;

namespace Chess.Server.Hubs
{

    public class SignalHub : Hub
    {
        public async Task StateSignal(StateSignal Signal)
        {
            
            var users = new[] { Signal.ToUserId, Signal.FromUserId };
            await Clients.Users(users).SendAsync("ReceiveStateSignal", Signal);
           
        }
        public async Task MoveSignal(MoveSignal moveSignal)
        {
            var users = new[] { moveSignal.ToUserId, moveSignal.FromUserId };
            await Clients.Users(users).SendAsync("ReceiveMoveSignal", moveSignal);
            
        }
        public async Task SelectCoordinateSignal(SelectCoordinateSignal Signal)
        {
            var users = new[] { Signal.ToUserId, Signal.FromUserId };
            await Clients.Users(users).SendAsync("ReceiveSelectCoordinateSignal", Signal);
            
        }
    }
}