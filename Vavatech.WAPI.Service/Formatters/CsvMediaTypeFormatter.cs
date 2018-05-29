using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Vavatech.WAPI.Models;

namespace Vavatech.WAPI.Service.Formatters
{
    public class CsvMediaTypeFormatter : MediaTypeFormatter
    {
        public CsvMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/csv"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(IList<Customer>);
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            return Task.Run(()=> WriteCsv((IList<Customer>)value, writeStream));
        }

        private void WriteCsv(IList<Customer> customers, Stream stream)
        {

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Id;Code;City;CreateDate;IsDeleted");

            foreach (var customer in customers)
            {
                stringBuilder.Append($"{customer.Id};");
                stringBuilder.Append($"{customer.Code};");
                stringBuilder.Append($"{customer.CreateDate};");
                stringBuilder.Append($"{customer.IsDeleted};");
            }

            Trace.WriteLine(stringBuilder.ToString());


            using (var writer = new StreamWriter(stream))
            {
                writer.Write(stringBuilder);
            }
        }



    }
}