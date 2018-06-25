using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using WebStore.Helpers;
using WebStore.Models;

using static WebStore.Helpers.Logger;

namespace WebStore
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Logging(1, DatabaseObjectError.NotFound);

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
