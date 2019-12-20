using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecretSanta.Models;
using SecretSanta.Interfaces;

namespace SecretSanta.Services
{
    public class NewUser
    {
        public async Task AddUser()
        {
            Console.WriteLine("Please, enter your name");
            using (var context = new SecretSantaContext())
            {
                while (true)
                {
                    string nameEntered = Console.ReadLine().ToLower();
                    var existingUser = context.Users.Where(n => n.Name.Contains(nameEntered)).FirstOrDefault();
                    if (existingUser == null)
                    {
                        var newUser = new User();
                        newUser.Name = nameEntered;
                        IUserCreation userCreation = new UserCreation();
                        await userCreation.CreateUser(newUser);
                        await AnotherUser();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This name already exists. Try using another one, please");
                    }
                }

            }

        }
        public async Task AnotherUser()
        {
            Console.WriteLine("Enter <y> if you want to add another user of anything else to continue");
            string answer = Console.ReadLine().ToLower();
            if (answer == "y")
            {
                await AddUser();
            }
        }
    }
}
