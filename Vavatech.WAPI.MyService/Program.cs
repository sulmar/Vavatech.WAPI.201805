using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Vavatech.WAPI.MyService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello My Service");

            string url = "http://localhost:5000";


            // Install-Package Topshelf

            HostFactory.Run(config =>
            {
                config.Service<WebApiService>(sc =>
                {
                    sc.ConstructUsing(() => new WebApiService(url));
                    sc.WhenStarted(s => s.Start());
                    sc.WhenStopped(s => s.Stop());
                });

                config.RunAsLocalSystem();
                config.SetServiceName("VavatechService");
                config.SetDescription("My Service");


                config.StartAutomatically();
            });

            //WebApiService webApiService = new WebApiService();
            //webApiService.Start();

            //Console.WriteLine("Press any key to exit.");

            //Console.ReadLine();

            //webApiService.Stop();
        }
    }
}
