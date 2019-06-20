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

        //public async Task<IActionResult> Index()
        //{
        //    int page = 1;
        //    int pageSize = 30;   // количество элементов на странице

        //    var source = db.Torrents.Take(pageSize).ToList();
        //    var count = await db.Torrents.CountAsync();
        //    PageInfo pageViewModel = new PageInfo(count, page, pageSize);
        //    TorrentViewModel viewModel = new TorrentViewModel
        //    {
        //        PageInfo = pageViewModel,
        //        torrents = source
        //    };
        //    return View("Index", viewModel);
        //}

        //public async Task<IActionResult> PageHelper(string s, int page = 1)
        //{
        //    int pageSize = 30;
        //    var query = db.Torrents.Where(p => string.IsNullOrWhiteSpace(s) || EF.Functions.Like(p.Title, $"%{s}%"));
        //    var count = await query.CountAsync();
        //    var torents = await query.Skip((page - 1) * pageSize).Take(pageSize).ToArrayAsync();
        //    PageInfo pageViewModel = new PageInfo(count, page, pageSize);
        //    TorrentViewModel viewModel = new TorrentViewModel
        //    {
        //        PageInfo = pageViewModel,
        //        torrents = torents,
        //        SearchString = s
        //    };
        //    return View(viewModel);
        //}

//Delete me please
        public async Task<IActionResult> Index(string s, int page = 1)
        {
            IQueryable<Torrent> query;
            int count;
            int pageSize = 30;   // количество элементов на странице
            if (s == null)
            {
                count = await db.Torrents.CountAsync();
                query = db.Torrents.Take(count);
            }
            else{
                query = db.Torrents.Where(p => string.IsNullOrWhiteSpace(s) || EF.Functions.Like(p.Title, $"%{s}%"));
                count = await query.CountAsync();
            }

            var torents = await query.Skip((page - 1) * pageSize).Take(pageSize).ToArrayAsync();

            PageInfo pageViewModel = new PageInfo(count, page, pageSize);
            TorrentViewModel viewModel = new TorrentViewModel
            {
                PageInfo = pageViewModel,
                torrents = torents,
                SearchString = s
            };
            var source = db.Torrents.Take(pageSize).ToList();

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
