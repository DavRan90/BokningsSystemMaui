using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystemMaui.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public bool? Notified { get; set; }
        public int SessionId { get; set; }
        public int UserId { get; set; }
    }
}
