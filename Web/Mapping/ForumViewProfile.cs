using ApplicationCore.Entities;
using AutoMapper;
using Web.Models.ViewModels.Torrents;

namespace Web.Mapping
{
    public class ForumViewProfile : Profile
    {
        public ForumViewProfile() => CreateMap<Forum, ForumView>();
    }
}
