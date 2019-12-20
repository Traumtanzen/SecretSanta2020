using SecretSanta.Services;
using System;
using System.Threading.Tasks;

namespace SecretSanta
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Start start = new Start();
            await start.Starting();
            Console.WriteLine("Happy Holidays!");
        }
    }
}
