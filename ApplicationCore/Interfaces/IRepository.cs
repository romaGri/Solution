using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IRepository
    {

        IEnumerable<Torrent> torrents { get; }
        IQueryable<Forum> forums { get; }
        IQueryable<File> files { get; }

    }
}
