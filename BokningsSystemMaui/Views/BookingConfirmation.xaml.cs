

namespace BokningsSystemMaui.Views;

public partial class BookingConfirmation : ContentPage
{
	public BookingConfirmation(Models.Session session)
	{
        session = Models.Session.GetCurrentSession();
		InitializeComponent();
		if (session != null)
		{
            Models.Collections.AddBooking(session);
            SessionId.Text = session.Id.ToString();
            //SessionName.Text = session.SessionName;
            SessionTimes.Text = session.TimeStart.ToString() + " - " + session.TimeEnd;
            UserName.Text = Models.User.GetUser().Username;
        }
		
    }

    private async void OnBackToMainPageClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}