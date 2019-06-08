using Labo2.Models;
using System.Security.Cryptography;
using System.Text;

namespace Labo2.ViewModels
{
    public class UserPostModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }


        private static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            

            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


        public static User ToUser(UserPostModel userModel)
        {
            UserRole rol = Labo2.Models.UserRole.Regular;

            if (userModel.UserRole == "UserManager")
            {
                rol = Labo2.Models.UserRole.UserManager;
            }
            else if (userModel.UserRole == "Admin")
            {
                rol = Labo2.Models.UserRole.Admin;
            }

            return new User
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Username = userModel.Username,
                Email = userModel.Email,
                Password = ComputeSha256Hash(userModel.Password),
                UserRole = rol
            };
        }
    }
}

