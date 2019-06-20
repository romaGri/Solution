using ApplicationCore.Entities;
using System.Collections.Generic;


namespace Ifrastructure.Abstract
{
    public interface ITorrentRepository
    {
        IEnumerable<Torrent> Torrents { get; }
    }
}
