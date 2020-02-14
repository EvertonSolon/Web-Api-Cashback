using Cashback_WebApi.Models;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cashback_WebApi.Extensoes
{
    public static class RetryPolicyExtensions
    {
        public static HttpResponseMessage ExecuteWithToken(this RetryPolicy<HttpResponseMessage> retryPolicy,
            TokenModel token, Func<Context, HttpResponseMessage> action)
        {
            var retryPolicy_ = retryPolicy.Execute(action,
                new Dictionary<string, object>
                {
                    { "AccessToken", token.Token }
                });

            return retryPolicy_;
        }
    }
}
