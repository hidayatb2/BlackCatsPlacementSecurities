using System.Text;

namespace BlackCats_Application.Utilities;

public static  class AppEncryption
{
    public static byte[] GenerateSalt()
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt();
        return Encoding.UTF8.GetBytes(salt);
    }

    public static byte[] PasswordHashig(string password,byte[] salt)
    {
        var passwordHashing=BCrypt.Net.BCrypt.HashPassword(password,Encoding.UTF8.GetString(salt));
        return Encoding.UTF8.GetBytes(passwordHashing);
    }

}
