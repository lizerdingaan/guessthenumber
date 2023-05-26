using GameCore.Data;
using GameCore.DTO;
using GameCore.Models;
using GameCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameStoringController : Controller
    {
        private readonly GameContext _context;
        private readonly ISingletonService _service;

        public GameStoringController(ISingletonService service)
        {
            _context = new GameContext();
            _service = service;
        }


        [HttpGet("start")]
        public IActionResult StartGame()
        {

            int Id = _service.AddNew();

            var message = new ResponseDTO
            {
                Message = "Guess a number between 1 and 20. You've got 5 tries.",
                Id = Id,
                Tries = _service.NumberOfTriesLeft(Id),
                PlayingGame = true,
                WonGame = false
            };

            return Ok(message);
        }


        [HttpGet("userExists/{username}")]
        public IActionResult UserExists([FromRoute] string username)
        {
            var existingUsername = _context.Usernames.Where(u => EF.Functions.Collate(u.Name, "SQL_Latin1_General_CP1_CS_AS") == username).FirstOrDefault();

            if (existingUsername is Username)
            {
                return Ok(new AddUserDTO
                {
                    Message = "\nThis username already exists.",
                    UsernameExists = true
                });
            }
            else
            {
                return Ok(new AddUserDTO
                {
                    Message = "\nThis username does not exist",
                    UsernameExists = false
                });
            }
        }


        [HttpGet("{username}")]
        public IActionResult ValidateUsername([FromRoute] string username)
        {
            var existingUsername = _context.Usernames.Where(u => EF.Functions.Collate(u.Name, 
                "SQL_Latin1_General_CP1_CS_AS") == username).FirstOrDefault();

            if (existingUsername is Username)
            {
                return Ok(new AddUserDTO {
                    Message = "\nThis username already exists. Please think of a more unique username.",
                    UsernameExists = true
                });
            }

            Username newUsername = new Username()
            {
                Name = username
            };

            _context.Add(newUsername);
            _context.SaveChanges();

            return Ok(new AddUserDTO {
                Message = $"Hi, {username} you have been registered. Good luck!",
                UsernameExists = false
            });
        }


        [HttpGet("{history}/{username}")]
        public IActionResult GetGameHistory([FromRoute] string history, [FromRoute] string username)
        {
            if (history == "y")
            {
                var gameHistory = _context.GameInstances.Where(x => EF.Functions.Collate(x.UsernameId, "SQL_Latin1_General_CP1_CS_AS") == username).ToList();

                if (gameHistory.Count() == 0)
                {
                    var messge = new ResponseDTO
                    {
                        Message = $"There are no previous games to show for user '{username}'"
                    };
                    return Ok(messge);
                }

                var message = new ResponseDTO
                {
                    games = gameHistory, 
                    Message = $"{username}'s previous games:"
                };
                return Ok(message);
            }

            return Ok();
        }


        [HttpDelete("deleteHistory/{deleteHistory}/{username}")]
        public IActionResult DeleteHistory([FromRoute] string deleteHistory, [FromRoute] string username)
        {
            if (deleteHistory == "yes")
            {
                var gameHistory = _context.GameInstances.Where(x => EF.Functions.Collate(x.UsernameId, "SQL_Latin1_General_CP1_CS_AS") == username).ToList();

                foreach (var history in gameHistory)
                {
                    _context.Remove(history);
                }
                _context.SaveChanges();

                var message = new ResponseDTO
                {
                    Message = "History cleared.",
                    HistoryCleared = true
                };
                return Ok(message);
            }
            return Ok();
        }


        [HttpDelete("delete/user/{deleteUser}/{username}")]
        public IActionResult DeleteUser([FromRoute] string deleteUser, [FromRoute] string username)
        {
            if (deleteUser == "delete")
            {
                DeleteHistory("yes", username);

                var existingUsernames = _context.Usernames.Where(u => EF.Functions.Collate(u.Name, "SQL_Latin1_General_CP1_CS_AS") == username).ToList();
                foreach (var existingUsername in existingUsernames)
                {
                    _context.Remove(existingUsername);
                }
                _context.SaveChanges();

                var message = new ResponseDTO
                {
                    Message = $"Username {username} is deleted."
                };
                return Ok(message);
            }
            return Ok();
        }
       
        
        [HttpGet("{username}/{id}/{guess}")]
        public IActionResult Guess([FromRoute] string username, [FromRoute] int id, [FromRoute] int guess)
        {

            try
            {
                var result = _service.Guess(guess, id);


                if (result)
                {
                    var message = new ResponseDTO
                    {
                        Message = "YAY! You guessed correctly.",
                        Id = id,
                        Tries = _service.NumberOfTriesLeft(id),
                        PlayingGame = false,
                        WonGame = true
                    };

                    GameInstance newGameInstance = new()
                    {
                        UsernameId = username,
                        RandomNumber = _service.GetGuess(id),
                        NumberOfTries = _service.NumberOfTriesLeft(id),
                        GameStatus = "Won"                      
                    };
                    _context.GameInstances.Add(newGameInstance);
                    _context.SaveChanges();

                    return Ok(message);
                }

                if (guess > _service.GetGuess(id))
                {

                    Console.WriteLine($"Guess? {_service.GetGuess(id)}");
                    var message = new ResponseDTO
                    {
                        Message = $"Too high, you have {_service.NumberOfTriesLeft(id)} chance(s) left",
                        Id = id,
                        Tries = _service.NumberOfTriesLeft(id),
                        PlayingGame = true,
                        WonGame = false
                    };
                    return Ok(message);
                }
                if (guess < _service.GetGuess(id))
                {
                    var message = new ResponseDTO
                    {
                        Message = $"Too low, you have {_service.NumberOfTriesLeft(id)} chance(s) left.",
                        Id = id,
                        Tries = _service.NumberOfTriesLeft(id),
                        PlayingGame = true,
                        WonGame = false
                    };
                    return Ok(message);
                }
                else
                {
                    var message = new ResponseDTO
                    {
                        Message = $"YAY! You guessed correctly. Congratulations, the number was {_service.GetGuess(id)}.",
                        Id = id,
                        Tries = _service.NumberOfTriesLeft(id),
                        PlayingGame = false,
                        WonGame = true
                    };
                    GameInstance newGameInstance = new GameInstance
                    {
                        UsernameId = username,
                        RandomNumber = _service.GetGuess(id),
                        NumberOfTries = _service.NumberOfTriesLeft(id),
                        GameStatus = "Won"
                    };
                    _context.GameInstances.Add(newGameInstance);
                    _context.SaveChanges();

                    return Ok(message);
                }

            }
            catch (Exception)
            {
                var message = new ResponseDTO
                {
                    Message = $"Sorry, you're out of guesses. The number was {_service.GetGuess(id)}.",
                    Id = id,
                    Tries = _service.NumberOfTriesLeft(id),
                    PlayingGame = false,
                    WonGame = false
                };
                GameInstance newGameInstance = new GameInstance
                {
                    UsernameId = username,
                    RandomNumber = _service.GetGuess(id),
                    NumberOfTries = _service.NumberOfTriesLeft(id),
                    GameStatus = "Loss"
                };
                _context.GameInstances.Add(newGameInstance);
                _context.SaveChanges();

                return Ok(message);
            }

        }
    }

   

}
