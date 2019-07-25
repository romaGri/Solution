using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.ViewModels.Torrents;

namespace Web.Models.ViewModels.Search
{
    public class SearchAndFilterData
    {
        public IEnumerable<ForumView> Forums { get; set; }
        public long TorrentMaxSize { get; set; }
    }
}
