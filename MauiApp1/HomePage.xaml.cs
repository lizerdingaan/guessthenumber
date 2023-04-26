using MauiApp1.Services;
using GameCore.Models;

namespace MauiApp1;

public partial class HomePage : ContentPage
{
    readonly IRegistrationInfo _registrationInfo = new RegistrationInfo();
    public HomePage()
    {
        InitializeComponent();
    }

    private void Register_Clicked(object sender, EventArgs e)
    {

    }

    /*private async void Register_Clicked(object sender, EventArgs e)
    {
        string userName = txtUserName.Text;

        if (userName == null)
        {
            await DisplayAlert("Warning", "Please enter a username", "Ok");
            return;
        }
        Username username = await _registrationInfo.Register(userName);
        if(userName != null)
        {
            await Navigation.PushAsync(new HomePage());
        }
        else
        {
            await DisplayAlert("Warning", "Username is not unique", "Ok");
        }
        
    }*/
}