using BokningsSystemMaui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystemMaui.ViewModels
{
    class LoginPageViewModel
    {
        public Models.User User { get; set; }

        private ObservableCollection<Models.User> _user;
        public ObservableCollection<Models.User> Users { get; set; }
        //{
        //    get { return _user; }
        //    set
        //    {
        //        _user = value;
        //    }
        //}
        //public static ObservableCollection<Models.User> ReturnUsers()
        //{
        //    ObservableCollection<Models.User> users = Users;
        //}

        
        public LoginPageViewModel()
        {
            //Users = new ObservableCollection<Models.User>();
            //Users.Add(new Models.User
            //{
            //    Id = 1,
            //    Username = "David",
            //    Password = "1234"
            //});
            var allUsers = Db.GetAllUsers();
            Users = new ObservableCollection<User>(allUsers);
        }
    }
}
