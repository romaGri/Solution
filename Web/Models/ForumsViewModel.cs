﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ForumsViewModel: TorrentViewModel
    {
        public IEnumerable<Forum> Forums { get; set; }
    }
}
