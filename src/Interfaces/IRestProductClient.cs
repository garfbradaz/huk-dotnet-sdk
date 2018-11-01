using System.Threading.Tasks;

namespace Hachette.API.SDK.Interfaces
{
    /// <summary>
    /// Interface for a RESTful Product Client.
    /// </summary>
    public interface IRestProductClient
    {
        /// <summary>
        /// Get a Product using its ISBN13
        /// </summary>
        /// <param name="isbn13"></param>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns>Product JSON</returns>
        Task<TResponse> GetProductAsync<TResponse>(string isbn13)
        where TResponse  : new();

        /// <summary>
        /// Get a collection of Products
        /// </summary>
        /// <param name="queryStringParameters"></param>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns>Product JSON</returns>
        Task<TResponse> GetProductsAsync<TResponse>(IHachetteCommonParameters queryStringParameters)
        where TResponse  : new();

    }
}