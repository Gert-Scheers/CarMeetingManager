using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CarMeetingManager.Helpers
{
    public class CustomPasswordHasher
    {
        //Method to hash the given password with salt
        public string HashPassword(string password, string salt)
        {
            //Using SHA1 (Any other method can be used here)
            SHA1 sha1 = SHA1.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(salt + password + salt);
            byte[] hash = sha1.ComputeHash(inputBytes);
            return Convert.ToBase64String(hash);
        }
        
        //Method to Verify the given password + salt. Hashing the given password to see if it matches the hashed PW stored in DataBase
        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword, string salt)
        {
            providedPassword = HashPassword(providedPassword, salt);
            return (providedPassword == hashedPassword ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed);
        }

        //Method to call in order to get randomized salt 'key'
        public string GetSalt()
        {
            string token = "";
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                byte[] tokenData = new byte[32];
                rng.GetBytes(tokenData);
                token = Convert.ToBase64String(tokenData);
            }
            return token;
        }
    }
}
