using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WissenMVC.Model;
using WissenMVC.Service.Services;

namespace WissenMVC.Admin.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;
        public PostController(IPostService postService, ICategoryService categoryService)
        {
            this.postService = postService;
            this.categoryService = categoryService;
        }
        // GET: Post
        public ActionResult Index()
        {
            var posts = postService.GetAll();
            return View(posts);
        }

        public ActionResult Create()
        {
            var post = new Post();
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(),"Id","Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                postService.Insert(post);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name",post.CategoryId);
            return View();
        }

        public ActionResult Edit(int id)
        {
            var post = postService.Find(id);

            if (post == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", post.CategoryId);
            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                var model = postService.Find(post.Id);
                model.Title = post.Title;
                model.Description = post.Description;
                model.CategoryId = post.CategoryId;
                postService.Update(model);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", post.CategoryId);
            return View();
        }

        public ActionResult Delete(int id)
        {
            postService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}