using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ITIDigitial.Challenge.WebApi.Test.SecurityControllerTests
{
    public class SecurityController_Get
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public SecurityController_Get()
        {
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Theory]
        [InlineData("")]
        [InlineData("aa")]
        [InlineData("ab")]
        [InlineData("AAAbbbCc")]
        [InlineData("AbTp9!foo")]
        [InlineData("AbTp9!foA")]
        [InlineData("AbTp9 fok")]
        public async Task Get_ReturnBadRequest(string password)
        {
            var response = await _client.GetAsync($"api/Security?password={password}");
            var responseString = await response.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal(bool.FalseString, responseString, true);
        }

        [Theory]
        [InlineData("AbTp9!fok")]
        public async Task Get_ReturnOk(string password)
        {
            var response = await _client.GetAsync($"api/Security?password={password}");
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(bool.TrueString, responseString, true);
        }
    }
}
