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
        public async Task<IActionResult> Index(string s, int page = 1, bool exist = true)
        {
            IQueryable<Torrent> query = db.Torrents;
            int count = await db.Torrents.CountAsync();
            int pageSize = 30;   // количество элементов на странице
            if (s == null && exist == true)
            {
                query = db.Torrents.Take(count).Where(t => t.Del == false).OrderByDescending(i => i.RegistredAt);
            }
            if (s == null && exist == false)
            {
                query = db.Torrents.Take(count).OrderByDescending(i => i.RegistredAt);
            }
            if (s != null)
            {
                query = db.Torrents.Where(p => string.IsNullOrWhiteSpace(s) || EF.Functions.Like(p.Title, $"%{s}%")).OrderByDescending(i => i.RegistredAt);
            }

            var torents = await query.Skip((page - 1) * pageSize).Take(pageSize).ToArrayAsync();

            PageInfo pageViewModel = new PageInfo(count, page, pageSize);
            TorrentViewModel viewModel = new TorrentViewModel
            {
                PageInfo = pageViewModel,
                torrents = torents,
                SearchString = s
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

