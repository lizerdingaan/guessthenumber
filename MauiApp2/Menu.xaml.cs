using GameCore.DTO;
using MauiApp2.Services;
using GameCore.Models;

namespace MauiApp2;

public partial class Menu : ContentPage
{
    private readonly string _player;

    public Menu(string username)
    {
        InitializeComponent();
        _player = username;
    }

    private void Start_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StartPage(_player));
    }

    private void History_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new HistoryPage(_player));
    }

    private void Exit_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new HomePage());
    }

    private async void DeleteUser_Clicked(object sender, EventArgs e)
    {
        var confirmAction = await DisplayAlert("Warning", "Are you sure you want to delete this user?", "Yes", "No");

        if (confirmAction)
        {
            var client = new HttpClient();
            HttpResponseMessage json = await client.DeleteAsync(
                $"http://localhost:5279/api/GameStoring/delete/user/{"delete"}/{_player}");
            var _ = await DeserializeJson.GetResult<ResponseDTO>(json);

            await DisplayAlert("Note", "This user has been deleted.", "Ok");
            await Navigation.PushAsync(new HomePage());
        }

        

    }
}