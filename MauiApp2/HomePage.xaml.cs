namespace MauiApp2;

public partial class HomePage : ContentPage
{
    //string username = null;
    public HomePage()
	{
		InitializeComponent();
	}

    private void Login_Clicked(object sender, EventArgs e)
    {
        
        Navigation.PushAsync(new LoginPage());
    }

    private void Register_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RegistrationPage());
    }

    private async void OnGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
        string rules = "1. Login as an existing user.\n2. If you are new, register with a unique username\n3. " +
            "Press start to begin. You have 5 tries to guess a number between 1 and 20.\n";
        await DisplayAlert("Note", rules, "Ok");
        
    }
}