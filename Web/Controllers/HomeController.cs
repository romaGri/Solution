using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Ifrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {


        torrentsdbContext db;

        public HomeController(torrentsdbContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index(bool exist, bool bigSize, string s, int page = 1)
        {

            int count = await db.Torrents.CountAsync();
            int pageSize = 30;   // количество элементов на странице

            TestSort test = new TestSort(db)
            {
                exist_torrent = exist,
                bigSize_torrent = bigSize
            };

            var query = test.Sort(s);

            var torents = await query.Skip((page - 1) * pageSize).Take(pageSize).ToArrayAsync();

            PageInfo pageViewModel = new PageInfo(count, page, pageSize);
            TorrentViewModel viewModel = new TorrentViewModel
            {
                PageInfo = pageViewModel,
                torrents = torents,
                SearchString = s,
                Exist = test.exist_torrent,
                BigSize = test.bigSize_torrent
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

