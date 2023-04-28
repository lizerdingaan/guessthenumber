using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Services
{
    public interface ISingletonService
    {

        int AddNew();

        int DecrementNumberOfTries(int id);

        int NumberOfTriesLeft(int id);

        bool Guess(int guess, int id);

        int GetGuess(int id);
    }
}
