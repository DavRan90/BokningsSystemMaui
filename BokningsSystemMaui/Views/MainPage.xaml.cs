using BokningsSystemMaui.Models;
using BokningsSystemMaui.Views;

namespace BokningsSystemMaui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        static User currentUser = User.GetUser();
        
        public MainPage()
        {
            //Task<Weather> weather = WeatherDataManager.GetWeather("v1/weather?lat=59.04410074073589&lon=17.315587071105572");
            InitializeComponent();
            Admin.IsVisible = false;
            GetWeather();

            //Weather.Text = await weather.Result.temp.ToString();
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
            //await Navigation.PushAsync(new LoginPage(new Models.User()));
            await Navigation.PushAsync(new LoginPage());
        }

        private void OnStartPageClicked(object sender, EventArgs e)
        {

        }

        private void OnAdminClicked(object sender, EventArgs e)
        {

        }

        private async void OnClickedLoadWeather(object sender, EventArgs e)
        {
            Task<Models.Weather> weatherToday = WeatherDataManager.GetWeather("v1/weather?lat=59.04410074073589&lon=17.315587071105572");
            WeatherNow.Text = ($"Temperatur i Gnesta nu: {(await weatherToday).temp}°C");
        }
    }

}
