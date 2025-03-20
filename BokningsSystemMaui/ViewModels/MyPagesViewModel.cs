using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystemMaui.ViewModels
{
    class MyPagesViewModel
    {
        public Models.User User { get; set; }
        public MyPagesViewModel()
        {
            User = Models.User.GetUser();
        }
    }
}
