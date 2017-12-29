

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace SecureAPI.Filters
{
    public class HMACAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        private static Dictionary<string, string> allowedApps = new Dictionary<string, string>();
        private readonly UInt64 requestMaxAgeInSeconds = 300;  //5 mins
        private readonly string authenticationScheme = "amx";

        public bool AllowMultiple { get; private set; }

        public HMACAuthenticationAttribute()
        {
            if (allowedApps.Count == 0)
            {
                allowedApps.Add("4d53bce03ec34c0a911182d4c228ee6c", "A93reRTUJHsCuQSHR+L3GxqOJyDmQpCgps102ciuabc=");
            }
        }

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;

            if (request.Headers.Authorization != null &&
                authenticationScheme.Equals(request.Headers.Authorization.Scheme, StringComparison.OrdinalIgnoreCase))
            {
                var authenticationHeaderParam = request.Headers.Authorization.Parameter;
                var authorizationHeaderArray = GetAuthorizationHeaderArray(authenticationHeaderParam);
                if (authorizationHeaderArray != null)
                {
                    var APPId = authorizationHeaderArray[0];
                    var base64Signature = authorizationHeaderArray[1];
                    var nonce = authorizationHeaderArray[2];
                    var requestTimeStamp = authorizationHeaderArray[3];

                    var isValid = isValidaRequest(request, APPId, base64Signature, nonce, requestTimeStamp);
                    if (isValid.Result)
                    {
                        
                    }
                }
            }
            
        }

        private async Task<bool> isValidaRequest(System.Net.Http.HttpRequestMessage request, string APPId, string base64Signature, string nonce, string requestTimeStamp)
        {
            throw new NotImplementedException();
        }

        private string[] GetAuthorizationHeaderArray(string authenticationHeaderParam)
        {
            var splitValue = authenticationHeaderParam.Split(':');
            if (splitValue.Length == 4)
            {
                return splitValue;
            }
            return null;
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        
    }
}