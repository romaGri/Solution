using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Services
{
    public class TorrentsViewModelService
    {

        //private readonly IAsyncRepository<Torrent> _torrentRepository;

        //public TorrentsViewModelService(IAsyncRepository<Torrent> torrentRepository)
        //{
        //    _torrentRepository = torrentRepository;
        //}
        //public async Task<TorrentViewModel> GetTorrents(int pageIndex, int itemsPage, string searchText)
        //{
        //    var filterSpecification = new CatalogFilterSpecification(searchText);
        //    var filterPaginatedSpecification = new CatalogFilterPaginatedSpecification(itemsPage * pageIndex, itemsPage, searchText);

        //    var torrentsOnPage = await _torrentRepository.ListAsync(filterPaginatedSpecification);
        //    var totalTorrents = await _torrentRepository.CountAsync(filterSpecification);

        //    var ci = new TorrentViewModel
        //    {
        //        CatalogTorrents = torrentsOnPage.Select(x => new TorrentViewModel()
        //        {
        //            Id = x.Id,
        //            Title = x.Title,
        //            Size = x.Size,
        //            RegistredAt = x.RegistredAt
        //        }),
        //        SearchText = searchText,
        //        PaginationInfo = new PaginationInfoViewModel()
        //        {
        //            ActualPage = pageIndex,
        //            TorrentsPerPage = torrentsOnPage.Count,
        //            TotalTorrents = totalTorrents,
        //            TotalPages = int.Parse(Math.Ceiling((decimal)totalTorrents / itemsPage).ToString())
        //        }
        //    };
        //    ci.PaginationInfo.Previous = (ci.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";
        //    ci.PaginationInfo.Next = (ci.PaginationInfo.ActualPage == ci.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
        //    return ci;
        //}
    }
}
