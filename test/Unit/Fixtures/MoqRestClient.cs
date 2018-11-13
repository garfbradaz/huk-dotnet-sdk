using System;
using System.Threading.Tasks;
using Hachette.API.SDK.Core;
using Hachette.API.SDK.Interfaces;
using Hachette.API.SDK.UnitTests.Models;
using Moq;
using Unit.Tests.SDK;

namespace Hachette.API.SDK.UnitTests.Fixtures
{
    public class MoqRestFixture
    {
        public Mock<RestClient> client {get;private set;}
        private readonly Mock<IHachetteSecurity> security;
        public MoqRestFixture()
        {
            dynamic product = new Product(){
                Isbn = "9781234567890",
                Title = "A Book",
                Author = "G J Bradley",
                Imprint = "Gollancz",
                Division = "Orion"
            };
            security = new Mock<IHachetteSecurity>();
            security.Setup(s => s.DeveloperKey)
                    .Returns("xqbfsunnuhgfcizmovtlgpqanrnnzbwl");

            client = new Mock<RestClient>();   
            client.Setup( moq => moq.GetAsync(It.IsNotNull<IHachetteCommonParameters>(),It.IsAny<string>()))
                    .Returns(Task.FromResult(product)); 
            client.Setup( moq => moq.Security)
                    .Returns(security.Object);
        }
    }
}