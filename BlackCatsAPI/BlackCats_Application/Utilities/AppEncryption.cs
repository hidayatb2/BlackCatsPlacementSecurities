using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.Utilities
{
    public static  class AppEncryption
    {

        public static  byte[]  GenerateSalt()
        {
            var Salt = BCrypt.Net.BCrypt.GenerateSalt();
            var SaltBytes=Encoding.UTF8.GetBytes(Salt);
            return SaltBytes;
        }


        public static byte[] PasswordHashing (string password, byte[] salt) 
        {
            var salthash=Encoding.UTF8.GetString(salt);
            var Password = BCrypt.Net.BCrypt.HashPassword(password, salthash);
            return Encoding.UTF8.GetBytes(Password);
        
        }


    }
}
