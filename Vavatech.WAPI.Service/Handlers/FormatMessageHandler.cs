using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Vavatech.WAPI.Service.Handlers
{
    public class FormatMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var parameters = request.GetQueryNameValuePairs();

            var keyValueFormat = parameters.FirstOrDefault(p => p.Key == "format");

            if (!string.IsNullOrEmpty(keyValueFormat.Value))
            {
                string format = keyValueFormat.Value;

                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(format));

            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}