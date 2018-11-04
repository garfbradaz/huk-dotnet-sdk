using System.Threading.Tasks;
using Hachette.API.SDK;
using Hachette.API.SDK.Common;
using Hachette.API.SDK.UnitTests.Fixtures;
using Xunit;

namespace Unit.Tests.SDK
{


    public class APIClientTests : IClassFixture<MoqRestFixture>
    {
        // private const string devKey = "xqbfsunnuhgfcizmovtlgpqanrnnzbwl";
        // private const string basePath = "https://localhost/products";
        // // RestClient fixture;
        // public APIClientTests(MoqRestFixture fixture)
        // {
        //     // this.fixture = fixture.client.Object;
        // }
        // static HttpClient client = new HttpClient();

        // // [Fact]
        // // public void Should_Return_DevKey()
        // // {
        // //     //arrange
        // //     string id = devKey;
        // //     //act
        // //     //assert
        // //     Assert.True(fixture.Security.DeveloperKey == id,$"Failed, {fixture.Security.DeveloperKey} " +
        // //       " does not match {id}");

        // // }

        // // [Fact]
        // // public async Task Should_Return_Product_With_Url_With_Parameters()
        // // {
        // //     //arrange
        // //     IHachetteCommonParameters parameters = new CommonParameters();
        // //     string div = "Orion";
        // //     string imp = "Gollancz";

        // //     //act
        // //     parameters.AddDivision(div);
        // //     parameters.AddImprint(imp);
        // //     var result = await fixture.GetAsync(basePath,parameters);

        // //     //assert
        // //     Assert.True(result.Isbn == "9781234567890",$"Assert failed, isbn is incorrect: {result.Isbn}");
        // //     Assert.True(result.Title == "A Book",$"Assert failed, title is incorrect: {result.Title}");
        // //     Assert.True(result.Author == "G J Bradley",$"Assert failed, author is incorrect: {result.Author}");
        // //     Assert.True(result.Imprint == imp,$"Assert failed, imprint is incorrect: {result.Imprint}");
        // //     Assert.True(result.Division == div,$"Assert failed, imprint is incorrect: {result.Division}");
        // // }
    
        public async Task Test_GetAsync()
        {
            string baseURL = "https://hachetteuk-test.apigee.net/api/v1/products";
            var security = new Security();
            security.DeveloperKey = "e3ygONq5WtK9dWXWFGAGWgjTNZkWzCa4";

            var parameters = new CommonParameters();
            parameters.AddImprint("Gollancz");
            parameters.FilterByIsActive = true;
        
            RestClient client = new RestClient(security);

            var response = await client.GetAsync(baseURL,parameters);
            Assert.True(response.record[0].imprint == "Gollancz",
                        $"Assert failed, expected Gollancz, received {response.record.imprint} ");
        }
    }
}