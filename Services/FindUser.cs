using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Services
{
    public class FindUser
    {
        public async Task FindAUser()
        {
            using (var context = new SecretSantaContext())
            {
                Console.WriteLine("Please, enter your name");
                string nameEntered = Console.ReadLine().ToLower();
                var existingUser = context.Gifters.Where(n => n.User.Name.Contains(nameEntered)).FirstOrDefault();
                if (existingUser != null)
                {
                    Console.WriteLine($"So, {existingUser.User.Name}, you should make a gift to {existingUser.GiftsTo.Name}");
                }
                else
                {
                    Console.WriteLine("The entered name is not found. Do you want to create a new user?");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "y")
                    {
                        NewUser newUser = new NewUser();
                        await newUser.AddUser();
                    }
                }

            }
        }
    }
}
