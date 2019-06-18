using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public int TorrentId { get; set; }

    }
}
