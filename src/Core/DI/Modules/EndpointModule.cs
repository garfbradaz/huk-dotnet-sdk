using Hachette.API.SDK.Core.Configuration;
using Hachette.API.SDK.Core.DI.Factories;
using Hachette.API.SDK.Core.DI.Interfaces;
using Hachette.API.SDK.SimpleDI.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hachette.API.SDK.Core.DI.Modules
{
    /// <summary>
    /// Module for <see cref="Endpoint" /> and dependencies 
    /// needed to load to create one.
    /// </summary>
    public class EndpointModule : Module
    {
    
        /// <summary>
        /// Load <see cref="IEndpoint"> 
        /// </summary>
        /// <param name="services"></param>
        public override void Load(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                            .AddEnvironmentVariables("hukRestClient")
                            .Build();  
            EndpointConfig endpointConfig = new EndpointConfig();
            
            if(config != null)
            {
                endpointConfig = config.Get<EndpointConfig>();
            }
            else
            {
                endpointConfig.EndpointType = "test";
            }
            
            services.AddSingleton<EndpointConfig>();            
            services.AddSingleton<IEndpoint>( endpoint => {
                    IEndpointFactory factory = new EndpointFactory();
                    return factory.Create(endpointConfig.EndpointType);
                }
            );
            services.AddTransient<IEndpointFactory,EndpointFactory>();
        }        
    }
}