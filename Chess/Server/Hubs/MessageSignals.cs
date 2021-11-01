using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chess.Shared.Models;
using Microsoft.AspNetCore.SignalR;

namespace Chess.Server.Hubs
{

    public class SignalHub : Hub
    {
        public async Task StateSignal(StateSignal signal)
        {
            
            var users = new[] { signal.ToUserId, signal.FromUserId };
            await Clients.Users(users).SendAsync("ReceiveStateSignal", signal);
           
        }
        public async Task MoveSignal(MoveSignal moveSignal)
        {
            var users = new[] { moveSignal.ToUserId, moveSignal.FromUserId };
            await Clients.Users(users).SendAsync("ReceiveMoveSignal", moveSignal);
            
        }
        public async Task SelectCoordinateSignal(SelectCoordinateSignal signal)
        {
            var users = new[] { signal.ToUserId, signal.FromUserId };
            await Clients.Users(users).SendAsync("ReceiveSelectCoordinateSignal", signal);
            
        }
        public async Task TimerSignal(TimerSignal signal)
        {
            
            var users = new[] { signal.ToUserId, signal.FromUserId };
            await Clients.Users(users).SendAsync("ReceiveTimerSignal", signal);
           
        }
    }
}