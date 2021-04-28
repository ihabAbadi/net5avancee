using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace exampleMVCApplication.Services
{
    //public class OurBackgroundService : IHostedService
    //{
    //    public Task StartAsync(CancellationToken cancellationToken)
    //    {
    //        //Logique metier de notre background task
    //        Debug.WriteLine("Start our backgournd task");
    //        return Task.CompletedTask;
    //        //throw new NotImplementedException();
    //    }

    //    public Task StopAsync(CancellationToken cancellationToken)
    //    {
    //        Debug.WriteLine("End of our background task");
    //        return Task.CompletedTask;
    //        //throw new NotImplementedException();
    //    }
    //}

    public class OurBackgroundService : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Debug.WriteLine("Start our backgournd task");
            return Task.CompletedTask;
        }
    }
}
