using Hachette.API.SDK.SimpleDI.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hachette.API.SDK.SimpleDI.Modules
{
    /// <summary>
    /// Base Module to be overridden / inherited.
    /// </summary>
    public  class Module : IModule
    {
        /// <summary>
        /// Load Services,
        /// </summary>
        /// <param name="services"></param>
        public virtual void Load(IServiceCollection services){}
    }
}