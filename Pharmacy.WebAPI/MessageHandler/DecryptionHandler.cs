using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Pharmacy.Utility;
using Pharmacy.Model.Entity;

namespace Pharmacy.WebAPI.MessageHandler
{
    public class DecryptionHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request.RequestUri.ToString().Contains("api/InvalidateCache"))
                return await base.SendAsync(request, cancellationToken);
            var encryption = new Encryption(ConstantEntity.KEY, ConstantEntity.IV);
            var nameValues = HttpUtility.ParseQueryString(HttpContext.Current.Request.QueryString.ToString());
            foreach (var key in HttpContext.Current.Request.QueryString.AllKeys)
            {
                nameValues.Set(key, encryption.DecodeFromBase64String(HttpContext.Current.Request.QueryString.Get(key).Replace(" ", "+")));
            }
            request.RequestUri = new Uri(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path) + "?" + nameValues);
            return await base.SendAsync(request, cancellationToken);
        }

        private string ReconstructUrl(string url)
        {
            var encryption = new Encryption(ConstantEntity.KEY, ConstantEntity.IV);
            var parts = url.Split('/');
            var originalParts = new List<string>();
            foreach (var part in parts)
            {
                originalParts.Add((!part.Contains("@@")
                    ? part
                    : encryption.DecodeFromBase64String(part.Replace("@@", "").Replace(" ", "+"))));
            }

            return string.Join("/", originalParts);
        }
    }
}