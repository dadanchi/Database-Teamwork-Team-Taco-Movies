using Moq;
using NUnit.Framework;
using System;
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
    public class LogIn_Should
    {
        [Test]
        public void ThrowArgumentException_WhenNoSuchUserExists()
        {
            var users = new List<User>().AsQueryable();

            var dbSetMock = new Mock<DbSet<User>>();
            dbSetMock.As<IQueryable<User>>().SetupGet(x => x.Provider).Returns(users.Provider);
            dbSetMock.As<IQueryable<User>>().SetupGet(x => x.Expression).Returns(users.Expression);
            dbSetMock.As<IQueryable<User>>().SetupGet(x => x.ElementType).Returns(users.ElementType);

            var contextMock = new Mock<IMovieDbContext>();
            contextMock.SetupGet(x => x.Users).Returns(dbSetMock.Object);

            var configuratorMock = new Mock<IConfigurationProvider>();

            var sut = new AuthProvider(contextMock.Object, configuratorMock.Object);

            Assert.Throws<ArgumentException>(() => sut.LogInUser("sample", "sample"));
        }

        [Test]
        public void SetsTheCurrentUser_WhenSuccessfullyLoggedIn()
        {
            var user = new User
            {
                FirstName = "sample",
                LastName = "sample",
                Username = "sample",
                Password = "sample",
                Authorization = Authorization.NormalUser,
                Id = 1
            };

            var users = new List<User>
            {
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
            sut.LogInUser("sample", "sample");

            Assert.AreEqual("sample", configuratorMock.Object.CurrentUser);
        }
    }
}