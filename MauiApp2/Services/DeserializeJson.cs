using System.Text.Json;


namespace MauiApp2.Services
{
    public class DeserializeJson
    {
        public static async Task<T> GetResult<T>(HttpResponseMessage message)
        {
            var contentString = await message.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var result = JsonSerializer.Deserialize<T>(contentString, options);
            return result;
        }
    }
}
