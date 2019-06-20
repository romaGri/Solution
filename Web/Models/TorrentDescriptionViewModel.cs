using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class TorrentDescriptionViewModel : TorrentViewModel
    {
        public string Content { get; set; }
        public string Dir { get; set; }
        public Forum Forum { get; set; }
        public IEnumerable<File> Files { get; set; }
    }
}
