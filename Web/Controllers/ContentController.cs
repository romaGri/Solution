using System;
using System.Linq;
using Ifrastructure;
using Microsoft.AspNetCore.Mvc;
using TorrentsWebApp.Helpers;
using Web.Models;

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

            var forum = db.Forums.FirstOrDefault(f => f.ForumId == torrent.ForumId);

            //torrent.Content = BBCodeHelper.Format(torrent.Content);
            //torrent.Files = db.Files.Where(f => f.TorrentId == id).ToArray();
            TorrentDescriptionViewModel viewModel = new TorrentDescriptionViewModel()
            {
                ForumId = torrent.ForumId,
                Forums = forum.Value,
                Content = BBCodeHelper.Format(torrent.Content),
                Title = torrent.Title,
                Dir = torrent.Dir,
                Files = db.Files.Where(f => f.TorrentId == id).ToArray()

        };


            return View(viewModel);
        }
    }
}