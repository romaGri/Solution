using ApplicationCore.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.ViewModels.Torrents;

namespace Web.Mapping
{
    public class FileViewProfile : Profile
    {
        public FileViewProfile() => CreateMap<File, FileView>();
    }
}
