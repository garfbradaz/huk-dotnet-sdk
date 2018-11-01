using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Hachette.API.SDK.Core;
using Hachette.API.SDK.Extensions;
using Hachette.API.SDK.Interfaces;
using Newtonsoft.Json;

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