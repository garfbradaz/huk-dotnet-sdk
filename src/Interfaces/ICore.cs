using System.Collections.Generic;
using Hachette.API.SDK.Interfaces;

namespace Hachette.API.SDK.Interfaces
{
    /// <summary>
    /// Core of the Rest Client.
    /// </summary>
    public interface ICore
    {
        /// <summary>
        /// List for reference, previous version numbers
        /// </summary>
        /// <value>Only contain valid version numbers.true Any depreciated
        /// wont exist.</value>
        List<string> PreviousVersions {get;}
        
        /// <summary>
        /// Details that hold the which API
        /// is in use.
        /// </summary>
        /// <value>Connection Details.</value>
        IEndpoint Endpoint {get;}

        /// <summary>
        /// Hachette Security options.
        /// </summary>
        /// <value>Credentials for API</value>
        IHachetteSecurity Security {get;}
    }
}