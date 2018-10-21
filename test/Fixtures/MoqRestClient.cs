using System;
using System.Threading.Tasks;
using Hachette.API.SDK.Interfaces;
using Hachette.API.SDK.UnitTests.Models;
using Moq;
using SDK.Tests;

namespace Hachette.API.SDK.UnitTests.Fixtures
{
    public class MoqRestFixture
    {
        public Mock<IRestClient> client {get;private set;}
        private readonly Mock<IHachetteSecurity> security;
        public MoqRestFixture()
        {
            var product = new Product(){
                Isbn = "9781234567890",
                Title = "A Book",
                Author = "G J Bradley",
                Imprint = "Gollancz",
                Division = "Orion"
            };
            security = new Mock<IHachetteSecurity>();
            security.Setup(s => s.DeveloperKey)
                    .Returns("xqbfsunnuhgfcizmovtlgpqanrnnzbwl");

            client = new Mock<IRestClient>();
            client.Setup( moq => moq.GetAsync<Product>(It.IsAny<Uri>()))
                    .Returns(Task.FromResult(product));      
            client.Setup( moq => moq.GetAsync<Product>(It.IsAny<string>(),It.IsNotNull<IHachetteCommonParameters>())) 
                    .Returns(Task.FromResult(product)); 
            client.Setup( moq => moq.Security)
                    .Returns(security.Object);
        }
    }
}