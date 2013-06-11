using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

using NUnit.Framework;

using Mood.Weather.Client.Factories;
using Mood.Weather.Domain;

namespace Mood.Weather.Client.Test
{
    [TestFixture]
    public class MediaTypeFormatterTests
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
        public void TestFormatters()
        {
            //arrange
            var factory = MediaTypeFormatters.Instance;
            
            //act
            var xml = factory.Create(HttpContentTypes.ApplicationXml);
            var json = factory.Create(HttpContentTypes.ApplicationJson);

            //assert
            Assert.IsNotNull(factory);
            Assert.IsNotNull(xml);
            Assert.IsNotNull(json);            
        }

        [Test]
        public void Test_XmlFormatter()
        {
            //arrange
            var factory = MediaTypeFormatters.Instance;

            //assert
            Assert.IsNotNull(factory);

            //act
            var xml = factory.Create(HttpContentTypes.ApplicationXml);

            //assert
            Assert.IsNotNull(factory);
            Assert.IsNotNull(xml);
        }
        [Test]
        public void Test_JsonFormatter()
        {
            //arrange
            var factory = MediaTypeFormatters.Instance;

            //assert
            Assert.IsNotNull(factory);

            //act
            var json = factory.Create(HttpContentTypes.ApplicationJson);

            //assert
            Assert.IsNotNull(factory);
            Assert.IsNotNull(json);
        }
        #endregion
    }
}
