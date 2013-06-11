using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Dapper;
using DapperExtensions;

using NUnit;
using NUnit.Framework;

namespace Mood.Weather.Domain.Repository.Test.csproj
{
    [TestFixture]
    public class RepositoryTests
    {

        #region SetUp / TearDown
        [SetUp]
        public void Init()
        { }

        [TearDown]
        public void Dispose()
        { }
        #endregion

        #region Tests
        [Test]
        public void RepoTestDummy()
        {
            //arrange
            int expected = 4;

            //act
            int current = 4;

            //assert
            Assert.AreEqual(expected, current);
        }
        
        #endregion


    }
}
