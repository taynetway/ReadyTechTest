using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using WebApp.Controllers;
using WebApp.Models;
using WebApp.ThirdPartyAPI;
using Xunit;

namespace RTTest.Tests
{
    public class BrewsControllerTest
    { 
        [Fact]
        public async void GetCoffeeAtTempLower30()
        {
            // Arrange
            var mock = new Mock<IWeatherAPI>();
            //Set temperature at 29
            float temp = 29;
            mock.Setup(m => m.GetTemperature()).Returns(Task.FromResult(temp));
            var controller = new BrewsController(mock.Object);
            BrewCoffee.CountedTime = 4;
            //Set normal date
            controller.data.PreparedDate = new DateTime(2021, 8, 1);
            // Act
            var okData = await controller.GetCoffee() as OkObjectResult;
            BrewCoffee result = (BrewCoffee)okData.Value;
            // Assert
            Assert.Equal("Your piping hot coffee is ready", result.Message);
        }

        [Fact]
        public async void GetCoffeeAtTempOver30()
        {
            // Arrange
            var mock = new Mock<IWeatherAPI>();
            //Set temperature at 31
            float temp = 31;
            mock.Setup(m => m.GetTemperature()).Returns(Task.FromResult(temp));
            var controller = new BrewsController(mock.Object);
            BrewCoffee.CountedTime = 4;
            //Set normal date
            controller.data.PreparedDate = new DateTime(2021, 8, 1);
            // Act
            var okData = await controller.GetCoffee() as OkObjectResult;
            BrewCoffee result = (BrewCoffee)okData.Value;
            // Assert
            Assert.Equal("Your refreshing iced coffee is ready", result.Message);
        }

        [Fact]
        public async void GetCoffeeIAmTeaPot()
        {
            // Arrange
            var mock = new Mock<IWeatherAPI>();
            //Set temperature at 31
            float temp = 31;
            mock.Setup(m => m.GetTemperature()).Returns(Task.FromResult(temp));
            var controller = new BrewsController(mock.Object);
            BrewCoffee.CountedTime = 4;
            //Set date on 1st April
            controller.data.PreparedDate = new DateTime(2021, 4, 1);
            // Act
            var status = await controller.GetCoffee() as StatusCodeResult;
            // Assert
            Assert.Equal(418, status.StatusCode);
        }

        [Fact]
        public async void GetCoffeeNoServiceAfter5Times()
        {
            // Arrange
            var mock = new Mock<IWeatherAPI>();
            //Set temperature at 31
            float temp = 31;
            mock.Setup(m => m.GetTemperature()).Returns(Task.FromResult(temp));
            var controller = new BrewsController(mock.Object);
            //Set counted time is from 5 cups
            BrewCoffee.CountedTime = 5;
            //Set normal date
            controller.data.PreparedDate = new DateTime(2021, 8, 1);
            // Act
            var status = await controller.GetCoffee() as StatusCodeResult;
            // Assert
            Assert.Equal(503, status.StatusCode);
        }
    }
}
