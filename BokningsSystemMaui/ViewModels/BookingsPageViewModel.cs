using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystemMaui.ViewModels
{
    public class BookingsPageViewModel
    {
        private ObservableCollection<Models.Booking> _booking;
        public ObservableCollection<Models.Booking> Bookings
            
        {
            get { return _booking; }
            set
            {
                _booking = value;
            }
        }
        public ObservableCollection<Models.BookingWithAdditionalInfo> BookingsWithExtra { get; set; }

        public BookingsPageViewModel()
        {
            List<Models.BookingWithAdditionalInfo> extraList = Db.GetListOfBookingsWithExtra(Models.User.GetUser().Id);
            BookingsWithExtra = new ObservableCollection<Models.BookingWithAdditionalInfo>(extraList);

            //Bookings = Models.Collections.GetBookings();
            List<Models.Booking> bookings = Db.GetBookings(Models.User.GetUser().Id);
            
            //List<Models.Booking> bookings = Db.GetAllBookings();
            Bookings = new ObservableCollection<Models.Booking>(bookings);
        }
    }
}
