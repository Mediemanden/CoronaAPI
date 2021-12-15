using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoronaAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // using ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            //     builder.AddJsonConsole(options =>
            //     {
            //         options.JsonWriterOptions = new JsonWriterOptions
            //         {
            //             Indented = true,
            //             SkipValidation = false,
            //             Encoder = JavaScriptEncoder.Default
            //         };
            //         options.IncludeScopes = true;
            //         options.TimestampFormat = "yyyy-MM-dd HH:mm:ss,SSS";
            //     }));
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
