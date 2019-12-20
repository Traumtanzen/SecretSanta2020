using SecretSanta.Interfaces;
using SecretSanta.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Services
{
    public class UserCreation : IUserCreation
    {
        public async Task CreateUser(User user)
        {
            using (var context = new SecretSantaContext())
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
        }
    }
}
