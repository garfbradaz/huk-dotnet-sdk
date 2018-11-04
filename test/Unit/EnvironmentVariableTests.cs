using System;
using Hachette.API.SDK.Core.Configuration;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Unit.SDK.DI
{
    public class EnvironmentVariableTests
    {
        [Fact]
        public void Should_Get_Test()
        {
            //arrange
            Environment.SetEnvironmentVariable("hukRestClientEndpointType","test",EnvironmentVariableTarget.Process);
            var config = new ConfigurationBuilder()
                            .AddEnvironmentVariables("hukRestClient")
                            .Build();
            //act
            var endpointConfig = config.Get<EndpointConfig>();
            //assert
            Assert.True(endpointConfig.EndpointType == "test",
                        $"Assert failed, expected test, received {endpointConfig.EndpointType}");
        }
        [Fact]
        public void Should_Get_Production()
        {
            //arrange
            Environment.SetEnvironmentVariable("hukRestClientEndpointType","production",EnvironmentVariableTarget.Process);
            var config = new ConfigurationBuilder()
                            .AddEnvironmentVariables("hukRestClient")
                            .Build();
            //act
            var endpointConfig = config.Get<EndpointConfig>();
            //assert
            Assert.True(endpointConfig.EndpointType == "production",
                        $"Assert failed, expected test, received {endpointConfig.EndpointType}");
        }
    }
}