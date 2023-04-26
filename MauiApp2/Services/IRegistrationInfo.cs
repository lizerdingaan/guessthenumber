using GameCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.Services
{
    public interface IRegistrationInfo
    {
        Task<bool> NewUser(string username);

        Task<bool> AddNewUser(string username);
    }
}
