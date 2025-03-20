using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystemMaui.Models
{
    public class Booking
    {
        private static readonly Booking currentBooking = new Booking();
        public int Id { get; set; }
        public bool? Booked { get; set; }
        public DateTime? BookedWhen { get; set; }
        public DateTime? UnbookedWhen { get; set; }
        public int? SessionId { get; set; }
        public int? UserId { get; set; }
        // Egentligen props från annan klass
        //public DateTime? WhenSession { get; set; }
        //public string? SessionName { get; set; }
        //public virtual Booking? Booking { get; set; }
        public static Booking GetCurrentBooking()
        {
            return currentBooking;
        }
        public static void SetCurrentBooking(Booking booking)
        {
            currentBooking.Id = booking.Id;
            currentBooking.Booked = booking.Booked;
            currentBooking.BookedWhen = booking.BookedWhen;
            currentBooking.UnbookedWhen = booking.UnbookedWhen;
            currentBooking.SessionId = booking.SessionId;
            currentBooking.UserId = booking.UserId;
            //currentBooking.WhenSession = booking.WhenSession;
            //currentBooking.SessionName = booking.SessionName;
        }
    }
}
