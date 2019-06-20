using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Interfaces;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Services
{
    public class CashedTorrentsViewModel
    {
        //public class CachedCatalogService : ITorrentsView
        //{
        //    private readonly IMemoryCache _cache;
        //    private readonly TorrentsViewModelService _catalogTorrents;
        //    private static readonly string _brandsKey = "brands";
        //    private static readonly string _typesKey = "types";
        //    private static readonly string _itemsKeyTemplate = "items-{0}-{1}-{2}-{3}";
        //    private static readonly TimeSpan _defaultCacheDuration = TimeSpan.FromSeconds(30);
        //    public CachedCatalogService(IMemoryCache cache,
        //    TorrentsViewModelService catalogTorrents)
        //    {
        //        _cache = cache;
        //        _catalogTorrents = catalogTorrents;
        //    }

        //    public async Task<TorrentDescriptionViewModel> GetTorrent(int id)
        //    {
        //        string cacheKey = String.Format(_itemsKeyTemplate, id);
        //        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        //        {
        //            entry.SlidingExpiration = _defaultCacheDuration;
        //            return await _catalogTorrents.GetTorrent(id);
        //        });
        //    }

        //    public async Task<TorrentViewModel> GetTorrents(int pageIndex, int itemsPage, string selectedTitle)
        //    {
        //        string cacheKey = String.Format(_itemsKeyTemplate, pageIndex, itemsPage, selectedTitle);
        //        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
        //        {
        //            entry.SlidingExpiration = _defaultCacheDuration;
        //            return await _catalogTorrents.GetTorrents(pageIndex, itemsPage, selectedTitle);
        //        });
        //    }
        //}
    }

   
}
