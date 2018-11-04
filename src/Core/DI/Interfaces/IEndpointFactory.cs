namespace Hachette.API.SDK.Core.DI.Interfaces
{
    /// <summary>
    /// Contract for a Endpoint Factory
    /// </summary>
    public interface IEndpointFactory
    {
        /// <summary>
        /// Creates an Endpoint.
        /// </summary>
        /// <param name="endpointType"></param>
        /// <typeparam name="TEndpoint"></typeparam>
        /// <returns><see cref="Endpoint"></returns>
        IEndpoint Create(string endpointType);
    }
}