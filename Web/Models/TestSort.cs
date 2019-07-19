using ApplicationCore.Entities;
using Ifrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class TestSort
    {

        torrentsdbContext db;

        public TestSort(torrentsdbContext context)
        {
            db = context;
        }

        public bool Exist_torrent { get; set; }
        public bool BigSize_torrent { get; set; }
        public IQueryable<Torrent> Sort(string s)
        {

            IQueryable<Torrent> query = db.Torrents;
            int count = db.Torrents.Count();

            if (s == null && Exist_torrent == true)
            {
                query = db.Torrents.Take(count).Where(t => t.Del == false).OrderByDescending(i => i.RegistredAt);
            }
            if (s == null && Exist_torrent == false)
            {
                query = db.Torrents.Take(count).OrderByDescending(i => i.RegistredAt);
            }
            if (s == null && BigSize_torrent == false)
            {
                query = db.Torrents.Take(count).OrderByDescending(i => Convert.ToInt64(i.Size));
            }
            if (s == null && BigSize_torrent == true)
            {
                query = db.Torrents.Take(count).OrderBy(i => Convert.ToInt64(i.Size));
            }
            if (s != null)
            {
                query = db.Torrents.Where(p => string.IsNullOrWhiteSpace(s) || EF.Functions.Like(p.Title, $"%{s}%")).OrderByDescending(i => i.RegistredAt);
            }

            return query;
        }
    }
}
//bool exist, bool bigSize