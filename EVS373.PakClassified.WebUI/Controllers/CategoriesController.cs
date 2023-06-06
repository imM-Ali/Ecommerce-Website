using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS373.PakClassified.WebUI.Common;
using EVS373.PakClassified.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using EVS373.PakClassified.WebUI;

namespace EVS373.PakClassified.WebUI.Controllers
{
    public class CategoriesController : SecureController
    {

        public IActionResult Manage()
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/categories/manage");
            List<AdvertizementCategoryModel> modelsList = new AdvertizementsHandler().GetTopCategories().ToModelList();
            return View(modelsList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/categories/manage");
            return PartialView("~/views/categories/_create.cshtml");
        }
        [HttpPost]
        public IActionResult Create(AdvertizementCategoryModel model)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/categories/manage");
            AdvertizementCategory entity = new AdvertizementsHandler().AddCategory(model.ToEntity());
            return RedirectToAction("manage");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/categories/manage");
            AdvertizementCategoryModel model = new AdvertizementsHandler().GetTopCategories(id).ToModel();
            return PartialView("~/views/categories/_edit.cshtml", model);
        }

        [HttpPost]
        public IActionResult Edit(AdvertizementCategoryModel model)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/categories/manage");
            new AdvertizementsHandler().UpdateCategory(model.ToEntity());
            return RedirectToAction("manage");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/categories/manage");
            AdvertizementCategoryModel toDelete = new AdvertizementsHandler().GetTopCategories(id).ToModel();
            return PartialView("~/views/categories/_delete.cshtml", toDelete);
        }

        [HttpPost]
        public IActionResult Delete(int id,AdvertizementCategoryModel cat)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/categories/manage");
            AdvertizementCategory entity = new AdvertizementsHandler().DeleteCategory(id);
            return RedirectToAction("manage");
        }



    }

}
