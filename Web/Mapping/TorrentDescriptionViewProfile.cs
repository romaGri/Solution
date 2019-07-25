using ApplicationCore.Entities;
using AutoMapper;
using TorrentsWebApp.HtmlHelpers;
using Web.Models.ViewModels.Torrents;

namespace Web.Mapping
{
    public class TorrentDescriptionViewProfile : Profile
    {
        public TorrentDescriptionViewProfile()
        {
            CreateMap<Torrent, TorrentDescriptionView>().ForMember(dist => dist.Content, opt => opt.MapFrom(x => BBCodeToHTMLConverter.Format(x.Content)));
        }
    }
}
