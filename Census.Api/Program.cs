﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Census.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //LogBootstrapper.Bootstrap(); //TODO up to here

            var builder = CreateWebHostBuilder(args);
            var webHost = builder.Build();
            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}