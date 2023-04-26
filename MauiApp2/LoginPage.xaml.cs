using MauiApp2.Services;

namespace MauiApp2;

public partial class LoginPage : ContentPage
{
    readonly RegisterUser _registerUser = new();
    readonly string _player;

    public LoginPage(string username)
    {
        InitializeComponent();
        _player = username;
    }

    private async void Login_Clicked(object sender, EventArgs e)
    {
		string userName = userEntry.Text;

        if (userName == null)
        {
            await DisplayAlert("Warning", "Please enter a username", "Ok");
            return;
        }
        var userExists = await _registerUser.NewUser(userName);

        if (userExists)
        {
            await DisplayAlert("Note", $"Welcome back {userName}. Get ready to play!", "Ok");
            await Navigation.PushAsync(new Menu(userName));
        }
        else
        {
            await DisplayAlert("Warning", $"{userName} does not exist, please go register.", "Ok");
            await Navigation.PushAsync(new HomePage());
        }
    }

}