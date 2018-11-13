using System.Threading.Tasks;

namespace Hachette.API.SDK.Interfaces
{
    /// <summary>
    /// Contract for creating a RESTful client.
    /// </summary>
    public interface IRestClient  : ICore
    {

        /// <summary>
        /// GET Method, including common typed query string parameters for one record.
        /// </summary>
        /// <param name="queryStringParameters"></param>
        /// <param name="urlOverride"></param>
        /// <typeparam name="dynamic"></typeparam>
        /// <returns>Serialized JSON Payload</returns>  
        Task<dynamic> GetAsync(IHachetteCommonParameters queryStringParameters, string urlOverride = null);
     
        /// <summary>
        /// GET Method, including common typed query string parameters for a collection of records.
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="queryStringParameters"></param>
        /// <typeparam name="dynamic"></typeparam>
        /// <returns>Collection of JSON</returns>
        Task<dynamic> GetACollectionAsync(string baseUrl, IHachetteCommonParameters queryStringParameters);
    }
}