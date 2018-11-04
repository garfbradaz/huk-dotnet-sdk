using System;

namespace Hachette.API.SDK.SimpleDI.Interfaces
{
    /// <summary>
    /// Simple Container Builder Contract.
    /// </summary>
    public interface ISimpleContainerBuilder
    {
        /// <summary>
        /// Register Modules with the Container.
        /// </summary>
        /// <param name="module"></param>
        /// <returns>Itself.</returns>
         ISimpleContainerBuilder Register(IModule module = null);
         
         /// <summary>
         /// Build a Container with Modules and Dependencies.
         /// </summary>
         /// <returns>Service Provider</returns>
         IServiceProvider Build();
    }
}