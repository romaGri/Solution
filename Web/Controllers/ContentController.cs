using System;
using System.Linq;
using ApplicationCore.Interfaces;
using Ifrastructure;
using Microsoft.AspNetCore.Mvc;
using TorrentsWebApp.HtmlHelpers;
using Web.Models.ViewModels;

namespace TorrentsWebApp.Controllers
{
    public class ContentController : Controller
    {
        IRepository db;

        public ContentController(IRepository context)
        {
            db = context;
        }

        [Route("Content/{id:int}")]
        public IActionResult Content(int id)
        {
            var torrent = db.torrents.FirstOrDefault(c => c.TorrentId == id);
            var forum = db.forums.FirstOrDefault(f => f.ForumId == torrent.ForumId);
            var size = long.Parse(torrent.Size) / 1048576;

            TorrentDescriptionViewModel viewModel = new TorrentDescriptionViewModel()
            {
                ForumId = torrent.ForumId,
                Forums = forum.Value,
                Content = BBCodeToHTMLConverter.Format(torrent.Content),
                Title = torrent.Title,
                Dir = torrent.Dir,
                Size = size,
                Files = db.files.Where(f => f.TorrentId == id).ToArray()
        };


            return View(viewModel);
        }
    }
}