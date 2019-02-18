﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WissenMVC.Model;
using WissenMVC.Service.Services;

namespace WissenMVC.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var categories = categoryService.GetAll();
            return View(categories);
        }

        public ActionResult Create()
        {
            var category = new Category();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryService.Insert(category);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var category = categoryService.Find(id);

            if(category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var model = categoryService.Find(category.Id);
                model.Name = category.Name;
                model.Descripton = category.Descripton;
                categoryService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

       
        public ActionResult Delete(int id)
        {
            categoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}