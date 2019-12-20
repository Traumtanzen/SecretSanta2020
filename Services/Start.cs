using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecretSanta.Models;

namespace SecretSanta.Services
{
    public class Start
    {
        public async Task Starting()
        {
            using (var context = new SecretSantaContext())
            {
                NewUser newUser = new NewUser();
                GiftRandom randomize = new GiftRandom();

                Console.WriteLine("Hello! This is Secret Santa 2020!" +
                    "\nAre you a new user?");
                while (true)
                {
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "y")
                    {
                        await newUser.AddUser();
                        break;
                    }
                    else if (answer == "n")
                    {
                        FindUser find = new FindUser();
                        await find.FindAUser();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong. Please enter \"y\" or\"n\"");
                    }

                }
                if (IsOdd(context.Users.Count()) && context.Users.Count() != 0)
                {
                    Console.WriteLine("Let's wait for at least one more user.");
                }
                else
                {
                    await randomize.RandomizeGifters();
                }
            }
        }
        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
    }
}
