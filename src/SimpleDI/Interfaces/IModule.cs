using Microsoft.Extensions.DependencyInjection;

namespace Hachette.API.SDK.SimpleDI.Interfaces
{
    /// <summary>
    /// Contract for Modules that can Load Services for a particular function.
    /// </summary>
    public interface IModule
    {
         void Load(IServiceCollection services);
    }
}