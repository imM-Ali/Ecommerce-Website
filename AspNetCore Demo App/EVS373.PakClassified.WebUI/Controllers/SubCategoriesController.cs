using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS373.PakClassified.WebUI.Common;
using EVS373.PakClassified.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using EVS373.PakClassified.WebUI;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EVS373.PakClassified.WebUI.Controllers
{
    public class SubCategoriesController : SecureController
    {

        public IActionResult Manage()
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/subcategories/manage");
            List<AdvertizementCategoryModel> modelsList = new AdvertizementsHandler().GetSubCategories().ToModelList();
            return View(modelsList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/subcategories/manage");
            List<SelectListItem> categories = new List<SelectListItem> { new SelectListItem { Text = "Select Category", Value = "0" } };
            categories.AddRange(new AdvertizementsHandler().GetTopCategories().ToSelectItemsList());
            ViewData["categories"] = categories;
            return PartialView("~/views/subcategories/_create.cshtml");
        }
        [HttpPost]
        public IActionResult Create(AdvertizementCategoryModel model)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/subcategories/manage");
            AdvertizementCategory entity = new AdvertizementsHandler().AddSubCategory(model.ToEntity());
            return RedirectToAction("manage");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/subcategories/manage");
            AdvertizementCategoryModel model = new AdvertizementsHandler().GetSubCategories(id).ToModel();
            List<SelectListItem> categories = new List<SelectListItem>();
            categories.AddRange(new AdvertizementsHandler().GetTopCategories().ToSelectItemsList());
            ViewData["categories"] = categories;
            return PartialView("~/views/subcategories/_edit.cshtml", model);
        }

        [HttpPost]
        public IActionResult Edit(AdvertizementCategoryModel model)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/subcategories/manage");
            new AdvertizementsHandler().UpdateSubCategory(model.ToEntity());
            return RedirectToAction("manage");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/subcategories/manage");
            AdvertizementCategoryModel toDelete = new AdvertizementsHandler().GetSubCategories(id).ToModel();
            return PartialView("~/views/subcategories/_delete.cshtml", toDelete);
        }

        [HttpPost]
        public IActionResult Delete(AdvertizementCategoryModel model)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/categories/manage");
            AdvertizementCategory entity = new AdvertizementsHandler().DeleteCategory(model.Id);
            return RedirectToAction("manage");
        }



    }

}
