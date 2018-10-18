using System.Threading.Tasks;
using Moq;

namespace Hachette.API.SDK.UnitTests.Fixtures
{
    public class MoqRestFixture
    {
        public Mock<IRestClient> client {get;private set;}
        private Mock<IHachetteSecurity> security;
        public MoqRestFixture()
        {
            security = new Mock<IHachetteSecurity>();
            security.Setup(s => s.DeveloperKey)
                    .Returns("xqbfsunnuhgfcizmovtlgpqanrnnzbwl");
            client = new Mock<IRestClient>();
            client.Setup( moq => moq.GetAsync())
                    .Returns(Task.FromResult(@"{ 'title':'Casual Vacancy' }"));
            client.Setup( moq => moq.Security)
                    .Returns(security.Object);
        }
    }
}