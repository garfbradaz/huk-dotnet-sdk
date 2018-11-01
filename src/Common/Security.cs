using Hachette.API.SDK.Interfaces;

namespace Hachette.API.SDK.Common
{
    /// <summary>
    /// Security Information needed when 
    /// talking to the Hachette API.
    /// </summary>
    public class Security : IHachetteSecurity
    {
        /// <summary>
        /// API Developer Key issued by our API Portal.
        /// </summary>
        /// <value></value>
        public string DeveloperKey {get;set;}
    }
}