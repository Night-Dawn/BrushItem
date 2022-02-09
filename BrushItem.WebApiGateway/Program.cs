using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrushItem.WebApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.UseStartup<Startup>()
                    .UseUrls("https://localhost:3000")//������������������ip
                    .UseKestrel(option =>
                    {
                        option.ConfigureHttpsDefaults(o =>
                        {
                            o.ServerCertificate =
                            new System.Security.Cryptography.X509Certificates.X509Certificate2(@"./localhost.pfx", "123456789");//֤��·��������
                        });
                    });
                });
    }
}
