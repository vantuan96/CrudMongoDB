using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CRUDMongoDB
{
    //    public static void Main(string[] args)
        //    {
        //        CreateHostBuilder(args).Build().Run();
        //    }

        //    public static IHostBuilder CreateHostBuilder(string[] args) =>
        //  Host.CreateDefaultBuilder(args)
        //    .ConfigureWebHostDefaults(builder =>
        //    {
        //        builder.ConfigureKestrel(opts =>
        //        {
        //          // ...
        //      })
        //        .UseStartup<Startup>();
        //    })
        //    .ConfigureServices(services =>
        //    {
        //        //services.AddHostedService<"">();
        //    });
        public class Program
        {
            public static void Main(string[] args)
            {
                CreateWebHostBuilder(args).Build().Run();
            }

            public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
              WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        }
    }


