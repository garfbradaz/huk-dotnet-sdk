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
        /// <typeparam name="TResponse">Object to Serialize</typeparam>
        /// <returns>Serialized JSON Payload</returns>
         Task<TResponse> GetAsync<TResponse>(Uri fullUrlAndQueryString) where TResponse : new();
    }
}