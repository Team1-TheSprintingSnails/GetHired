using System;
using System.Data.Entity;
using GetHired.DataModels.Contracts;
using GetHired.DataModels.Repositories;
using GetHired.DomainModels;
using Moq;
using NUnit.Framework;

namespace GetHired.Tests.DataModels.Repositories.GenericRepositoryTests
{
    [TestFixture]
    public class Insert_Should
    {
        private GenericRepository<User> sut;
        private Mock<IGetHiredContext> getHiredContextMock;
        private Mock<DbSet<User>> dbSetMock;

        [SetUp]
        public void SetUp()
        {
            this.getHiredContextMock = new Mock<IGetHiredContext>();
            this.dbSetMock = new Mock<DbSet<User>>();
            this.getHiredContextMock.Setup(x => x.Set<User>()).Returns(dbSetMock.Object);
            this.sut = new GenericRepository<User>(this.getHiredContextMock.Object);
        }

        [Test]
        public void ThrowArgumentNullException_When_PassedNull()
        {
            Assert.That(() => sut.Insert(null), Throws.TypeOf<ArgumentNullException>());
        }
    }
}