namespace Hachette.API.SDK.Core.DI.Interfaces
{
    /// <summary>
    /// Contract for the ConnectionInformation
    /// </summary>
    public interface IEndpoint
    {   
        /// <summary>
        /// Current (Stable) Hachette UK Version.
        /// </summary>
        /// <value>Version Number</value>
        string CurrentVersion {get;}

        /// <summary>
        /// BaseURL
        /// </summary>
        /// <value>URL</value>
        string BaseUrl {get;}
    }
}