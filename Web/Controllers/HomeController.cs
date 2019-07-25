using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ifrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;
using Web.Models.ViewModels;
using Web.Services;

namespace Web.Controllers
{
    public class HomeController : Controller
    {


        IRepository<T> db;

        public HomeController(IRepository<T> context)
        {
            db = context;
        }
        public async Task<IActionResult> Index(bool exist, bool bigSize, string s, int page = 1)
        {

            int count = db.torrents.Count();
            int pageSize = 30;   // количество элементов на странице


            SortService sortBySize = new SortService(db, bigSize);
            FilterTorrentsService filter = new FilterTorrentsService(db, exist);
            
            var query = sortBySize.Sort(s) ;

            

            var torents = query.Skip((page - 1) * pageSize).Take(pageSize).ToArray();

            PageInfo pageViewModel = new PageInfo(count, page, pageSize);
            TorrentViewModel viewModel = new TorrentViewModel
            {
                PageInfo = pageViewModel,
                torrents = torents,
                SearchString = s,
                Exist = filter.existTorrent,
                BigSize = sortBySize.bigSizeTorrent
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

