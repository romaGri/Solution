using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ifrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    public class ForumsController : Controller
    {
      
        int _pageSize = 30;
        readonly IRepository db;

        public ForumsController(IRepository context)
        {
            db = context;
        }

        public IActionResult Index(int page = 1)
        {
            var count = db.forums.Count();
            var query = db.forums.Take(count);

            var forums = query.Skip((page - 1) * _pageSize).Take(_pageSize).ToArray();

            PageInfo pageViewModel = new PageInfo(count, page, _pageSize);
            ForumsViewModel viewModel = new ForumsViewModel()
            {
                PageInfo = pageViewModel,
                Forums = forums
            };
            return View(viewModel);
        }

        [Route("/Forums/{id:int}")]
        public IActionResult Torrents(int id, int page = 1)
        {
            var query = db.torrents.Where(t => t.ForumId == id).ToArray();
            var count = query.Count();
            var torents = query.Skip((page - 1) * _pageSize).Take(_pageSize).ToArray();
            PageInfo pageViewModel = new PageInfo(count, page, _pageSize);
            TorrentViewModel viewModel = new TorrentViewModel
            {
                PageInfo = pageViewModel,
                torrents = torents
            };
            return View(viewModel);
        }
    }
}
