using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Services
{
    public interface ISingletonService
    {

        Guid AddNew();

        int DecrementNumberOfTries(Guid id);

        int NumberOfTriesLeft(Guid id);

        bool Guess(int guess, Guid id);

        int GetGuess(Guid id);
    }
}
