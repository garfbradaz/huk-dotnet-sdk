using System;
using System.Net.Http;
using System.Threading.Tasks;
using Hachette.API.SDK.Interfaces;
using Hachette.API.SDK.UnitTests.Fixtures;
using Hachette.API.SDK.UnitTests.Models;
using Xunit;

namespace SDK.Tests
{
    // public interface IHachetteSecurity
    // {
    //     string DeveloperKey {get;}
    // }
    // public interface IRestClient 
    // {
    //     IHachetteSecurity Security {get;}
    //     Task<string> GetAsync();
    //     Task<TResponse> GetAsync<TResponse>(Uri url)  where TResponse : new();
    // }

    public class APIClientTests : IClassFixture<MoqRestFixture>
    {
        private const string devKey = "xqbfsunnuhgfcizmovtlgpqanrnnzbwl";
        IRestClient fixture;
        public APIClientTests(MoqRestFixture fixture)
        {
            this.fixture = fixture.client.Object;
        }
        static HttpClient client = new HttpClient();

        [Fact]
        public void Should_Return_DevKey()
        {
            //arrange
            string id = devKey;
            //act
            //assert
            Assert.True(fixture.Security.DeveloperKey == id,$"Failed, {fixture.Security.DeveloperKey} " +
              " does not match {id}");

        }

        [Fact]
        public async Task Should_Return_Product_With_Url()
        {
            //arrange
            Uri url = new Uri("https://localhost/products?filterByImprint=Gollancz&limit=10");
            
            //act
            var result = await fixture.GetAsync<Product>(url);

            //assert
            Assert.True(result.Isbn == "9781234567890",$"Assert failed, isbn is incorrect: {result.Isbn}");
            Assert.True(result.Title == "A Book",$"Assert failed, title is incorrect: {result.Title}");
            Assert.True(result.Author == "G J Bradley",$"Assert failed, author is incorrect: {result.Author}");
        }
    }
}