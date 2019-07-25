using ApplicationCore.Entities;
using AutoMapper;
using Web.Models.ViewModels.Torrents;

namespace Web.Mapping
{
    public class TorrentsViewModelProfile : Profile
    {
        public TorrentsViewModelProfile() => CreateMap<Torrent, TorrentView>();
    }
}
