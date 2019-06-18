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
        public async Task HomeControllerActionTestAsync()
        {
            // Arrange
            string result = "1";

            //Action
            
            Assert.NotNull(result);
        }
    }
}
