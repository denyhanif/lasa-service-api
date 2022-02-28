using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace his_lasa_managemenet_service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
                    .UseIISIntegration()
                    .UseUrls("http://*:7500")
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseStartup<Startup>()
                    .Build();
    }
}
