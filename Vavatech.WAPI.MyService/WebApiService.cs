using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.WAPI.MyService
{

   

    public class WebApiService 
    {
        private IDisposable _webapp;

        private readonly string url;

        public WebApiService(string url)
        {
            this.url = url;
        }

        public void Start()
        {
            

            _webapp = WebApp.Start<Startup>(url);
        }

        public void Stop()
        {
            _webapp.Dispose();
        }



    }
}
