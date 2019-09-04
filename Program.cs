using ConsoleAppUsingGenericHost.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace ConsoleAppUsingGenericHost
{
    static class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("How to Use .NET Core Console Application as Generic Host with HostBuilder ?");
            /*
             For this, We have to add below dlls to your project from Nuget.
                -- Microsoft.Extensions.Configuration.Json
                -- Microsoft.Extensions.Hosting;
                -- Microsoft.Extensions.Configuration;

            On the other hand, To run this project, You mast add "<LangVersion>latest</LangVersion>" tag to your project .csproj file. 
             */
            var builder = new HostBuilder()
                         .ConfigureAppConfiguration((hostingContext, config) =>
                        {
                            config.AddJsonFile("appsettings.json", optional: true);//adding jsonfile
                        })
                          .ConfigureServices((hostContext, services) => {
                              services.AddOptions();
                              services.Configure<AdditionalValues>(conf => hostContext.Configuration.GetSection("AdditionalValues").Bind(conf)); //binding additionalValues section to AdditionalValues class.

                              services.AddSingleton<IHostedService, ConsoleListener>(); //defining ConsoleListener class as HostedService
                          });

            await builder.RunConsoleAsync();
        }
    }
}
