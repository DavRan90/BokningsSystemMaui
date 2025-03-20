using BokningsSystemMaui.Models;

namespace BokningsSystemMaui.Views;

public partial class CancellationPage : ContentPage
{
	public CancellationPage(Models.Booking booking)
	{
		InitializeComponent();
        Models.Booking currentBooking = new Models.Booking();
        var bookings = Db.GetAllBookings();
        foreach (var book in bookings)
        {
            if(book.Id == booking.Id)
            {
                currentBooking = book;
            }
        }

        Models.Booking.SetCurrentBooking(currentBooking);
        //BookingId.Text = booking.Id.ToString();
        BindingContext = new ViewModels.CancellationPageViewModel();
    }
    public CancellationPage(BookingWithAdditionalInfo booking)
    {
        InitializeComponent();
        Models.Booking currentBooking = new Models.Booking();
        var bookings = Db.GetBookings(User.GetUser().Id);
        foreach (var book in bookings)
        {
            if (book.Id == booking.Id)
            {
                currentBooking = book;
            }
        }

        Models.Booking.SetCurrentBooking(currentBooking);
        //BookingId.Text = booking.Id.ToString();
        BindingContext = new ViewModels.CancellationPageViewModel();


    }
    public CancellationPage()
    {
        InitializeComponent();
        
    }

    private async void OnRemoveBookingClicked(object sender, EventArgs e)
    {
        var booking = Models.Booking.GetCurrentBooking();

        Db.CancelBooking(booking.Id);

        await Navigation.PushAsync(new BookingsPage());
    }

    private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }
}