using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystemMaui.Models
{
    class Collections
    {
        private static readonly ObservableCollection<Booking> currentBookings = new ObservableCollection<Booking>();
        public static void AddBooking(Session session)
        {
            Booking newBooking = new Booking
            {
                Booked = true,
                BookedWhen = DateTime.Now,
                SessionId = session.Id,
                UserId = Models.User.GetUser().Id
            };
            Db.AddBooking(newBooking);
            session.SlotsBooked++;
            Db.UpdateSession(session);
        }
        //public static void SetBookings(ObservableCollection<Booking> bookings)
        //{
        //    currentBookings = new ObservableCollection<Booking>();
        //}
        public static void RemoveBooking(int bookingId)
        {
            currentBookings.RemoveAt(bookingId);
        }
        public static ObservableCollection<Booking> GetBookings()
        {
            return currentBookings;
        }
    }
}
