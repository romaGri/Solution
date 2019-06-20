using System;
using System.Collections.Generic;
using System.Text;
using Web.Controllers;
using Ifrastructure;
using Xunit;
using Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Moq;

namespace FunctionalTests.Web.Controllers
{
    public class HomeControllersTest
    {

        private readonly HomeController _homeController;

        public HomeControllersTest() : base()
        {
            
        }

        [Fact]
        public void HomeControllerActionTestAsync()
        {
            // Arrange
            var mockRepo = new Mock<torrentsdbContext>();
            var controller = new HomeController(mockRepo.Object);

            // Act
            var result =  controller.Index("");

            // Assert
            Assert.NotNull(result);
        }
    }
}
