using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Interfaces
{
    interface ITorrentsView
    {
        Task<TorrentViewModel> GetTorrent(int pageIndex, int itemsPage, string selectedTitle);

    }
}
