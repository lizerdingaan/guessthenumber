using GameCore.DTO;
using GameCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.Services
{
    class ViewHistoryService
    {
        private string text;
        readonly List<string> gameInstances = new List<string>();

        public List<string> Games { get; set; }

        public ViewHistoryService(string text)
        {
            this.text = text;
        }

        public ViewHistoryService(string text, List<string> Game)
        {
            this.text = text;
            gameInstances = Game;
            
        }


    }

    public class RefreshHistory
    {
        private object _username;

        public async void Refresh()
        {
            var client = new HttpClient();

            HttpResponseMessage json = await client.GetAsync(
                $"http://localhost:5279/api/GameStoring/{"y"}/{_username}");
            var result = await DeserializeJson.GetResult<ResponseDTO>(json);
        }
    }
}
