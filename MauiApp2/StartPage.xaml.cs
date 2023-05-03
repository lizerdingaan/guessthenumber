using GameCore.DTO;
using MauiApp2.Services;

namespace MauiApp2;

public partial class StartPage : ContentPage
{
    string _player;
    ResponseDTO result;
    GameInstanceDTO gameInstance;
    RefreshHistory refreshHistory = new RefreshHistory();


    public StartPage(string username)
    {
        InitializeComponent();
        StartGame();
        _player = username;
    }

    private async void StartGame()
    {
        var client = new HttpClient();

        HttpResponseMessage json_ = await client.GetAsync(
        $"http://localhost:5279/api/GameStoring/start");
        result = await DeserializeJson.GetResult<ResponseDTO>(json_);

        messageLabel.Text = result.Message;
        
    }

    private void VisibilityAndRefresh()
    {
        messageLabel.IsVisible = false;
        userGuess.IsVisible = false;
        btnSubmit.IsVisible = false;
        btnMenu.IsVisible = true;
        btnPlayAgain.IsVisible = true;
        refreshHistory.Refresh();
    }

    private async void Submit_Clicked(object sender, EventArgs e)
    {
        var number = userGuess.Text;

        if (number != null && number != "" && int.TryParse(number, out int _))
        {
            if (int.Parse(number) < 1 || int.Parse(number) > 20)
            {
                await DisplayAlert("Warning", "Please enter number between 1 and 20.", "Ok");
            }
            else
            {
                var client = new HttpClient();
                HttpResponseMessage json = await client.GetAsync($"http://localhost:5279/api/GameStoring/{_player}/{result.Id}/{number}");
                result = await DeserializeJson.GetResult<ResponseDTO>(json);

                responseMessage.Text = result.Message;
                

                if (!result.PlayingGame)
                {
                    VisibilityAndRefresh();
                }
                if (result.WonGame)
                {
                    VisibilityAndRefresh();
                }
                
            }
        }
        else
        {
            await DisplayAlert("Warning", "Please enter a valid number.", "Ok");
        }
        userGuess.Text = string.Empty;

    }

    private void Menu_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Menu(_player));
    }

    private void PlayAgain_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StartPage(_player));
    }
}