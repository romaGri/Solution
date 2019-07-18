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
    public class SortController : Controller
    {
        torrentsdbContext db;
        public SortController(torrentsdbContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Sort( bool exist = true, bool bigSize = true)
        {
            IQueryable<Torrent> query = db.Torrents;
            int count = await db.Torrents.CountAsync();
            int pageSize = 30;   // количество элементов на странице



            if ( exist == true)
            {
                query = db.Torrents.Take(count).Where(t => t.Del == false).OrderByDescending(i => i.RegistredAt);
            }
            if ( exist == false)
            {
                query = db.Torrents.Take(count).OrderByDescending(i => i.RegistredAt);
            }
            if (bigSize == false)
            {
                query = db.Torrents.Take(count).OrderByDescending(i => Convert.ToInt64(i.Size));
            }
          
           
            

            return View();
        }
    }
}