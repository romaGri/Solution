using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class TorrentViewModel
    {
        public IEnumerable<Torrent> torrents { get; set; }
        public PageInfo PageInfo { get; set; }
        public string SearchString { get; set; }
    }
}
