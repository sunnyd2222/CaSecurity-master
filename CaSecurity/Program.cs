using CaSecurity.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CaSecurity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

            var host = CreateWebHostBuilder(args)
                .UseKestrel()
                //.UseContentRoot(Directory.GetCurrentDirectory())
                .UseUrls("http://localhost:5000", "http://casecurity.net:5000", "http://10.237.134.75:5000")
                .UseIISIntegration()
                .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    context.Database.Migrate();
                    DbInitializer.Seed(context);
                }
                catch (Exception ex)
                {
                   // w rzeczywistej sytuacji moglbym to zarejestrować 
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
