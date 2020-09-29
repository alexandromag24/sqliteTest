using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using sqliteTest.Models;

namespace sqliteTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                 .UseKestrel((context, options) =>
                 {
                     var port = Environment.GetEnvironmentVariable("PORT");
                     if (!string.IsNullOrEmpty(port))
                     {
                         options.ListenAnyIP(int.Parse(port));
                     }
                 });
    }
}
