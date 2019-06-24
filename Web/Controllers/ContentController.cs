using System;
using System.Linq;
using Ifrastructure;
using Microsoft.AspNetCore.Mvc;
using TorrentsWebApp.Helpers;

namespace TorrentsWebApp.Controllers
{
    public class ContentController : Controller
    {
        torrentsdbContext db;

        public ContentController(torrentsdbContext context)
        {
            db = context;
        }

        [Route("Content/{id:int}")]
        public IActionResult Content(int id)
        {
            var torrent = db.Torrents.FirstOrDefault(c => c.TorrentId == id);
            torrent.Content = BBCodeHelper.Format(torrent.Content);
            torrent.Files = db.Files.Where(f => f.TorrentId == id).ToArray();

            
            return View(torrent);
        }
    }
}