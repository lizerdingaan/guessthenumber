using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.Services
{
    abstract class Register
    {
        public abstract Task<bool> NewUser(string username);

    }
}
