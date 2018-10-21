using System;
using System.Net.Http;
using System.Threading.Tasks;
using Hachette.API.SDK.Common;
using Hachette.API.SDK.Interfaces;
using Hachette.API.SDK.UnitTests.Fixtures;
using Hachette.API.SDK.UnitTests.Models;
using Xunit;

namespace SDK.Tests
{


    public class APIClientTests : IClassFixture<MoqRestFixture>
    {
        private const string devKey = "xqbfsunnuhgfcizmovtlgpqanrnnzbwl";
        private const string basePath = "https://localhost/products";
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
            Uri url = new Uri($"{basePath}?filterByImprint=Gollancz&limit=10");
            
            //act
            var result = await fixture.GetAsync<Product>(url);

            //assert
            Assert.True(result.Isbn == "9781234567890",$"Assert failed, isbn is incorrect: {result.Isbn}");
            Assert.True(result.Title == "A Book",$"Assert failed, title is incorrect: {result.Title}");
            Assert.True(result.Author == "G J Bradley",$"Assert failed, author is incorrect: {result.Author}");
        }
        [Fact]
        public async Task Should_Return_Product_With_Url_With_Parameters()
        {
            //arrange
            Uri url = new Uri($"{basePath}?filterByImprint=Gollancz&limit=10");
            IHachetteCommonParameters parameters = new CommonParameters();
            string div = "Orion";
            string imp = "Gollancz";

            //act
            parameters.AddDivision(div);
            parameters.AddImprint(imp);
            var result = await fixture.GetAsync<Product>(url);

            //assert
            Assert.True(result.Isbn == "9781234567890",$"Assert failed, isbn is incorrect: {result.Isbn}");
            Assert.True(result.Title == "A Book",$"Assert failed, title is incorrect: {result.Title}");
            Assert.True(result.Author == "G J Bradley",$"Assert failed, author is incorrect: {result.Author}");
            Assert.True(result.Imprint == imp,$"Assert failed, imprint is incorrect: {result.Imprint}");
            Assert.True(result.Division == div,$"Assert failed, imprint is incorrect: {result.Division}");
        }
    }
}