
namespace GameCore.Services
{
    public interface IUserInput
    {
        string? ReadLine();
            
        ConsoleKeyInfo ReadKey();
    }
}
