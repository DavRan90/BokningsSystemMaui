
using BokningsSystemMaui.Views;
using System.Collections.ObjectModel;

namespace BokningsSystemMaui;

public partial class LoginPage : ContentPage
{
    static Models.User currentUser = Models.User.GetUser();
    public Models.User User{ get; set; }
    public Models.TestUser TestUser { get; set; }
    //public List<Models.User> Users { get; set; }
    public LoginPage()
    {
        InitializeComponent();
        Admin.IsVisible = false;
        if (currentUser.Username != null)
        {
            LoginButton.IsVisible = false;
            RegisterButton.IsVisible = false;
            Login.Text = currentUser.Username;
            Username.Text = currentUser.Username;
            Password.Text = "********";
            LoginButton.Text = "Logout";
            //Bookings.IsVisible = true;
            //Book.IsVisible = true;
            //MyPages.IsVisible = true;
        }
        else
        {
            LogoutButton.IsVisible = false;
            Login.Text = "Logga in";
            //Bookings.IsVisible = false;
            //Book.IsVisible = false;
            //MyPages.IsVisible = false;
        }
        BindingContext = new ViewModels.LoginPageViewModel();
    }
    public LoginPage(Models.User user)
	{
		InitializeComponent();
        Admin.IsVisible = false;
        User = user;
        if (currentUser.Username != null)
        {
            InfoLabel.Text = "Du är inloggad som";
            Login.Text = currentUser.Username;
            Username.Text = currentUser.Username;
            Password.Text = "********";
            LoginButton.Text = "Logout";
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
        BindingContext = new ViewModels.LoginPageViewModel();
    }

    private async void OnClickedLoginButton(object sender, EventArgs e)
    {
        ObservableCollection<Models.User> users = new ObservableCollection<Models.User>(Db.GetAllUsers());

        foreach (var user in users)
        {
            if (user.Username == Username.Text && user.Password == Password.Text)
            {
                Models.User.UpdateUser(user);
                await DisplayAlert("Inloggning lyckades", $"Välkommen {user.Name}", "OK");

                await Navigation.PushAsync(new MainPage());
                return;
            }
        }
        DisplayAlert("Inloggning misslyckades", "Fel användarnamn eller lösenord", "OK");
        Navigation.PushAsync(new LoginPage());
    }

    private void OnClickedRegisterButton(object sender, EventArgs e)
    {

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
        //await Navigation.PushAsync(new LoginPage(new Models.User()));
        await Navigation.PushAsync(new LoginPage());
    }

    private void OnAdminClicked(object sender, EventArgs e)
    {

    }

    private async void OnClickedLogoutButton(object sender, EventArgs e)
    {
        Models.User.UpdateUser(new Models.User(1));
        await Navigation.PushAsync(new LoginPage());
    }
}