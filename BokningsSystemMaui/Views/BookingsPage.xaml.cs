using BokningsSystemMaui.Models;
using BokningsSystemMaui.Views;

namespace BokningsSystemMaui;

public partial class BookingsPage : ContentPage
{
    static User currentUser = User.GetUser();
    public BookingsPage()
	{
		InitializeComponent();
        Admin.IsVisible = false;
        //BindingContext = new ViewModels.BookingsPageViewModel();
        BindingContext = new ViewModels.BookingsPageViewModel();

        if (currentUser.Username != null)
        {
            Login.Text = currentUser.Username;
            //Bookings.IsVisible = true;
            //Book.IsVisible = true;
            //MyPages.IsVisible = true;
        }
        else
        {
            Login.Text = "Logga in";
            //Bookings.IsVisible = false;
            //Book.IsVisible = false;
            //MyPages.IsVisible = false;
        }

    }

    private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //var booking = ((ListView)sender).SelectedItem as Models.Booking;
        //if (booking != null)
        //{
        //    var page = new Views.CancellationPage();
        //    page.BindingContext = booking;
        //    await Navigation.PushAsync(page);
        //}
    }

    private async void OnClickedUnBook(object sender, EventArgs e)
    {
        var booking = ((Button)sender).BindingContext as Models.BookingWithAdditionalInfo;

        bool answer = await DisplayAlert("Bekräfta avbokning", $"Bekräfta avbokning till {booking.SessionName} den {String.Format("{0:d}", booking.Date)} kl {booking.Start} ", "Ja", "Nej");
        if (answer == true)
        {
            Collections.RemoveBooking(booking);
            // Testar
            //Db.CancelBooking(booking.Id);
            await DisplayAlert("Bokning borttagen", $"Bokning till {booking.SessionName} med ID {booking.Id} den {String.Format("{0:d}", booking.Date)} kl {booking.Start} borttagen", "OK");
            await Navigation.PushAsync(new BookingsPage());
        }
    }

    private async void OnStartPageClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void OnMyPagesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MyPagesPage());
    }

    private async void OnBookingsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BookingsPage());
    }

    private async void OnBookClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BookPage());
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }

    private void OnAdminClicked(object sender, EventArgs e)
    {

    }
}