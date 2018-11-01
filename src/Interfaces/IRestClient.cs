using System;
using System.Threading.Tasks;

namespace Hachette.API.SDK.Interfaces
{
    /// <summary>
    /// Contract for creating a RESTful client.
    /// </summary>
    public interface IRestClient  : ICore
    {

         /// <summary>
         /// GET Method, including common typed query string parameters.
         /// </summary>
         /// <param name="url"></param>
         /// <param name="queryStringParameters"></param>
         /// <typeparam name="TResponse">Type expecting from API.</typeparam>
         /// <returns>Serialized JSON Payload</returns>
         Task<TResponse> GetAsync<TResponse>(string baseUrl, IHachetteCommonParameters queryStringParameters)
         where TResponse  : new();
    }
}