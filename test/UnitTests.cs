using System.Net.Http;
using System.Threading.Tasks;
using Hachette.API.SDK.UnitTests.Fixtures;
using Xunit;

namespace Hachette.API.SDK.UnitTests
{
    public interface IHachetteSecurity
    {
        string DeveloperKey {get;set;}
    }
    public interface IRestClient
    {
        IHachetteSecurity Security {get;}
        Task<string> GetAsync();
    }

    public class APIClientTests : IClassFixture<MoqRestFixture>
    {
        MoqRestFixture fixture;
        public APIClientTests(MoqRestFixture fixture)
        {
            this.fixture = fixture;
        }
        static HttpClient client = new HttpClient();
        [Fact]
        public async Task Should_Return_Product()
        {
            //arrange
            string product = null;

            //act
            product = await fixture.client.Object.GetAsync();
            //assert
            Assert.True(product == @"{ 'title':'Casual Vacancy' }","Failed - JSON Payload not returned");
        }
    }
}