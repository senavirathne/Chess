using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using Chess.Shared.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;

namespace Chess.Server
{
    public static class ChessBoard
    {
        public static Dictionary<int, Piece> Board { get; set; } = new();


        private static int ToInt(int x, int y)
        {
            return int.Parse($"{x}{y}");
        }
        public static  Dictionary<int, Piece> Reset()
        {
            var pieces = Enum.GetValues(typeof(Piece)).ToDynamicList();

            for (var j = 1; j <= 8; j++)
            {
                switch (j)
                {
                    case 1:
                    {
                        var i = 0;
                        var k = 3;

                        while (i < 8)
                        {
                            if (i < 5)
                            {
                                Board.Add(ToInt(i + 1, j), pieces[i]);
                            }
                            else
                            {
                                Board.Add(ToInt(i + k, j), pieces[i - 5]);
                                k -= 2;
                            }

                            i++;
                        }

                        break;
                    }
                    case 2:
                    {
                        for (var i = 1; i <= 8; i++)
                        {
                            Board.Add(ToInt(i, j), pieces[5]);
                        }

                        break;
                    }
                    case > 2 and < 7:
                    {
                        for (var i = 1; i <= 8; i++)
                        {
                            Board.Add(ToInt(i, j), pieces[12]);
                        }

                        break;
                    }
                    case 7:
                    {
                        for (var i = 1; i <= 8; i++)
                        {
                            Board.Add(ToInt(i, j), pieces[6]);
                        }

                        break;
                    }
                    case 8:
                    {
                        var i = 0;
                        var k = 3;

                        while (i < 8)
                        {
                            if (i < 5)
                            {
                                // 0 -> 7
                                Board.Add(ToInt(i + 1, j), pieces[i + 7]);
                            }
                            else
                            {
                                //5 -> 7
                                Board.Add(ToInt(i + k, j), pieces[i + 2]);
                                k -= 2;
                            }

                            i++;
                        }

                        break;
                    }
                }
                
            }

            return Board;
        }
    }
}