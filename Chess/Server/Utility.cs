﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace Chess.Server
{
    public class Utility
    {
        public static string Encrypt(string password)
        {
            var provider = MD5.Create();
            const string salt = "S0m3R@nd0mSalt";            
            var bytes = provider.ComputeHash(Encoding.UTF32.GetBytes(salt + password));
            return BitConverter.ToString(bytes).Replace("-","").ToLower();
        }
    }
}
