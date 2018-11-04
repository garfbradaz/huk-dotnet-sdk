using Hachette.API.SDK.Core.Constant;
using Hachette.API.SDK.Core.DI.Factories;
using Hachette.API.SDK.Core.Endpoints;
using Xunit;

namespace Unit.SDK.DI
{
    public class EndpointFactoryTests
    {
        [Fact]
        public void Should_Create_Test_Endpoint()
        {
            //arrange
            var factory = new EndpointFactory();
            //act
            var endpoint = factory.Create("test");
            //act
            Assert.True(endpoint.GetType() == typeof(TestEndpoint)
                        ,$"Assert failed, expecting {typeof(TestEndpoint)} instead of {endpoint.GetType()}");
            Assert.True(endpoint.CurrentVersion ==  Constants.CurrentVersion,
                        $"Assert failed, expected {endpoint.CurrentVersion}, received {Constants.CurrentVersion}");
            Assert.True(endpoint.BaseUrl ==  Constants.BaseTestURL,
                        $"Assert failed, expected {endpoint.BaseUrl}, received {Constants.BaseTestURL}");
        }
        [Fact]
        public void Should_Create_Test_Endpoint_When_Type_Is_Blank()
        {
            //arrange
            var factory = new EndpointFactory();
            //act
            var endpoint = factory.Create(string.Empty);
            //act
            Assert.True(endpoint.GetType() == typeof(TestEndpoint)
                        ,$"Assert failed, expecting {typeof(TestEndpoint)} instead of {endpoint.GetType()}");
            Assert.True(endpoint.CurrentVersion ==  Constants.CurrentVersion,
                        $"Assert failed, expected {endpoint.CurrentVersion}, received {Constants.CurrentVersion}");
            Assert.True(endpoint.BaseUrl ==  Constants.BaseTestURL,
                        $"Assert failed, expected {endpoint.BaseUrl}, received {Constants.BaseTestURL}");
        }    
        [Fact]
        public void Should_Create_Production_Endpoint()
        {
            //arrange
            var factory = new EndpointFactory();
            //act
            var endpoint = factory.Create("production");
            //act
            Assert.True(endpoint.GetType() == typeof(ProductionEndpoint)
                        ,$"Assert failed, expecting {typeof(ProductionEndpoint)} instead of {endpoint.GetType()}");
            Assert.True(endpoint.CurrentVersion ==  Constants.CurrentVersion,
                        $"Assert failed, expected {endpoint.CurrentVersion}, received {Constants.CurrentVersion}");
            Assert.True(endpoint.BaseUrl ==  Constants.BaseProductionURL,
                        $"Assert failed, expected {endpoint.BaseUrl}, received {Constants.BaseProductionURL}");
        }   
    }
}