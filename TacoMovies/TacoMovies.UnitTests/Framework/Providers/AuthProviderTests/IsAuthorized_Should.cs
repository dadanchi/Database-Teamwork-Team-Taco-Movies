using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TacoMovies.Data.Contracts;
using System.Data.Entity;
using System.Linq;
using TacoMovies.Contracts;
using TacoMovies.Framework.Providers;
using TacoMovies.Models;
using TacoMovies.Models.Enums;

namespace TacoMovies.UnitTests.Framework.Providers.AuthProviderTests
{

    [TestFixture]
    public class IsAuthorized_Should
    {
        [Test]
        public void ReturnFalse_WhenNoUserIsLoggedIn()
        {
            var contextMock = new Mock<IMovieDbContext>();
            var configuratorMock = new Mock<IConfigurationProvider>();
            configuratorMock.SetupGet(x => x.CurrentUser).Returns(string.Empty);

            var sut = new AuthProvider(contextMock.Object, configuratorMock.Object);

            Assert.IsFalse(sut.IsAuthorized());
        }

        [Test]
        public void ReturnFalse_WhenUserIsNotAnAdmin()
        {
            var user = new User
            {
                FirstName = "sample name",
                LastName = "sample name",
                Username = "sample name",
                Password = "sample name",
                Authorization = Authorization.NormalUser,
                Id = 1
            };

            var users = new List<User>
            {
                user,
                user
            }.AsQueryable();

            var dbSetMock = new Mock<DbSet<User>>();
            dbSetMock.As<IQueryable<User>>().SetupGet(x => x.Provider).Returns(users.Provider);
            dbSetMock.As<IQueryable<User>>().SetupGet(x => x.Expression).Returns(users.Expression);
            dbSetMock.As<IQueryable<User>>().SetupGet(x => x.ElementType).Returns(users.ElementType);

            var contextMock = new Mock<IMovieDbContext>();
            contextMock.SetupGet(x => x.Users).Returns(dbSetMock.Object);

            var configuratorMock = new Mock<IConfigurationProvider>();
            configuratorMock.SetupGet(x => x.CurrentUser).Returns("sample name");

            var sut = new AuthProvider(contextMock.Object, configuratorMock.Object);

            Assert.IsFalse(sut.IsAuthorized());
        }

        [Test]
        public void ReturnTrue_WhenUserIsAnAdmin()
        {
            var user = new User
            {
                FirstName = "sample name",
                LastName = "sample name",
                Username = "sample name",
                Password = "sample name",
                Authorization = Authorization.Admin,
                Id = 1
            };

            var users = new List<User>
            {
                user,
                user
            }.AsQueryable();

            var dbSetMock = new Mock<DbSet<User>>();
            dbSetMock.As<IQueryable<User>>().SetupGet(x => x.Provider).Returns(users.Provider);
            dbSetMock.As<IQueryable<User>>().SetupGet(x => x.Expression).Returns(users.Expression);
            dbSetMock.As<IQueryable<User>>().SetupGet(x => x.ElementType).Returns(users.ElementType);

            var contextMock = new Mock<IMovieDbContext>();
            contextMock.SetupGet(x => x.Users).Returns(dbSetMock.Object);

            var configuratorMock = new Mock<IConfigurationProvider>();
            configuratorMock.SetupGet(x => x.CurrentUser).Returns("sample name");

            var sut = new AuthProvider(contextMock.Object, configuratorMock.Object);

            Assert.IsTrue(sut.IsAuthorized());
        }
    }
}