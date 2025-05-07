using System.Net.Http;
using Unicorn.Backend.Services;
#if (RestClient)
using Unicorn.Backend.Services.RestService;
#endif
#if (SoapClient)
using Unicorn.Backend.Services.SoapService;
#endif

namespace Company.ApiModule
{
#if (RestClient)
    public class NewApiClient : RestClient
#endif
#if (SoapClient)
    public class NewApiClient : SoapClient
#endif
    {
        public NewApiClient() : base("<api-base-url>") { }                      // TODO: <--------- Specify API base URL

        public NewApiClient(IServiceSession session) : base("<api-base-url>")   // TODO: <--------- Specify API base URL
        {
            Session = session;
        }

#if (RestClient)
        public RestResponse GetRequest()
        {
            return SendRequest(HttpMethod.Get, "<endpoint-relative-url>");      // TODO: <--------- Specify endpoint relative URL
        }
#endif
#if (SoapClient)
        public SoapResponse PostRequest()
        {
            return Post("<endpoint-relative-url>", "<soap-content>");           // TODO: <--------- Specify endpoint relative URL and content
        }
#endif
    }
}
