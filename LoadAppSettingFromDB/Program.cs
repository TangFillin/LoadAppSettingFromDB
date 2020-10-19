using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoadAppSettingFromDB.ConfigurationSet;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LoadAppSettingFromDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(configBuilder=>
                {
                    var configuration = configBuilder.Build();
                    configBuilder.AddEntityFramework(config => config.UseOracle(configuration.GetConnectionString("Oracle")));
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
