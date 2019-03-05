using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Weather.Controllers;
using Weather.Models;
using Weather.Models.Repository;
using Xunit;

namespace UnitTestApi
{
    public class UnitTest1
    {
        UserController _controller;
        IDataRepository<User> _dbContext;
        public UnitTest1()
        {
            _dbContext = new UserTest();
            _controller = new UserController(_dbContext);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get() as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<User>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
    }
}
