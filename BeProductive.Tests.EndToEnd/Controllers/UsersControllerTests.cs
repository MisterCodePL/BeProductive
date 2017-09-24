using BeProductive.Api;
using BeProductive.Infrastructure.Commands.Users;
using BeProductive.Infrastructure.DTO;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BeProductive.Tests.EndToEnd.Controllers
{
    [TestFixture]
    public class UsersControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UsersControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
                
        }

        [Test]
        public async Task given_valid_email_user_should_exist()
        {
            var email = "user1@gmail.com";
            var response = await _client.GetAsync($"users/{email}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(responseString);

            user.Email.ShouldBeEquivalentTo(email);
        }

        [Test]
        public async Task given_invalid_email_user_should_not_exist()
        {
            var email = "user1000@gmail.com";
            var response = await _client.GetAsync($"users/{email}");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Test]
        public async Task given_unique_email_user_should_be_created()
        {
            var request = new CreateUser
            {
                Email = "test@gmail.com",
                Password = "Secret123",
                Username = "TestAccount"
            };
            var payload = GetPayload(request);
            var response = await _client.PostAsync($"users", payload);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"users/{request.Email}");
            var user = await GetUserAsync(request.Email);
            user.Email.ShouldBeEquivalentTo(request.Email);
        }

        public async Task<UserDto> GetUserAsync(string email)
        {
            var response = await _client.GetAsync($"users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }

        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8,"application/json");
        }
    }
}
