using Hachette.API.SDK.SimpleDI.Interfaces;
using Hachette.API.SDK.SimpleDI.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace Hachette.API.SDK.SimpleDI.Containers
{
  /// <summary>
    /// Builder to compose dependencies to build a container.
    /// </summary>
    public class SimpleContainer  : ISimpleContainerBuilder
    {
        private readonly IServiceCollection services;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SimpleContainer()
        {
            this.services = new ServiceCollection();
        }

        /// <summary>
        /// Builds Service Provider.
        /// </summary>
        /// <returns>IServiceProvider</returns>
        public System.IServiceProvider Build()
        {
            return this.services.BuildServiceProvider();
        }

        /// <summary>
        /// Registers a Module.
        /// </summary>
        /// <param name="module"></param>
        /// <returns>ISimpleContainerBuilder</returns>
        public ISimpleContainerBuilder Register(IModule module = null)
        {
            if(module == null)
                module = new Module();

            module.Load(this.services);
            return this;
        }
    }
}