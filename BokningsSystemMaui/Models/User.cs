using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystemMaui.Models
{
    public class User
    {
        private static readonly User currentUser = new User();
        private User()
        {
            
        }
        public User(int num)
        {
            
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PersonNummer { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public static User GetUser()
        {
            return currentUser;
        }
        public static User NewUser()
        {
            return new User();
        }
        public static void UpdateUser(User user)
        {
            currentUser.Id = user.Id;
            currentUser.Username = user.Username;
            currentUser.Password = user.Password;
            currentUser.PersonNummer = user.PersonNummer;
            currentUser.Name = user.Name;
            currentUser.City = user.City;
            currentUser.ZipCode = user.ZipCode;
            currentUser.Telephone = user.Telephone;
            currentUser.Email = user.Email;
        }
    }
}
