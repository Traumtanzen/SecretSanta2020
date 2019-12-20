using SecretSanta.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Interfaces
{
    interface IUserCreation
    {
        public Task CreateUser(User user);
    }
}
