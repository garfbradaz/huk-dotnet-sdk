using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Hachette.API.SDK.Extensions;
using Hachette.API.SDK.Interfaces;
using Hachette.API.SDK.Utilities;
using Newtonsoft.Json;

namespace Hachette.API.SDK.Core
{
    /// <summary>
    /// Core Base Client for creating REST Clients.
    /// </summary>
    public class BaseClient : IRestClient
    {
        /// <summary>
        /// Default Constructor.
        /// </summary>
        /// <param name="security"></param>
        public BaseClient(IHachetteSecurity security)
        {
            this.Security = security;
            this.assemblyVersion = GetVersion();
        }
        /// <summary>
        /// Reusable Instance HTTP Client.
        /// </summary>
        /// <returns>HTTP Client</returns>
        protected static HttpClient client = new HttpClient();

        /// <summary>
        /// Save the current Assembly Version to send 
        /// out in reporting headers.
        /// </summary>
        private  string assemblyVersion;

       
        /// <summary>
        /// Previous versions of the API.
        /// </summary>
        /// <value>Versions that have not been depreciated.</value>
        public List<string> PreviousVersions {get;private set;}

        /// <summary>
        /// Connection details of API.
        /// </summary>
        /// <value>Details for connecting to an Endpoint.</value>
        public IEndpoint Endpoint {get;set;}

        /// <summary>
        /// Hachette Security object. Will be used when communicating with API.
        /// </summary>
        public  IHachetteSecurity Security {get;private set;}

        /// <summary>
        /// Simple GET Method to obtain a JSON payload.
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="queryStringParameters"></param>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns>JSON response.</returns>
        public async Task<TResponse> GetAsync<TResponse>(string baseUrl, IHachetteCommonParameters queryStringParameters) 
        where TResponse : new()
        {
            Trashcan.AllAreNull($"both {nameof(baseUrl)} & {this.Endpoint.BaseUrl} are null",
                                baseUrl,
                                this.Endpoint.BaseUrl);
            Trashcan.IsNull(nameof(queryStringParameters),queryStringParameters);
            
            //baseUrl is basically an override and should be treated as such.
            string urlToUse = string.Empty;
            if(string.IsNullOrEmpty(baseUrl))
            {
                Trashcan.IsNull(nameof(this.Endpoint.BaseUrl),this.Endpoint.BaseUrl);
                urlToUse = this.Endpoint.BaseUrl;
            }
            else {
                urlToUse = baseUrl;
            }
            using(var request = new HttpRequestMessage(HttpMethod.Get,new Uri($"{urlToUse}{queryStringParameters.BuildQueryString()}")))
            {
                request.Headers.Add("x-apikey",new []{this.Security.DeveloperKey});
                request.Headers.Add("x-sdk",$"dotnet-{this.assemblyVersion}");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.SendAsync(request);
                if(response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<TResponse>(
                        await response.Content.ReadAsStringAsync()
                    );
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the current Assembly Version.n
        /// </summary>
        /// <returns></returns>
        private string GetVersion()
        {
            return  typeof(BaseClient).Assembly.GetName().Version.ToString();
        }
    }
}