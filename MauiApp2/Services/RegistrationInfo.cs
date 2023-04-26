using GameCore.DTO;

namespace MauiApp2.Services
{

    class RegisterUser : IRegistrationInfo
    {
        public async Task<bool> NewUser(string username)
        {   
            var client = new HttpClient();

            HttpResponseMessage json_ = await client.GetAsync(
           $"http://localhost:5279/api/GameStoring/userExists/{username}");
            var result = await DeserializeJson.GetResult<AddUserDTO>(json_);

            var existing = result.UsernameExists;

            

            return existing;
        }

        public async Task<bool> AddNewUser(string username)
        {
            var client = new HttpClient();

            HttpResponseMessage json_ = await client.GetAsync(
           $"http://localhost:5279/api/GameStoring/{username}");
            var result = await DeserializeJson.GetResult<AddUserDTO>(json_);

            var existing = result.UsernameExists;



            return existing;
        }   
    }
}
