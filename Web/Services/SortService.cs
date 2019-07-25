using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ifrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services
{
    public class SortService
    {

        IRepository db;

        public SortService(IRepository context , bool bigSizeTorrent)
        {
            db = context;
            this.bigSizeTorrent = bigSizeTorrent; 
        }

        public bool bigSizeTorrent { get; set; }
        public IEnumerable<Torrent> Sort(string s)
        {
            IEnumerable<Torrent> query = db.torrents;
            int count = db.torrents.Count();
            List<Torrent> listTorrents = query.Take(count).Where(t => t.Del == false).ToList();

            if (s == null && bigSizeTorrent == true)
            {
                listTorrents = query.Take(count).OrderByDescending(i => Convert.ToInt64(i.Size)).ToList();
            }
            if (s == null && bigSizeTorrent == false)
            {
                listTorrents = query.Take(count).OrderBy(i => Convert.ToInt64(i.Size)).ToList();
            }
            if (s != null)
            {
                listTorrents = query.Where(p => string.IsNullOrWhiteSpace(s) || EF.Functions.Like(p.Title, $"%{s}%")).ToList();
            }

            return listTorrents;
        }
    }
}
