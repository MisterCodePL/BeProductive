using AutoMapper;
using BeProductive.Core.Domain;
using BeProductive.Core.Repositories;
using BeProductive.Infrastructure.Services;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace BeProductive.Tests.Services
{
    [TestFixture]
    class UserServiceTests
    {
        [Test]
        public async Task register_should_invoke_add_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object,mapperMock.Object);
            userService.RegisterAsync("user1@gmail.com", "user", "Secret123");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
