using Xunit;
using Moq;
using Ifrastructure;
using Web;
using ApplicationCore.Interfaces;
using System.Collections.Generic;
using ApplicationCore.Entities;
using System;
using Web.Services;

namespace UnitTests
{
    public class SorTest
    {


        [Fact]
        public void Sorting_by_exist()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.torrents).Returns(new List<Torrent>
            {
                new Torrent{Id =1 ,TorrentId = 9351, RegistredAt = new DateTime(2002-06-22 , 11 , 1 ), Size ="345134532", Del = true},
                new Torrent{Id =2 ,TorrentId = 9351, RegistredAt = new DateTime(2009-06-22 , 11 , 1 ), Size ="36573413", Del = false},
                new Torrent{Id =3 ,TorrentId = 1276, RegistredAt = new DateTime(2008-06-22 , 11 , 1 ), Size ="32456234", Del = true},
                new Torrent{Id =4 ,TorrentId = 9654, RegistredAt = new DateTime(2007-06-22 , 11 , 1 ), Size ="3451132", Del = false},
                new Torrent{Id =5 ,TorrentId = 3451, RegistredAt = new DateTime(2006-06-22 , 11 , 1 ), Size ="345114351", Del = true}
            });

            SortService sort = new SortService(mock.Object);

        }
    }
}

