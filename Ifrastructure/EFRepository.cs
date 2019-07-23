using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ifrastructure
{
    public class EFRepository : IRepository
    {

        private readonly torrentsdbContext _db;
        public EFRepository(torrentsdbContext db )
        {
            _db = db;
        }
        

        public IQueryable<Torrent> torrents { get { return _db.Torrents; } }

        public IQueryable<Forum> forums { get { return _db.Forums; } }

        public IQueryable<File> files { get { return _db.Files; } }
    }

   

}
