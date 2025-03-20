using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystemMaui.Models
{
    public class SessionNotifications
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TimeOnly TimeStart { get; set; }
        public int SlotsBooked { get; set; }
        public int MaxSlots { get; set; }
        public int UserId { get; set; }

    }
}
