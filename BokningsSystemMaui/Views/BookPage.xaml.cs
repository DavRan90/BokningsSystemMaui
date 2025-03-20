using BokningsSystemMaui.Models;
using BokningsSystemMaui.ViewModels;
using BokningsSystemMaui.Views;
using Plugin.Maui.Calendar.Models;

namespace BokningsSystemMaui;

public partial class BookPage : ContentPage
{
    public EventCollection Events { get; set; }
    public BookPage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.BookPageViewModel();    
    }

    private async void OnClickedApply(object sender, EventArgs e)
    {
        var session = ((Button)sender).BindingContext as Models.Session;
        if (session.SlotsBooked < 5)
        {
            bool answer = await DisplayAlert("Bekräfta bokning", $"Bekräfta bokning till {session.Name} den {String.Format("{0:d}", session.Date)} kl {session.TimeStart} ", "Ja", "Nej");
            if (answer == true)
            {
                Models.Collections.AddBooking(session);
                await DisplayAlert("Bokning klar", $"Bokning till {session.Name} den {String.Format("{0:d}", session.Date)} kl {session.TimeStart} slutförd", "OK");
                await Navigation.PushAsync(new MainPage());
            }
            
        }
        else
        {
            bool answer = await DisplayAlert("Alert", "Passet är fullbokat, vill du bli notifierad om en plats blir ledig?", "Ja", "Nej");
            if (answer == true)
            {
                Notification notification = new Notification()
                {
                    Notified = false,
                    SessionId = session.Id,
                    UserId = User.GetUser().Id
                };
                Db.AddNotification(notification);
            }
        }
    }
}