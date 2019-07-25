using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.ViewModels.Torrents;

namespace Web.Models.ViewModels
{
    public class TorrentViewModel
    {
        public IEnumerable<TorrentView> Torrents { get; set; }
        public PaginationInfoViewModel PaginationInfo { get; set; }

    }
}
