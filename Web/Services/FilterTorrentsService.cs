using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services
{
    public class FilterTorrentsService
    {
        readonly IRepository db;

        public FilterTorrentsService(IRepository context, bool exisTorrent)
        {
            db = context;
            this.existTorrent = exisTorrent;
        }

        public bool existTorrent { get; set; }
        public IEnumerable<Torrent> FilterBy (string s)
        {

            IEnumerable<Torrent> query = db.torrents;
            int count = db.torrents.Count();
            List<Torrent> listTorrents = query.Take(count).Where(t => t.Del == false).ToList();

            if (existTorrent == true)
            {
                listTorrents = query.Take(count).Where(t => t.Del == false).ToList();
            }
            if (existTorrent == false)
            {
                listTorrents = query.Take(count).ToList();
            }
            return listTorrents;
        }
    }
}