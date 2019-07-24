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

        public SortService(IRepository context)
        {
            db = context;
        }

        public bool exisTorrent { get; set; }
        public bool bigSizeTorrent { get; set; }
        public List<Torrent> Sort(string s)
        {

            
            IEnumerable<Torrent> query = db.torrents;
            int count = db.torrents.Count();
            List<Torrent> listTorrents = query.Take(count).Where(t => t.Del == false).ToList();

            if (s == null && exisTorrent == true)
            {
               listTorrents = query.Take(count).Where(t => t.Del == false).ToList();
            }
            if (s == null && exisTorrent == false)
            {
                listTorrents = query.Take(count).ToList();
            }
            if (s == null && bigSizeTorrent == true && exisTorrent == true)
            {
                listTorrents = query.Take(count).OrderByDescending(i => Convert.ToInt64(i.Size)).ToList();
            }
            if (s == null && bigSizeTorrent == false && exisTorrent == true)
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
