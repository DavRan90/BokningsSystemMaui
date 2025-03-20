using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystemMaui.Models
{
    public class TestUser
    {
        private static readonly TestUser currentUser = new TestUser();

        public string Username { get; set; }
        public string Password  { get; set; }
        public int Id { get; set; }
        //public TestUser User { get; set; }

        public static TestUser GetUser()
        {
            return currentUser;
        }
        public static void UpdateUser(TestUser user)
        {
            currentUser.Username = user.Username;
            currentUser.Password = user.Password;
            currentUser.Id = user.Id;
        }
        //public TestUser()
        //{
        //    //Username = user.Username;
        //    //Password = user.Password;
        //    //Id = user.Id;
        //}

    }
}
