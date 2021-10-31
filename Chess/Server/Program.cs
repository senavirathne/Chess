using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess.Shared.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Chess.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
           

            // var chessBoard = ChessBoard.Reset();
            // foreach (var key in chessBoard.Keys)
            // {
            //     var y = $"<div class=\"piece @(ChessBoard[{key}]) square-{key}\" @onclick=\"() => Test({key})\" ></div>";
            //     // var  x = $"<div class=\"piece {chessBoard[key]} square-{key}\" style=\"\" ></div>";
            //     Console.WriteLine(y);
            //
            // }



            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
