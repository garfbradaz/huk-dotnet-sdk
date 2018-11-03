using System;
using Hachette.API.SDK.Common;
using Hachette.API.SDK.Core;
using Hachette.API.SDK.Core.Constant;
using Xunit;

namespace Tests.SDK.Core
{
    public class BaseClientTests
    {
        [Fact]
        public void Should_Setup_Test_Endpoint()
        {
            //arrange
            Environment.SetEnvironmentVariable("hukRestClientEndpointType","test",EnvironmentVariableTarget.Process);
            var security = new Security();
            security.DeveloperKey = "e3ygONq5WtK9dWXWFGAGWgjTNZkWzCa4";

            //act
            var client = new BaseClient(security);

            //assert
            Assert.True(client.Endpoint.CurrentVersion ==  Constants.CurrentVersion,
                        $"Assert failed, expected {client.Endpoint.CurrentVersion}, received {Constants.CurrentVersion}");
            Assert.True(client.Endpoint.BaseUrl ==  Constants.BaseTestURL,
                        $"Assert failed, expected {client.Endpoint.BaseUrl}, received {Constants.BaseTestURL}");
        }
    }
}