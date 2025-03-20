using BokningsSystemMaui.Models;
using BokningsSystemMaui.Views;

namespace BokningsSystemMaui
{
    public partial class MainPage : ContentPage
    {
        static User currentUser = User.GetUser();
        
        public MainPage()
        {
            InitializeComponent();
            Admin.IsVisible = false;
            GetWeather();

            if (currentUser.Username != null)
            {
                Login.Text = currentUser.Username;
            }
            else
            {
                Login.Text = "Logga in";
            }
        }
        public async void GetWeather()
        {
            Task<Models.Weather> weatherToday = WeatherDataManager.GetWeather("v1/weather?lat=59.04410074073589&lon=17.315587071105572");
            WeatherNow.Text = ($"{(await weatherToday).temp}°C");
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

        private void OnStartPageClicked(object sender, EventArgs e)
        {

        }

        private void OnAdminClicked(object sender, EventArgs e)
        {

        }

        private async void OnNotificationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotificationsPage());
        }
    }

}
