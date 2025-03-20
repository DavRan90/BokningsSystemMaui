using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsSystemMaui.ViewModels
{
    class CancellationPageViewModel
    {
        public Models.Booking Booking { get; set; }

        

        private ObservableCollection<Models.Booking> _booking;
        public ObservableCollection<Models.Booking> Bookings
        {
            get { return _booking; }
            set
            {
                _booking = value;
            }
        }
        public CancellationPageViewModel()
        {
            var bookingList = Db.GetBookings(Models.User.GetUser().Id);
            Bookings = new ObservableCollection<Models.Booking>(bookingList);
            Booking = Models.Booking.GetCurrentBooking();
        }
    }
}
