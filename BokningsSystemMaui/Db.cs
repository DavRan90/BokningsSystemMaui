using BokningsSystemMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystemMaui
{
    class Db
    {
        public static void AddBooking(Models.Booking booking)
        {
            using (var db = new Models.BookingSystemContext())
            {
                db.Add(booking);
                db.SaveChanges();
            }
        }
        public static void UpdateUser(Models.User user)
        {
            using (var db = new BookingSystemContext())
            {
                db.Update(user);
                db.SaveChanges();
            }
        }
        public static void UpdateSession(Models.Session session)
        {
            using (var db = new BookingSystemContext())
            {
                db.Update(session);
                db.SaveChanges();
            }
        }
        public static void CancelBooking(int bookingId)
        {
            using (var db = new BookingSystemContext())
            {
                var bookingList = db.Bookings;
                var updateBooking = (from b in bookingList
                                     where b.Id == bookingId
                                     select b).SingleOrDefault();
                if (updateBooking != null)
                {
                    updateBooking.UnbookedWhen = DateTime.Now;
                    updateBooking.Booked = false;
                    bookingList.Update(updateBooking);
                }
                db.SaveChanges();
            }
        }
        public static List<BookingWithAdditionalInfo> GetSpecificSession(int bookingId)
        {
            using (var db = new BookingSystemContext())
            {
                var result = from booking in db.Bookings
                             join session in db.Sessions on booking.SessionId equals session.Id
                             join user in db.Users on booking.UserId equals user.Id
                             where booking.Id == bookingId
                             select new BookingWithAdditionalInfo
                             {
                                 Id = booking.Id,
                                 Name = user.Name,
                                 SessionName = session.Name,
                                 Date = session.Date,
                                 Start = session.TimeStart,
                                 End = session.TimeEnd,
                                 Booked = booking.Booked,
                                 BookedWhen = booking.BookedWhen,
                                 Unbooked = booking.UnbookedWhen,
                                 SessionId = session.Id
                             };
                
                return result.ToList();
            }
        }
        public static List<BookingWithAdditionalInfo> GetListOfBookingsWithExtra(int userId)
        {
            using (var db = new BookingSystemContext())
            {
                var result = from booking in db.Bookings
                             join session in db.Sessions on booking.SessionId equals session.Id
                             join user in db.Users on booking.UserId equals user.Id
                             where user.Id == userId && booking.Booked == true
                             select new BookingWithAdditionalInfo
                             {
                                 Id = booking.Id,
                                 Name = user.Name,
                                 SessionName = session.Name,
                                 Date = session.Date,
                                 Start = session.TimeStart,
                                 End = session.TimeEnd,
                                 Booked = booking.Booked,
                                 BookedWhen = booking.BookedWhen,
                                 Unbooked = booking.UnbookedWhen,
                                 SessionId = session.Id
                             };

                return result.ToList();
            }
        }
        public static List<SessionNotifications> GetListOfSessionsWithNotifications()
        {
            using (var db = new BookingSystemContext())
            {
                var result = from note in db.Notifications
                             join session in db.Sessions on note.SessionId equals session.Id
                             join user in db.Users on note.UserId equals user.Id
                             where note.Notified == true
                             select new SessionNotifications
                             {
                                 Name = session.Name,
                                 Date = session.Date,
                                 TimeStart = session.TimeStart,
                                 SlotsBooked = session.SlotsBooked,
                                 MaxSlots = session.MaxSlots,
                                 UserId = note.UserId
                             };

                return result.ToList();
            }
        }
        public static List<Session> GetListOfSessionsWithNotifications(int userId)
        {
            using (var db = new BookingSystemContext())
            {
                var result = from note in db.Notifications
                             join session in db.Sessions on note.SessionId equals session.Id
                             join user in db.Users on note.UserId equals user.Id
                             where note.Notified == true && note.UserId == userId
                             select new Session
                             {
                                 Id = session.Id,
                                 Name = session.Name,
                                 Date = session.Date,
                                 TimeStart = session.TimeStart,
                                 TimeEnd = session.TimeEnd,
                                 SessionType = session.SessionType,
                                 SlotsBooked = session.SlotsBooked,
                                 MaxSlots = session.MaxSlots,
                             };

                return result.ToList();
            }
        }
        public static void RemoveBooking(int bookingId)
        {
            using (var db = new BookingSystemContext())
            {
                var bookingList = db.Bookings;
                var removeBooking = (from b in bookingList
                                     where b.Id == bookingId
                                     select b).SingleOrDefault();
                if (removeBooking != null)
                {
                    bookingList.Remove(removeBooking);
                }
                db.SaveChanges();
            }
        }
        public static void UpdateNotifications(int sessionId, bool notify)
        {
            using (var db = new BookingSystemContext())
            {
                var notifications = db.Notifications;
                var updateNotifications = (from n in notifications
                                            where n.SessionId == sessionId
                                            select n).SingleOrDefault();
                if (updateNotifications != null)
                {
                    updateNotifications.Notified = notify;
                }
                db.SaveChanges();
            }
        }
        public static void AddNotification(Models.Notification notification)
        {
            using (var db = new Models.BookingSystemContext())
            {
                db.Add(notification);
                db.SaveChanges();
            }
        }
        public static List<Models.Notification> GetCurrentUserNotifications(int userId)
        {
            using (var db = new Models.BookingSystemContext())
            {
                var result = from n in db.Notifications
                             where n.UserId == userId
                             select n;

                var result2 = db.Notifications.Where(note => note.UserId == userId && note.Notified == true);

                return result2.ToList();
            }
        }
        public static List<Models.Booking> GetActiveBookings(int userId)
        {
            using(var db = new Models.BookingSystemContext())
            {
                var result = from booking in db.Bookings
                             where booking.Id == userId
                             select booking;

                var result2 = db.Bookings.Where(book => book.UserId == userId && book.Booked == true);

                return result2.ToList();
            }
        }
        public static List<Models.Session> GetAllSessions()
        {
            using (var db = new Models.BookingSystemContext())
            {
                var result = from session in db.Sessions
                             select session;

                var result2 = db.Sessions;

                return result2.ToList();
            }
        }
        public static List<Models.Booking> GetAllBookings()
        {
            using (var db = new Models.BookingSystemContext())
            {
                var result2 = db.Bookings.Where(book => book.Booked == true);

                return result2.ToList();
            }
        }
        public static List<Models.User> GetAllUsers()
        {
            using (var db = new Models.BookingSystemContext())
            {
                var result = db.Users.Where(user => user.Id > 0);

                return result.ToList();
            }
        }
    }
}
