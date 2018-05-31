using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace Pharmacy.WebAPI.MessageHandler
{
    public class ApiKeyHandler : DelegatingHandler
    {
      

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri.ToString().Contains("api/InvalidateCache") || request.RequestUri.ToString().Contains("api/Export"))
                return await base.SendAsync(request, cancellationToken);
            var isValidApiKey = false;
            IEnumerable<string> apiHeader;
            IEnumerable<string> userHeader;

            var checkApiKeyExists = request.Headers.TryGetValues("ApiKey", out apiHeader);
            var checkUserExists = request.Headers.TryGetValues("User", out userHeader);
            if (!checkUserExists)
            {
                return request.CreateErrorResponse(HttpStatusCode.Forbidden, "User Not Found");

            }
            if (checkApiKeyExists)
            {

                if (apiHeader.FirstOrDefault() != null && apiHeader.FirstOrDefault().Equals("abcd"))
                {
                    isValidApiKey = true;
                }

            }

            if (!isValidApiKey) return request.CreateResponse(HttpStatusCode.Forbidden, "Bad API key");
            return await base.SendAsync(request, cancellationToken);
        }
    }
}