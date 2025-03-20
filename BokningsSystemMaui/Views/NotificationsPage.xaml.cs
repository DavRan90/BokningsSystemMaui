namespace BokningsSystemMaui.Views;

public partial class NotificationsPage : ContentPage
{
    static Models.User currentUser = Models.User.GetUser();
    public NotificationsPage()
	{
		InitializeComponent();
        Admin.IsVisible = false;
        BindingContext = new ViewModels.NotificationPageViewModel();

        if (currentUser.Username != null)
        {
            Login.Text = currentUser.Username;
        }
        else
        {
            Login.Text = "Logga in";
        }
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

    private async void OnStartPageClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private void OnAdminClicked(object sender, EventArgs e)
    {

    }

    private async void OnNotificationClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NotificationsPage());
    }

    private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }
    private async void OnClickedBook(object sender, EventArgs e)
    {
        var session = ((Button)sender).BindingContext as Models.Session;
        Models.Helper.AddBooking(session);
        await DisplayAlert("Bokning klar", $"Bokning till {session.Name} med ID {session.Id} den {String.Format("{0:d}", session.Date)} kl {session.TimeStart} tillagd", "OK");
        await Navigation.PushAsync(new NotificationsPage());
    }

    private async void OnClickedNotInterested(object sender, EventArgs e)
    {
        var session = ((Button)sender).BindingContext as Models.Session;
        Db.DeleteNotifications(session.Id, Models.User.GetUser().Id);
        await Navigation.PushAsync(new NotificationsPage());
    }
}