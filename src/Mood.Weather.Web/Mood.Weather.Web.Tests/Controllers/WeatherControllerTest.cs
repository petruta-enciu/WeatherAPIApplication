using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Mood.Weather.Web.Controllers;

namespace Mood.Weather.Web.Tests.Controllers
{
    [TestFixture]
    public class WeatherControllerTest
    {

        [Test]
        public void GetStatus()
        {
            // Arrange
            WeatherController controller = new WeatherController();
            string expected = "REST SERVICE IS UP  AND  RUNNING";
            // Act
            string result = controller.GetStatus();

            // Assert
            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void Get()
        {
            // Arrange
            WeatherController controller = new WeatherController();

            // Act
            IEnumerable<string> result = controller.Get();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(2, Is.EqualTo(result.Count()));
            Assert.That("value1", Is.EqualTo(result.ElementAt(0)));
            Assert.That("value2", Is.EqualTo(result.ElementAt(1)));
        }

        [Test]
        public void GetById()
        {
            // Arrange
            WeatherController controller = new WeatherController();

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.That("value", Is.EqualTo(result));
        }

        [Test]
        public void Post()
        {
            // Arrange
            WeatherController controller = new WeatherController();

            // Act
            controller.Post("value");

            // Assert
        }

        [Test]
        public void Put()
        {
            // Arrange
            WeatherController controller = new WeatherController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [Test]
        public void Delete()
        {
            // Arrange
            WeatherController controller = new WeatherController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
