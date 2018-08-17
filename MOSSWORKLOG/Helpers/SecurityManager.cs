﻿using System;
using System.Security.Cryptography;
using System.Text;


namespace MOSSWORKLOG.Helpers
{
    /// <summary>
    /// Token-based authentication for ASP .NET MVC REST web services.
    /// Copyright (c) 2015 Kory Becker
    /// http://primaryobjects.com/kory-becker
    /// License MIT
    /// </summary>
    public static class SecurityManager
    {
        private const string Alg = "HmacSHA256";
        private const string Salt = "rz8LuOtFBXphj9WQfvFh";
        private const int ExpirationMinutes = 10;

        /// <summary>
        /// Generates a token to be used in API calls.
        /// The token is generated by hashing a message with a key, using HMAC SHA256.
        /// The message is: username:ip:userAgent:timeStamp
        /// The key is: password:ip:salt
        /// The resulting token is then concatenated with username:timeStamp and the result base64 encoded.
        /// 
        /// API calls may then be validated by:
        /// 1. Base64 decode the string, obtaining the token, username, and timeStamp.
        /// 2. Ensure the timestamp is not expired.
        /// 2. Lookup the user's password from the db (cached).
        /// 3. Hash the username:ip:userAgent:timeStamp with the key of password:salt to compute a token.
        /// 4. Compare the computed token with the one supplied and ensure they match.
        /// </summary>
        public static string GenerateToken(string username, string password, long ticks)
        {
            var hash = string.Join(":", new string[] { username , ticks.ToString() });
            string hashLeft;
            string hashRight;

            using (HMAC hmac = HMACSHA256.Create(Alg))
            {
                hmac.Key = Encoding.UTF8.GetBytes(GetHashedPassword(password));
                hmac.ComputeHash(Encoding.UTF8.GetBytes(hash));

                hashLeft = Convert.ToBase64String(hmac.Hash);
                hashRight = string.Join(":", new string[] { username, ticks.ToString() });
            }

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(":", hashLeft, hashRight)));
        }

        /// <summary>
        /// Returns a hashed password + salt, to be used in generating a token.
        /// </summary>
        /// <param name="password">string - user's password</param>
        /// <returns>string - hashed password</returns>
        public static string GetHashedPassword(string password)
        {
            var key = string.Join(":", new string[] { password, Salt });

            using (HMAC hmac = HMACSHA256.Create(Alg))
            {
                // Hash the key.
                hmac.Key = Encoding.UTF8.GetBytes(Salt);
                hmac.ComputeHash(Encoding.UTF8.GetBytes(key));

                return Convert.ToBase64String(hmac.Hash);
            }
        }

        /// <summary>
        /// Checks if a token is valid.
        /// </summary>
        /// <param name="token">string - generated either by GenerateToken() or via client with cryptojs etc.</param>
        /// <param name="ip">string - IP address of client, passed in by RESTAuthenticate attribute on controller.</param>
        /// <param name="userAgent">string - user-agent of client, passed in by RESTAuthenticate attribute on controller.</param>
        /// <returns>bool</returns>
        public static bool IsTokenValid(string token)
        {
            var result = false;

            try
            {
                // Base64 decode the string, obtaining the token:username:timeStamp.
                var key = Encoding.UTF8.GetString(Convert.FromBase64String(token));

                // Split the parts.
                var parts = key.Split(new char[] { ':' });
                if (parts.Length == 3)
                {
                    // Get the hash message, username, and timestamp.
                    //  var hash = parts[0];
                    var username = parts[1];
                    var ticks = long.Parse(parts[2]);
                    var timeStamp = new DateTime(ticks);

                    // Ensure the timestamp is valid.
                    var expired = Math.Abs((DateTime.UtcNow - timeStamp).TotalMinutes) > ExpirationMinutes;
                    if (!expired)
                    {
                        //
                        // Lookup the user's account from the db.
                        //
                        var password = "password";//password from your database
                        // Hash the message with the key to generate a token.
                        var computedToken = GenerateToken(username, password, ticks);

                        // Compare the computed token with the one supplied and ensure they match.
                        result = (token == computedToken);

                    }
                }
            }
            catch
            {
                //return false;
            }

            return result;
        }
    }
}