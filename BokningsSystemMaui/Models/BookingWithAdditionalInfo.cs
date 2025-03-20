using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystemMaui.Models
{
    public class BookingWithAdditionalInfo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SessionName { get; set; }
        public DateTime? Date { get; set; }
        public TimeOnly? Start { get; set; }
        public TimeOnly? End { get; set; }
        public bool? Booked { get; set; }
        public DateTime? BookedWhen { get; set; }
        public DateTime? Unbooked { get; set; }
    }
}
