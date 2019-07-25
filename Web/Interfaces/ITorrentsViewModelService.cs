using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.ViewModels;
using Web.Models.ViewModels.Search;
using Web.Models.ViewModels.Torrents;

namespace Web.Interfaces
{
    public interface ITorrentsViewModelService
    {
        Task<TorrentViewModel> GetTorrents(int pageIndex, int itemsPage, SearchAndFilterCriteria criteria);
        Task<TorrentDescriptionView> GetTorrent(int id);
        Task<SearchAndFilterData> GetDataToFilter(int forumsCount);
    }
}
