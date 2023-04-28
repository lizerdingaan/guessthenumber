using GameCore.DTO;
using MauiApp2.Services;


namespace MauiApp2;

public partial class HistoryPage : ContentPage
{
    string _username;

    public HistoryPage(string username)
	{
		InitializeComponent();

        _username = username;
        
	}

    protected async override void OnAppearing()
    {
        var client = new HttpClient();

        HttpResponseMessage json = await client.GetAsync(
            $"http://localhost:5279/api/GameStoring/{"y"}/{_username}");

        var result = await DeserializeJson.GetResult<ResponseDTO>(json);

        
        messageLabel.Text = result.Message;
        var Games = result.games;
        
        if (Games != null)
        {
            btnClear.IsVisible = true;
            List<string> ListOfGames = Games.Select(game => 
            $"Number of Tries: {game.NumberOfTries}, " +
            $"Random Number: {game.RandomNumber}, Game Status: {game.GameStatus}").ToList();
            historyCollection.ItemsSource = ListOfGames;

            BindingContext = new ViewHistoryService(messageLabel.Text, ListOfGames);
        }

        BindingContext = new ViewHistoryService(messageLabel.Text);


    }

    private void Menu_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Menu(_username));
    }

    private async void ClearHistory_Clicked(object sender, EventArgs e)
    {
        var confirmAction = await DisplayAlert("Warning", "Are you sure you want to delete your history games?", "Yes", "No");
        
        if (confirmAction)
        {
            var client = new HttpClient();
            HttpResponseMessage json = await client.DeleteAsync(
                $"http://localhost:5279/api/GameStoring/deleteHistory/{"yes"}/{_username}");

            var result = await DeserializeJson.GetResult<ResponseDTO>(json);

            messageLabel.IsVisible = false;
            historyCollection.IsVisible = false;

            clearHistory.Text = result.Message;
            BindingContext = new ViewHistoryService(clearHistory.Text);
        }

        

    }

}