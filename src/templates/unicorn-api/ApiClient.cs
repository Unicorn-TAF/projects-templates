using System.Net.Http;
using Unicorn.Backend.Services;
using Unicorn.Backend.Services.RestService;

namespace Company.ApiModule
{
    /// <summary>
    /// Implementation of REST api client (should inherit <see cref="RestClient"/>)
    /// </summary>
    public class ApiClient : RestClient
    {
        public ApiClient() : base("<api-base-url>") { }                     // TODO: <--------- Specify API base URL

        public ApiClient(IServiceSession session) : base("<api-base-url>")  // TODO: <--------- Specify API base URL
        {
            Session = session;
        }

        public RestResponse GetRequest()
        {
            return SendRequest(HttpMethod.Get, "<endpoint-relative-url>");  // TODO: <--------- Specify endpoint relative URL
        }
    }
}
