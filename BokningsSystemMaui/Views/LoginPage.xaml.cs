
using BokningsSystemMaui.Views;
using System.Collections.ObjectModel;

namespace BokningsSystemMaui;

public partial class LoginPage : ContentPage
{
    static Models.User currentUser = Models.User.GetUser();
    public Models.User User{ get; set; }
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
        }
        else
        {
            LogoutButton.IsVisible = false;
            Login.Text = "Logga in";
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
                await DisplayAlert("Inloggning lyckades", $"V�lkommen {user.Name}", "OK");

                await Navigation.PushAsync(new MainPage());
                return;
            }
        }
        DisplayAlert("Inloggning misslyckades", "Fel anv�ndarnamn eller l�senord", "OK");
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

    private async void OnNotificationClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NotificationsPage());
    }
}