using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Vavatech.WAPI.Service.Handlers
{
    public class TraceMessageHandler : DelegatingHandler
    {

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Trace.WriteLine($"{request.Method} : {request.RequestUri}");

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            Trace.WriteLine($"{response.StatusCode} {response.ReasonPhrase}");

            return response;
        }
    }
}