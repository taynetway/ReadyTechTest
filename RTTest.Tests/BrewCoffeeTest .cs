using System;
using WebApp.Models;
using Xunit;

namespace RTTest.Tests
{
    public class BrewCoffeeTest
    { 
        [Fact]
        public void CanConstructDefaultParameters()
        {
            // Arrange
            var coff1 = new BrewCoffee();
            // Act
            // Assert
            Assert.Equal("Your piping hot coffee is ready", coff1.Message);
            Assert.Equal(29, coff1.LocalTemp);
            Assert.Equal(DateTime.Now.Date, coff1.PreparedDate.Date);
        }

        [Fact]
        public void CanSetAndGetParameters()
        {
            // Arrange
            var coff2 = new BrewCoffee();
            // Act
            coff2.Message = "hello Kitty";
            coff2.LocalTemp = 30;
            var testDate = new DateTime(2021, 8, 9);
            coff2.PreparedDate = new DateTime(2021, 8, 9);
            var getMessage = coff2.Message;
            var getLocalTemp = coff2.LocalTemp;
            // Assert
            Assert.Equal("hello Kitty", coff2.Message);
            Assert.Equal(30, coff2.LocalTemp);
            Assert.Equal(testDate, coff2.PreparedDate);
            Assert.Equal(30, getLocalTemp);
            Assert.Equal("hello Kitty",getMessage);
        }

        [Fact]
        public void CanIncreaseTheCountEveryTimeConstructing()
        {
            // Arrange
            var coff3 = new BrewCoffee();
            var coff4 = new BrewCoffee();
            // Act
            // Assert
            Assert.Equal(3, coff3.ServeTime);
            Assert.Equal(4, coff4.ServeTime);
        }
    }
}
