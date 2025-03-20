using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystemMaui.Models
{
    class Helper
    {
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
            if(session.SlotsBooked == session.MaxSlots)
            {
                Db.UpdateNotifications(session.Id, false);
            }
            Db.UpdateSession(session);
        }
        public static void RemoveBooking(BookingWithAdditionalInfo booking)
        {
            var sessions = Db.GetAllSessions();
            foreach (var session in sessions)
            {
                if (session.Id == booking.SessionId)
                {
                    Session.SetCurrentSession(session);
                    if (session.SlotsBooked == session.MaxSlots)
                    {
                        Db.UpdateNotifications(session.Id, true);
                    }
                    session.SlotsBooked--;
                    Db.UpdateSession(session);
                }
            }
            Db.CancelBooking(booking.Id);
        }
    }
}
