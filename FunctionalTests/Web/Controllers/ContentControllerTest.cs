using ApplicationCore.Entities;
using Ifrastructure;
using Ifrastructure.Abstract;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TorrentsWebApp.Controllers;
using Xunit;

namespace FunctionalTests.Web.Controllers
{
    public class ContentControllerTest
    {
        private readonly ContentController _contentController;
        public ContentControllerTest() : base()
        {
           // _contentController = new ContentController();
        }

        [Fact]
        public void GetContentBy_Id()
        {
            // Arrange
            var mockRepo = new Mock<ITorrentRepository>();
            mockRepo.Setup(s => s.Torrents).Returns(new List<Torrent>
            {
                new Torrent(torrent )
            });
            var controller = new ContentController(mockRepo);

            // Act
            var result = controller.Index("");

            // Assert
            Assert.NotNull(result);
        }
    }
}
