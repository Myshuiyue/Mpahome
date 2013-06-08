using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mpahome.Domain.Entities;
using Mpahome.Domain.Abstract;

namespace Mpahome.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private IBlogsRepository repostiory;
        public BlogController(IBlogsRepository blogRepository) {
            this.repostiory = blogRepository;
        }

        public ViewResult List() {
            return View(repostiory.Blogs);
        }
    }
}
