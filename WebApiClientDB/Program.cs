using GameCore.DTO;
using GameCore.Services;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using GameCore.Data;
using GameCore.Models;

Console.Write("please wait, your api is starting up...");
Console.ReadKey();
Console.WriteLine();

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

await RegisterUser(client);

static async Task RegisterUser(HttpClient client)
{
    
    Console.WriteLine("Do you want to register?(y/n)");
    var registration = Console.ReadKey();
    string username;
    
    Console.Write("\n");

    if (registration.Key == ConsoleKey.Y)
    {
        
        while (true)
        {
            Console.WriteLine("Please enter new username:");
            username = Console.ReadLine();

            HttpResponseMessage json_ = await client.GetAsync(
            $"http://localhost:5279/api/GameStoring/{username}");
            var result = await GetResult<AddUserDTO>(json_);

            var existing = result.UsernameExists;
            if (existing)
            {
                Console.WriteLine(result.Message);
                continue;
            }
            else
            {
                Console.WriteLine(result.Message);
                break;
            }

        }

        await StartGameAsync(client, username);

    }
    else
    {
        Console.WriteLine("Enter your username");
        var originalPlayer = Console.ReadLine();

        HttpResponseMessage json_ = await client.GetAsync(
        $"http://localhost:5279/api/GameStoring/{originalPlayer}");
        var result = await GetResult<AddUserDTO>(json_);

        var playerExists = result.UsernameExists;
        if (playerExists)
        {
            Console.WriteLine($"\nWelcome back, {originalPlayer}!!");

            await StartGameAsync(client, originalPlayer);
        }
        else
        {
            Console.WriteLine("\nThis user does not exist, please register before continuing.");
            await RegisterUser(client);
        }

    }
}


static async Task StartGameAsync(HttpClient client, string username)
{

    HttpResponseMessage json_ = await client.GetAsync(
        $"http://localhost:5279/api/GameStoring/start");
    var result = await GetResult<ResponseDTO>(json_);

    
    Console.WriteLine("\nInput your guess:");

    await PlayGameAsync(client, result, username);

}


static async Task PlayGameAsync( HttpClient client, ResponseDTO result, string username)
{

    var tries = result?.Tries;

    while (true)
    {
        string userInput = Console.ReadLine();
        

        HttpResponseMessage json = await client.GetAsync($"http://localhost:5279/api/GameStoring/{username}/{result?.Id}/{userInput}");

        var result_ = await GetResult<ResponseDTO>(json);
        var newTries = result_.Tries;

        Console.WriteLine(result_?.Message);

        var playing = result_.PlayingGame;

        if (playing)
        {
            tries = newTries;

        }
        if (!playing)
        {
            await GetUserHistory(client, username);
            var replay = ReplayGame();
            if (replay)
            {
                await StartGameAsync(client, username);
            }

            if (!replay) 
            {
                break;
            }
        }
    }
}


static async Task GetUserHistory(HttpClient client, string username)
{
    Console.WriteLine("\nDo you want to view your game history?(y/n)");
    string history = Console.ReadLine();

    if (history == "y")
    {
        HttpResponseMessage json = await client.GetAsync(
            $"http://localhost:5279/api/GameStoring/{history}/{username}");

        var result_ = await GetResult<ResponseDTO>(json);
        var gameHistory = result_.games;
        foreach (var gameInstance in gameHistory)
        {
            Console.Write("\n");
            Console.WriteLine($"Random Number:      {gameInstance.RandomNumber}");
            Console.WriteLine($"Number of Tries left:    {gameInstance.NumberOfTries}");
            Console.WriteLine($"Game Status(win-true, loss-false):    {gameInstance.GameStatus}");
            Console.WriteLine(new string('-', 20));
        }
    }
}


static bool ReplayGame()
{
    Console.WriteLine("\nDo you want to play again (y/n)? ");
    while (true)
    {
        var keyStroke = Console.ReadKey();
        Console.Write("\n");
        if (keyStroke.Key == ConsoleKey.Y)
        {
            return true;
        }
        else if (keyStroke.Key == ConsoleKey.N)
        {
            return false;
        }
        else
        {
            Console.Write("\nPlease input either y or n: ");
        }
    }
}


static async Task<T?> GetResult<T>(HttpResponseMessage message)
{
    var contentString = await message.Content.ReadAsStringAsync();
    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };
    var result = JsonSerializer.Deserialize<T>(contentString, options);
    return result;
}




