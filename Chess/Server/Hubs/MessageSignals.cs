using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            
            
            await Clients.Client(signal.ToUserId).SendAsync("ReceiveStateSignal", signal);
           
        }
        public async Task BoardStringSignal(BoardStringSignal signal)
        {
            await Clients.Client(signal.ToUserId).SendAsync("ReceiveBoardStringSignal", signal);
           
        }
        public async Task MoveSignal(MoveSignal moveSignal)
        {
            var users = new List<string>{ moveSignal.ToUserId, moveSignal.FromUserId };
            await Clients.Clients(users).SendAsync("ReceiveMoveSignal", moveSignal);
            
        }
        public async Task SelectCoordinateSignal(SelectCoordinateSignal signal)
        {
            var users = new List<string>{ signal.ToUserId, signal.FromUserId };
            await Clients.Clients(users).SendAsync("ReceiveSelectCoordinateSignal", signal);
            
        }
        public async Task TimerSignal(TimerSignal signal)
        {
            
            var users = new List<string>{ signal.ToUserId, signal.FromUserId };
            await Clients.Clients(users).SendAsync("ReceiveTimerSignal", signal);
           
        }

        public override Task OnConnectedAsync()
        {
            //
            // Clients.All.e
            // var users = new[] { signal.ToUserId, signal.FromUserId };
            // await Clients.Users(users).SendAsync("ReceiveStateSignal", signal);
            return base.OnConnectedAsync();
        }
       

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}