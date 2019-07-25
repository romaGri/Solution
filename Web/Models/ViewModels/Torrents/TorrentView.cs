using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.ViewModels.Torrents
{
    public class TorrentView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public long Size { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}
