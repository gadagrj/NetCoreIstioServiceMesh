using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCoreIstio.Web.Service
{
    public interface IUserServiceClient
    {
        Task<IEnumerable<User>> GetUserAsync();
    }
    public class UserServiceClient : IUserServiceClient
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;

        public UserServiceClient(HttpClient client, IHttpContextAccessor httpContextAccessor, ILoggerFactory loggerFactory)
        {
            this._client = client;
            this._httpContextAccessor = httpContextAccessor;
            _logger = loggerFactory.CreateLogger<UserServiceClient>();
        }
        public async Task<IEnumerable<User>> GetUserAsync()
        {
            try
            {
               var userAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"].ToString();

                var incomingHeaders = new[] {"x-request-id",
                       "x-b3-traceid",
                       "x-b3-spanid",
                       "x-b3-parentspanid",
                       "x-b3-sampled",
                       "x-b3-flags",
                       "x-ot-span-context"
                        };
                foreach (var header in incomingHeaders)
                {
                    if (_httpContextAccessor.HttpContext.Request.Headers.Keys.Contains(header))
                    {
                        _client.DefaultRequestHeaders.Add(header, new string[] { _httpContextAccessor.HttpContext.Request.Headers[header] });
                    }
                }

                var reviewsResponse = await _client.GetAsync($"api/user");

                var reviews = await reviewsResponse.Content.ReadAsAsync<List<User>>();

                return reviews;
            }
            catch (System.Exception ex )
            {
                return null;
            }
        }
    }
}
