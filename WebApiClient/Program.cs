using GameCore.DTO;
using GameCore.Services;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using GameCore.Data;
using GameCore.Models;

using GameContext gameContext = new GameContext();


Console.Write("please wait, your api is starting up...");
Console.ReadKey();
Console.WriteLine();

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

var finalResult = await StartGuessingAsync(client);
await ProcessGuessAsync(client, finalResult);

/*static async Task RegisterPlayer(HttpClient client)
{
    Console.WriteLine("Please enter your username: ");
    Username username = new Username()
    {
        Name = Console.ReadLine()
    };
    
    Console.ReadLine();

   
}*/


static async Task<ResponseDTO> StartGuessingAsync(HttpClient client)
{
    HttpResponseMessage json_ = await client.GetAsync(
        "http://localhost:5279/api/Game/api/start");
    var result = await GetResult<ResponseDTO>(json_);


    Console.WriteLine(result?.Message);
    Console.WriteLine("Input your guess:");

    return result;
}


static async Task ProcessGuessAsync(HttpClient client, ResponseDTO result)
{
    
    var tries = result?.Tries;

    while (true)
    {
        
        var userInput = Console.ReadLine();

        HttpResponseMessage json = await client.GetAsync(
            $"http://localhost:5279/api/Game/{result?.Id}/{userInput}");

        var result_ = await GetResult<ResponseDTO>(json);
        var newTries = result_?.Tries;

        Console.WriteLine(result_?.Message);

        var playing = result_.PlayingGame;

        if (playing)
        {
            tries = newTries;
            
        } 
        if (!playing)
        {
            var replay = ReplayGame();

            if (!replay)
            {
                break;
            }

            var dataObject = await StartGuessingAsync(client);
            await ProcessGuessAsync(client, dataObject);
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
