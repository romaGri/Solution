using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.ViewModels.Torrents
{
    public class TorrentDescriptionView : TorrentView
    {
        public string Content { get; set; }
        public string DirName { get; set; }
        public ForumView Forum { get; set; }
        public IEnumerable<FileView> Files { get; set; }
    }
}
