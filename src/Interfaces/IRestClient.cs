using System;
using System.Threading.Tasks;

namespace Hachette.API.SDK.Interfaces
{
    /// <summary>
    /// Contract for creating a RESTful client.
    /// </summary>
    public interface IRestClient
    {
        /// <summary>
        /// Hachette Security options.
        /// </summary>
        /// <value></value>
        IHachetteSecurity Security {get;}

        /// <summary>
        /// GET Method.
        /// </summary>
        /// <param name="fullUrlAndQueryString"></param>
        /// <typeparam name="TResponse">Type expecting from API</typeparam>
        /// <returns>Serialized JSON Payload</returns>
         Task<TResponse> GetAsync<TResponse>(Uri fullUrlAndQueryString) where TResponse : new();
         /// <summary>
         /// GET Method, including common typed query string parameters.
         /// </summary>
         /// <param name="url"></param>
         /// <param name="queryStringParameters"></param>
         /// <typeparam name="TResponse">Type expecting from API.</typeparam>
         /// <returns>Serialized JSON Payload</returns>
         Task<TResponse> GetAsync<TResponse>(string url, IHachetteCommonParameters queryStringParameters)
         where TResponse  : new();
    }
}