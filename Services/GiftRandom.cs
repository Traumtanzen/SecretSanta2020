using SecretSanta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSanta.Services
{
    public class GiftRandom
    {
        public async Task RandomizeGifters()
        {
            Console.WriteLine("Making some Christmas magic...");
            using (var context = new SecretSantaContext())
            {
                List<User> gifters = new List<User>();
                gifters.AddRange(context.Users);
                gifters.OrderBy(n => n.Name);
                List<User> giftsTo = new List<User>();
                giftsTo.AddRange(context.Users);
                giftsTo.OrderBy(o => Guid.NewGuid());
                while (gifters.Count != 0)
                {
                    if (gifters.ElementAt(0).Name != giftsTo.ElementAt(0).Name)
                    {
                        Gifter newGifter = new Gifter();
                        newGifter.User = gifters.ElementAt(0);
                        newGifter.GiftsTo = giftsTo.ElementAt(0);
                        context.Gifters.Add(newGifter);
                        gifters.RemoveAt(0);
                        giftsTo.RemoveAt(0);
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        giftsTo.OrderBy(o => Guid.NewGuid());
                    }
                }
            }
        }
    }
}


