using Hachette.API.SDK.Core.DI.Interfaces;

namespace Hachette.API.SDK.Core.Endpoints
{
    /// <summary>
    /// Details for accessing our Test API.
    /// </summary>
    public class TestEndpoint : IEndpoint
    {
        private string currentVersion = default;
        
        /// <summary>
        /// Current API Version.
        /// </summary>
        /// <value></value>
        public string CurrentVersion {get {return this.currentVersion;}}

        private string baseUrl = default;
        
        /// <summary>
        /// Base URL
        /// </summary>
        /// <value></value>
        public string BaseUrl {get{return this.baseUrl;}}

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="currentVersion"></param>
        /// <param name="baseUrl"></param>
        public TestEndpoint (string currentVersion, string baseUrl )
        {
            if (!string.IsNullOrEmpty(currentVersion))
            {
                this.currentVersion = currentVersion;
            }
            if (!string.IsNullOrEmpty(baseUrl))
            {
                this.baseUrl = baseUrl;
            }
        }
    }
}