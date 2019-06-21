using ApplicationCore.Entities;
using Ifrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class ForumsController : Controller
    {
        torrentsdbContext db;
        int _pageSize = 50;
        public ForumsController(torrentsdbContext db)
        {
            this.db = db;
        }

        public IActionResult Index(int page = 1)
        {
            // IQueryable<Torrent> query;
          
          

            var count = db.Forums.Count();
            var query = db.Forums.Take(count);

            var forums = query.Skip((page - 1) * _pageSize).Take(_pageSize).ToArray();

            PageInfo pageViewModel = new PageInfo(count, page, _pageSize);
            ForumsViewModel viewModel = new ForumsViewModel()
            {
                PageInfo = pageViewModel,
                Forums = forums
            };
            return View(viewModel);
        }

        [Route("Index/{id:int}")]
        public IActionResult Torrents(int id, int page = 1)
        {
            var query = db.Torrents.Where(t => t.ForumId == id).ToArray();
            var count = query.Count();
            var torents = query.Skip((page - 1) * _pageSize).Take(_pageSize).ToArray();
            PageInfo pageViewModel = new PageInfo(count, page, _pageSize);
            TorrentViewModel viewModel = new TorrentViewModel
            {
                PageInfo = pageViewModel,
                torrents = torents,
            };
            return View("/Views/Home/Index.cshtml", viewModel);
        }
    }
}
