using GameCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    class RegistrationInfo : IRegistrationInfo
    {
        public async Task<Username> Register(string username)
        {
            
            var Username = new Username();
            var client = new HttpClient();

            string url = $"http://localhost:5279/api/GameStoring/{username}";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                Username = JsonConvert.DeserializeObject<Username>(content);

                return Username;
            }
            else return null;
        }
    }
}
