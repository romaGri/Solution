using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.Models.ViewModels;
using Web.Models.ViewModels.Search;
using Web.Models.ViewModels.Torrents;

namespace Web.Services
{
    public class CachedTorrentsViewModelService : ITorrentsViewModelService
    {
        private readonly IMemoryCache _cache;
        private readonly TorrentsViewModelService _torrentViewModelService;
        private static readonly string _torrentKeyTemplate = "torrent-{0}";
        private static readonly string _torrentsKeyTemplate = "torrents-{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}";
        private static readonly string _popularForumsKeyTemplate = "popularForums-{0}";
        private static readonly TimeSpan _defaultCacheDuration = TimeSpan.FromSeconds(30);

        public CachedTorrentsViewModelService(IMemoryCache cache, TorrentsViewModelService torrentViewModelService)
        {
            _cache = cache;
            _torrentViewModelService = torrentViewModelService;
        }

        public async Task<TorrentDescriptionView> GetTorrent(int id)
        {
            string cacheKey = String.Format(_torrentKeyTemplate, id);
            return await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.SlidingExpiration = _defaultCacheDuration;
                return await _torrentViewModelService.GetTorrent(id);
            });
        }

        public async Task<TorrentViewModel> GetTorrents(int pageIndex, int itemsPage, SearchAndFilterCriteria criteria)
        {
            string cacheKey = string.Format(_torrentsKeyTemplate, pageIndex,
                                                      itemsPage,
                                                      criteria.SearchText,
                                                      criteria.SelectedForumId,
                                                      criteria.Size.From,
                                                      criteria.Size.To,
                                                      criteria.Date.From,
                                                      criteria.Date.To);
            return await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.SlidingExpiration = _defaultCacheDuration;
                return await _torrentViewModelService.GetTorrents(pageIndex, itemsPage, criteria);
            });
        }

        public async Task<SearchAndFilterData> GetDataToFilter(int forumsCount)
        {
            string cacheKey = String.Format(_popularForumsKeyTemplate, forumsCount);
            return await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.SlidingExpiration = _defaultCacheDuration;
                return await _torrentViewModelService.GetDataToFilter(forumsCount);
            });
        }

    }
}
