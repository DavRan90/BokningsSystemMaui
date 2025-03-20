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
        public ObservableCollection<Models.User> Users { get; set; }

        
        public LoginPageViewModel()
        {
            var allUsers = Db.GetAllUsers();
            Users = new ObservableCollection<User>(allUsers);
        }
    }
}
