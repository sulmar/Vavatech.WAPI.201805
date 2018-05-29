using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using Vavatech.WAPI.Models;

namespace Vavatech.WAPI.Service.Formatters
{
    public class QrCodeMediaTypeFormatter : MediaTypeFormatter
    {

        public QrCodeMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("image/png"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(Customer);
        }

        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            Customer customer = (Customer)value;

            string uri = $"https://chart.googleapis.com/chart?cht=qr&chl={customer.Name}&chs=160x160&chld=L|0";


            using (var client = new WebClient())
            {
                byte[] image = await client.DownloadDataTaskAsync(uri);

                await writeStream.WriteAsync(image, 0, image.Length);
            }
        }
    }
}