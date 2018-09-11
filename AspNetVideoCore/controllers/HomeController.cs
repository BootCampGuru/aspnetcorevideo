using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetVideoCore.Entities;
using AspNetVideoCore.Services;
using AspNetVideoCore.ViewModels;

namespace AspNetVideoCore.controllers
{
    public class HomeController : Controller
    {
        private IVideoData _videos;

        public HomeController(IVideoData videos)
        {
            _videos = videos;
        }
        public ViewResult Index()
        {
            var model = _videos.GetAll().Select(video =>
                new VideoViewModel
                {
                    Id = video.Id,
                    Title = video.Title,
                    Genre = video.Genre.ToString()
                });

            return View(model);
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(VideoEditViewModel model)
        {
            var video = new Video
            {
                Title = model.Title,
                Genre = model.Genre
            };
            _videos.Add(video);
            return RedirectToAction("Details", new { id = video.Id });
        }

        public IActionResult Details(int id)
        {

            var model = _videos.Get(id);

            if (model == null)
            {
                return RedirectToAction("Index");
            }


            return View(new VideoViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Genre = model.Genre.ToString()
            });

        }

        public ViewResult Collection()
        {
            var model = new List<Video>
            {
                new Video { Id = 1, Title = "Ranjan" },
                new Video { Id = 2, Title = "James" },
                new Video { Id = 3, Title = "Peter" }
            };
            return View(_videos.GetAll());
        }
    }
}
