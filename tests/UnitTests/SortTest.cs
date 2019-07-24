using Xunit;
using Moq;
using Ifrastructure;
using Web;
using ApplicationCore.Interfaces;
using System.Collections.Generic;
using ApplicationCore.Entities;
using System;
using Web.Services;
using System.Linq;

namespace UnitTests
{
    public class SorTest
    {


        private List<Torrent> getTestList()
        {
            var torrents = new  List<Torrent>{
                new Torrent { Id = 1, TorrentId = 9351, RegistredAt = new DateTime(2002 - 06 - 22, 11, 1), Size = "345134532", Del = true },
                new Torrent { Id = 2, TorrentId = 9351, RegistredAt = new DateTime(2009 - 06 - 22, 11, 1), Size = "36573413", Del = false },
                new Torrent { Id = 3, TorrentId = 1276, RegistredAt = new DateTime(2008 - 06 - 22, 11, 1), Size = "32456234", Del = true },
                new Torrent { Id = 4, TorrentId = 9654, RegistredAt = new DateTime(2007 - 06 - 22, 11, 1), Size = "3451132", Del = false },
                new Torrent { Id = 5, TorrentId = 3451, RegistredAt = new DateTime(2006 - 06 - 22, 11, 1), Size = "3451143511", Del = true }
            };
            return torrents;
        }
            
        [Fact]
        public void Sorting_by_size()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.torrents).Returns(getTestList());

            SortService sortClass = new SortService(mock.Object)
            {
                exisTorrent = true,
                bigSizeTorrent = false
            };

            var result = sortClass.Sort(null);
            Assert.Equal("3451132", result[0].Size );
            Assert.NotEqual("3451132", result[4].Size);

        }
        [Fact]
        public void Sorting_by_exist()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.torrents).Returns(getTestList());

            SortService sortClass = new SortService(mock.Object)
            {
                exisTorrent = false,
                bigSizeTorrent = false
            };

            var result = sortClass.Sort(null);
            Assert.Equal(true, result[0].Del);

        }
    }
}

