using System;
using Hachette.API.SDK.Core.Constant;
using Hachette.API.SDK.Core.DI.Interfaces;
using Hachette.API.SDK.Core.Endpoints;
using Hachette.API.SDK.SimpleDI.Containers;
using Hachette.API.SDK.SimpleDI.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hachette.API.SDK.Core.DI.Factories
{
    /// <summary>
    /// Factory class to create <see cref="Endpoint" />.
    /// </summary>
    public sealed class EndpointFactory : IEndpointFactory
    {

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EndpointFactory()
        {
        }
        /// <summary>
        /// Create an <see cref="Endpoint" />
        /// </summary>
        /// <typeparam name="TEndpoint"></typeparam>
        /// <returns><see cref="Endpoint"/></returns>
        public IEndpoint Create(string endpointType)
        {
            if(string.IsNullOrEmpty(endpointType))
            {
                endpointType = "test";
            }
            var tp = new TestEndpoint(Constants.CurrentVersion,Constants.BaseTestURL);
            switch(endpointType.ToLowerInvariant())
            {
                case "production":
                    return new ProductionEndpoint(Constants.CurrentVersion,Constants.BaseProductionURL);
                case "test":
                default:
                    return tp;
            }
        }
    }
}