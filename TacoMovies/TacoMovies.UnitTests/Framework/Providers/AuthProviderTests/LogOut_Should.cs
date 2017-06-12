using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Framework.Providers;
using TacoMovies.Models;
using TacoMovies.Models.Enums;

namespace TacoMovies.UnitTests.Framework.Providers.AuthProviderTests
{
    [TestFixture]
    public class LogOut_Should
    {
        [Test]
        public void SetCurrentUsernametoEmptyString_WhenCalled()
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
            configuratorMock.SetupAllProperties();

            var sut = new AuthProvider(contextMock.Object, configuratorMock.Object);
            sut.LogOut();

            Assert.AreEqual(string.Empty, configuratorMock.Object.CurrentUser);
        }
    }
}