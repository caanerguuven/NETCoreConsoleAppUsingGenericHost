using ConsoleAppUsingGenericHost.Model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppUsingGenericHost
{
    public class ConsoleListener : IHostedService
    {
        private readonly IOptions<AdditionalValues> _additionalValues;
        public ConsoleListener(IOptions<AdditionalValues> additionalValues) {
            additionalValues = _additionalValues;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Started ....");
            //Do anything what you want (like Logging,processes ....)

            Console.WriteLine("Listening ....");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stopping.");
            Console.WriteLine($"Date  : {DateTime.Now}");

            Console.WriteLine("Do anything when console stopped. ");
            return Task.CompletedTask;
        }
    }
}
