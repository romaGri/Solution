using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class TorrentDescriptionViewModel : TorrentViewModel
    {
        public int ForumId { get; set;}
        public IEnumerable<Torrent> Torrents { get;set; }
        public string Content { get; set; }
        public string Dir { get; set; }
        public string Forums { get; set; }
        public string Title { get;set; }
        public long Size { get; set; }
        public IEnumerable<File> Files { get; set; }
    }
}
