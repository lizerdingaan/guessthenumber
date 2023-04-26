using MauiApp2.Services;

namespace MauiApp2;

public partial class RegistrationPage : ContentPage
{
    readonly RegisterUser _registerUser = new();


    public RegistrationPage()
    {
        InitializeComponent();

    }

    private async void Registered_Clicked(object sender, EventArgs e)
    {
        string uniqueName = userEntry.Text;

        if (uniqueName == null)
        {
            await DisplayAlert("Warning", "Please enter a username.", "Ok");
            return;
        }            
        var newUser = await _registerUser.AddNewUser(uniqueName);

        if (!newUser)
        {
            await DisplayAlert("Welcome", "New user has been created.", "Ok");
            await Navigation.PushAsync(new Menu(uniqueName));
        }
        else
        {
            await DisplayAlert("Warning", "Username already exists, please enter more unique name.", "Ok");
            return;
        }
    }
}
