using GameCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GameWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomGuessController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly SingletonService_LEGACY singletonService;
        private int _numberToGuess;
        public int _numberOfChances;

        public RandomGuessController(IMemoryCache cache, SingletonService_LEGACY singletonService)
        {
            _memoryCache = cache;
            this.singletonService = singletonService;
            _numberOfChances = 0; // SingletonService.TurnsInstance();

        }

        [HttpGet]
        public string Get()
        {
            return "";//$"Guess a number between 1 and 20 (hint: {singletonService.numberToGuess}). Remaining guesses: {_numberOfChances}";
        }

        //randomguess/{guess}
        [HttpGet("{guess}")]
        public ActionResult<string> Guess(int guess)
        {
            if ( !_memoryCache.TryGetValue(CacheKeys._numberToGuess, out _numberToGuess))
            {
                _numberToGuess = 0;
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024,
                };
                _memoryCache.Set(CacheKeys._numberToGuess, _numberToGuess, cacheEntryOptions);

                return Ok(_numberToGuess);
            }

            _numberOfChances--;
            if (guess == _numberToGuess)
            {

                return "HOOOOOORRRAAAAYYYYYYY...Well done";
            }
            else if (guess < _numberToGuess)
            {
                return $"Number to guess is {_numberToGuess}. Too low, you have {_numberOfChances} chance(s) left to try.";
            }
            else
            {
                return $"Number to guess is {_numberToGuess}. Too high, you have {_numberOfChances} chance(s) left to try.";
            }
            
            
        }

        public static class CacheKeys
        {
            public static string _numberToGuess => "NumberToGuess";
        }
    }
}
