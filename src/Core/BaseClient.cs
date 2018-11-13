
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Hachette.API.SDK.Core.DI.Interfaces;
using Hachette.API.SDK.Core.DI.Modules;
using Hachette.API.SDK.Extensions;
using Hachette.API.SDK.Interfaces;
using Hachette.API.SDK.SimpleDI.Containers;
using Hachette.API.SDK.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Hachette.API.SDK.Core
{
    /// <summary>
    /// Core Base Client for creating REST Clients.
    /// </summary>
    public class BaseClient : IRestClient
    {
        private readonly IServiceProvider container;

        /// <summary>
        /// Default Constructor.
        /// </summary>
        /// <param name="security"></param>
        public BaseClient(IHachetteSecurity security)
        {
            this.Security = security;
            this.assemblyVersion = GetVersion();
            this.container = null;
            this.container = new SimpleContainer()
                                .Register(new EndpointModule())
                                .Build();
            this.Endpoint = this.container.GetService<IEndpoint>();
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
        private string assemblyVersion;


        /// <summary>
        /// Previous versions of the API.
        /// </summary>
        /// <value>Versions that have not been depreciated.</value>
        public List<string> PreviousVersions { get; private set; }

        /// <summary>
        /// Connection details of API.
        /// </summary>
        /// <value>Details for connecting to an Endpoint.</value>
        public BaseClient(IEndpoint endpoint)
        {
            this.Endpoint = endpoint;

        }
        public IEndpoint Endpoint { get; set; }

        /// <summary>
        /// Hachette Security object. Will be used when communicating with API.
        /// </summary>
        public IHachetteSecurity Security { get; private set; }

        //TODO: baseUrl needs to be an optional parameter

        /// /// <summary>
        /// Simple GET Method to obtain a JSON payload.
        /// </summary>
        /// <param name="queryStringParameters"></param>
        /// <param name="urlOverride"></param>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns>JSON response.</returns>
        public async virtual Task<dynamic> GetAsync(IHachetteCommonParameters queryStringParameters, string urlOverride = null)
        {

            Trashcan.AllAreNull($"both {nameof(urlOverride)} & {this.Endpoint.BaseUrl} are null",
                                urlOverride,
                                this.Endpoint.BaseUrl);
            Trashcan.IsNull(nameof(queryStringParameters), queryStringParameters);

            //baseUrl is basically an override and should be treated as such.
            string urlToUse = string.Empty;
            if (string.IsNullOrEmpty(urlOverride))
            {
                Trashcan.IsNull(nameof(this.Endpoint.BaseUrl), this.Endpoint.BaseUrl);
                urlToUse = this.Endpoint.BaseUrl;
            }
            else
            {
                urlToUse = urlOverride;
            }
            using (var request = new HttpRequestMessage(HttpMethod.Get, new Uri($"{urlToUse}{queryStringParameters.BuildQueryString()}")))
            {
                request.Headers.Add("x-apikey", new[] { this.Security.DeveloperKey });
                request.Headers.Add("x-sdk", $"dotnet-{this.assemblyVersion}");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var settings = new JsonSerializerSettings(){
                        TypeNameHandling = TypeNameHandling.All,
                        TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full
                    };
                    var s = await response.Content.ReadAsStringAsync();
                    dynamic  json = JObject.Parse(s);
                    return json;
                }
            }
            return default(dynamic);
        }
        public async Task<dynamic> GetACollectionAsync(string baseUrl, IHachetteCommonParameters queryStringParameters)
        {
            Trashcan.AllAreNull($"both {nameof(baseUrl)} & {this.Endpoint.BaseUrl} are null",
                                baseUrl,
                                this.Endpoint.BaseUrl);
            Trashcan.IsNull(nameof(queryStringParameters), queryStringParameters);

            //baseUrl is basically an override and should be treated as such.
            string urlToUse = string.Empty;
            if (string.IsNullOrEmpty(baseUrl))
            {
                Trashcan.IsNull(nameof(this.Endpoint.BaseUrl), this.Endpoint.BaseUrl);
                urlToUse = this.Endpoint.BaseUrl;
            }
            else
            {
                urlToUse = baseUrl;
            }
            using (var request = new HttpRequestMessage(HttpMethod.Get, new Uri($"{urlToUse}{queryStringParameters.BuildQueryString()}")))
            {
                request.Headers.Add("x-apikey", new[] { this.Security.DeveloperKey });
                request.Headers.Add("x-sdk", $"dotnet-{this.assemblyVersion}");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var s = await response.Content.ReadAsStringAsync();
                    dynamic  json = JArray.Parse(s);
                    return json;
                }
            }
            return default(dynamic);
        }

        /// <summary>
        /// Gets the current Assembly Version.n
        /// </summary>
        /// <returns></returns>
        private string GetVersion()
        {
            return typeof(BaseClient).Assembly.GetName().Version.ToString();
        }




    }
}