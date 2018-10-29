using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Hachette.API.SDK.Extensions;
using Hachette.API.SDK.Interfaces;

namespace Hachette.API.SDK
{
    public class RestClient : IRestClient
    {
        private static HttpClient client = new HttpClient();
        private readonly IHachetteSecurity security;
        /// <summary>
        /// Hachette Security object. Will be used when communicating with API.
        /// </summary>
        public  IHachetteSecurity Security {get {return security;}}
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="security">HUK Security details.</param>
        public RestClient(IHachetteSecurity security)
        {
            this.security = security;
        }
        public Task<TResponse> GetAsync<TResponse>(string url, 
                                                    IHachetteCommonParameters queryStringParameters) 
        where TResponse : new()
        {
            queryStringParameters.BuildQueryString();
            //await client.SendAsync();
            throw new NotImplementedException();
        }
    }
}