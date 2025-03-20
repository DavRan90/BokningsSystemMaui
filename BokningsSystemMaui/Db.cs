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
                                 Unbooked = booking.UnbookedWhen
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
                                 Unbooked = booking.UnbookedWhen
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
        public static List<Models.Booking> GetBookings(int userId)
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
