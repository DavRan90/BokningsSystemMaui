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
        public ObservableCollection<Models.BookingWithAdditionalInfo> BookingsWithExtra { get; set; }
        private ObservableCollection<Models.Booking> _booking;
        public ObservableCollection<Models.Booking> Bookings
            
        {
            get { return _booking; }
            set
            {
                _booking = value;
            }
        }
        public BookingsPageViewModel()
        {
            List<Models.BookingWithAdditionalInfo> extraList = Db.GetListOfBookingsWithExtraInfo(Models.User.GetUser().Id);
            BookingsWithExtra = new ObservableCollection<Models.BookingWithAdditionalInfo>(extraList);

            List<Models.Booking> bookings = Db.GetActiveBookings(Models.User.GetUser().Id);
            Bookings = new ObservableCollection<Models.Booking>(bookings);
        }
    }
}
