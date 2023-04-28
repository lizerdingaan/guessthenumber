
using GameCore.DTO;
using GameCore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;


namespace GameWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly ISingletonService _service;
        private readonly IUserInput _userInputService;
        public bool wonGame = false;

        public GameController(ISingletonService service)
        {
            _service = service;
        }


        [HttpGet("api/start")]
        public IActionResult StartGame()
        {
            int Id = _service.AddNew();

            // Console.WriteLine(_service.NumberOfTriesLeft(Id));

            var message = new ResponseDTO
            {
                Message = $"Guess a number between 1 and 20. You have {_service.NumberOfTriesLeft(Id)} tries",
                Id = Id,
                Tries = _service.NumberOfTriesLeft(Id),
                PlayingGame = true
            };

            return Ok(message);
        }

        [HttpGet("{id}/{guess}")]
        public IActionResult Guess([FromRoute] int id, [FromRoute] int guess)
        {
            //Guid GameId = service_.AddNew();
            
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
                        PlayingGame = false
                    };
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
                        PlayingGame = true
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
                        PlayingGame = true
                    };
                    return Ok(message);
                }
                else
                {
                    var message = new ResponseDTO
                    {
                        Message = $"YAY! You guessed correctly.",
                        Id = id,
                        Tries = _service.NumberOfTriesLeft(id),
                        PlayingGame = false
                    };

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
                    PlayingGame = false
                };
                return Ok(message);
            }


        }

    }
}
