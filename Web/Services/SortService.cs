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
        public IEnumerable<Torrent> Sort(string s)
        {

            IEnumerable<Torrent> query = db.torrents;
            int count = db.torrents.Count();

            if (s == null && exisTorrent == true)
            {
                query = db.torrents.Take(count).Where(t => t.Del == false).OrderByDescending(i => i.RegistredAt);
            }
            if (s == null && exisTorrent == false)
            {
                query = db.torrents.Take(count).OrderByDescending(i => i.RegistredAt);
            }
            if (s == null && bigSizeTorrent == false)
            {
                query = db.torrents.Take(count).OrderByDescending(i => Convert.ToInt64(i.Size));
            }
            if (s == null && bigSizeTorrent == true)
            {
                query = db.torrents.Take(count).OrderBy(i => Convert.ToInt64(i.Size));
            }
            if (s != null)
            {
                query = db.torrents.Where(p => string.IsNullOrWhiteSpace(s) || EF.Functions.Like(p.Title, $"%{s}%")).OrderByDescending(i => i.RegistredAt);
            }

            return query;
        }
    }
}
//bool exist, bool bigSize