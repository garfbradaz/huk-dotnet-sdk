using Hachette.API.SDK.Core;
using Hachette.API.SDK.Interfaces;

namespace Hachette.API.SDK
{
    /// <summary>
    /// Hachette UK REST Client.
    /// </summary>
    public class RestClient : BaseClient
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="security">HUK Security details.</param>
        public RestClient(IHachetteSecurity security) : 
        base(security)
        {
        }
    }
}