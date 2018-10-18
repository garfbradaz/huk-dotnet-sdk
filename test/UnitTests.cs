using System.Net.Http;
using System.Threading.Tasks;
using Hachette.API.SDK.UnitTests.Fixtures;
using Xunit;

namespace SDK.Tests
{
    public interface IHachetteSecurity
    {
        string DeveloperKey {get;}
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

        [Fact]
        public void Should_Return_DevKey()
        {
            //arrange
            string id = "xqbfsunnuhgfcizmovtlgpqanrnnzbwl";
            //act
            //assert
            Assert.True(fixture.client.Object.Security.DeveloperKey == id,$"Failed, {fixture.client.Object.Security.DeveloperKey} " +
              " does not match {id}");

        }
    }
}