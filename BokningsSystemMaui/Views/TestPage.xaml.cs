

namespace BokningsSystemMaui.Views;

public partial class TestPage : ContentPage
{
    public Models.EventModel EventModel { get; set; }
    public Models.Session Session { get; set; }

    public Models.User User { get; set; }
    public Models.TestUser TestUser { get; set; }
    public TestPage(Models.Session session)
	{
		InitializeComponent();
        Session = session;
        Models.Session.SetCurrentSession(session);
        if (session != null)
		{
            User = Models.User.GetUser();
            SessionId.Text = session.Id.ToString();
            //SessionName.Text = session.SessionName;
            if (User != null)
            {
                Password.Text = User.Username;
                BackButton.Text = "Boka";
            }
            
            
		}
	}
    public TestPage(Models.User user)
    {
        InitializeComponent();
        User = user;
        if (user != null)
        {
            SessionId.Text = User.Id.ToString();
            SessionName.Text = User.Username;
            Password.Text = User.Password;
        }
    }
    public TestPage(Models.TestUser user)
    {
        InitializeComponent();
        TestUser = user;
        if (user != null)
        {
            SessionId.Text = TestUser.Id.ToString();
            SessionName.Text = TestUser.Username;
            Password.Text = TestUser.Password;
            
        }
    }

    private async void OnClickedBackButton(object sender, EventArgs e)
    {
        if(BackButton.Text == "Boka")
        {
            var session = ((Button)sender).BindingContext as Models.Session;
            await Navigation.PushAsync(new BookingConfirmation(session));
        }
        else
        {
            await Navigation.PushAsync(new MainPage());
        }
            
    }
}