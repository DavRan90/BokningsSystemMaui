namespace BokningsSystemMaui.Views;

public partial class MyPagesPage : ContentPage
{
    public Models.User User { get; set; }
    static Models.User currentUser = Models.User.GetUser();
    public MyPagesPage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.MyPagesViewModel();
        Admin.IsVisible = false;
        //User.UpdateUser(new User() { Id = 1, Username = "David", Password = "1234" });
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

    private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }

    private async void OnClickedSave(object sender, EventArgs e)
    {
        var user = ((Button)sender).BindingContext as Models.User;
        Db.UpdateUser(user);
        await DisplayAlert("Ändringar sparade", $"Dina ändringar har sparats!", "OK");
        //await Navigation.PushAsync(new MyPagesPage());
    }

    private async void OnStartPageClicked(object sender, EventArgs e)
    {
        
        await Navigation.PushAsync(new MainPage());
    }

    private void OnMyPagesClicked(object sender, EventArgs e)
    {

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
        //await Navigation.PushAsync(new LoginPage(new Models.User()));
        await Navigation.PushAsync(new LoginPage());
    }

    private void OnAdminClicked(object sender, EventArgs e)
    {

    }
}