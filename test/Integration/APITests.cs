using System;
using System.Threading.Tasks;
using Hachette.API.SDK;
using Hachette.API.SDK.Common;
using Xunit;

namespace Integration.SDK
{
    public class APITests
    {
        [Fact]
        public async Task Test_GetAsync()
        {
            string baseURL = "https://hachetteuk-test.apigee.net/api/v1/products";
            var security = new Security();
            security.DeveloperKey = "e3ygONq5WtK9dWXWFGAGWgjTNZkWzCa4";

            var parameters = new CommonParameters();
            parameters.Id = "9780297843320";

            RestClient client = new RestClient(security);

            var response = await client.GetAsync(baseURL,parameters);
            Assert.True(response.record.isbn13 == "9780297843320",
                        $"Assert failed, expected {parameters.Id}, received {response.record.isbn13} ");
        }

        [Fact]
        public async Task Test_GetAsyncCollection()
        {
            string baseURL = "https://hachetteuk-test.apigee.net/api/v1/products";
            var security = new Security();
            security.DeveloperKey = "e3ygONq5WtK9dWXWFGAGWgjTNZkWzCa4";

            var parameters = new CommonParameters();
            parameters.AddImprint("Gollancz");

            RestClient client = new RestClient(security);

            var response = await client.GetAsync(baseURL,parameters);
            Assert.True(response.record[0].imprint == "Gollancz",
                        $"Assert failed, expected Gollancz, received {response.record[0].imprint} ");           
        }
    }
}
