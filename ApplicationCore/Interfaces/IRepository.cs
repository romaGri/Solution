﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IRepository
    {

        IQueryable<Torrent> torrents { get; }
        IQueryable<Forum> forums { get; }
        IQueryable<File> files { get; }

    }
}