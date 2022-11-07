using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Threading.Tasks;
using EVS373.PakClassified.WebUI.Common;
using EVS373.PakClassified.WebUI.Models;
using EVS373.UsersMgt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EVS373.PakClassified.WebUI.Controllers
{
    public class AdvertizementsController : SecureController
    {
        [HttpGet]
        public IActionResult PostAdv()
        {

            AdvertizementModel model = new AdvertizementModel();

            List<SelectListItem> countries = new List<SelectListItem> { new SelectListItem { Value="0", Text="- Country -" } };
            countries.AddRange(new LocationsHandler().GetCountries().ToSelectItemsList());
            model.Countries = countries;

            List<SelectListItem> topLevelCategories = new List<SelectListItem> { new SelectListItem { Value = "0", Text = "- Category -" } };
            topLevelCategories.AddRange(new AdvertizementsHandler().GetTopCategories().ToSelectItemsList());
            model.TopLevelCategories =topLevelCategories;

            model.Types = new AdvertizementsHandler().GetAdvTypes().ToSelectItemsList();

            return PartialView("~/views/advertizements/_postadv.cshtml",model);
        }



        [HttpPost]
        public IActionResult PostAdv(AdvertizementModel model)
        {

            //IFormFile file = Request.Form.Files["photo1"];
            //if (file.Length > 100)
            //{
            //    using (MemoryStream ms = new MemoryStream())
            //    {
            //        file.CopyTo(ms);
            //        byte[] imageData = ms.ToArray();
            //    }
            //}
            model.City = new CityModel { Id = Convert.ToInt32(Request.Form["citiesddl"]) };
            model.Category = new AdvertizementCategoryModel { Id = Convert.ToInt32(Request.Form["subcategoriesddl"]) };
            model.Type = new AdvTypeModel { Id = Convert.ToInt32(Request.Form["advtype"]) };
            model.Status = new AdvertizementStatusModel { Id = 2 }; //new add will be saved in pending status
            //User currentuser = HttpContext.Session.Get<User>(Constants.CURRENT_USER);
            //User me = new UsersHandler().GetUser(currentuser.LoginId, currentuser.Password);
            model.PostedBy = HttpContext.Session.Get<User>(Common.Constants.CURRENT_USER).ToModel();            
            Advertizement adv = model.ToEntity();
            for(int i=0;i<Request.Form.Files.Count;i++)
            {
                var filePhoto = Request.Form.Files[i];
                if (filePhoto.Length > 0)
                {
                    AdvertizementImage img = new AdvertizementImage();
                    img.DisplayRank = i + 1;
                    img.Caption = Request.Form["phcaption" + (i + 1)];
                    using (MemoryStream ms = new MemoryStream())
                    {
                        filePhoto.CopyTo(ms);
                        img.Content = ms.ToArray();
                    }
                    adv.Images.Add(img);
                }                
            }
            new AdvertizementsHandler().AddAdvertizement(adv);
            return RedirectToAction("index", "home");
        }


        public IActionResult Details(int id)
        {
            Advertizement ad = new AdvertizementsHandler().GetAdvertizements(id);
            string postedby = ad.PostedBy.Name;
            ViewBag.postedby = postedby;
            List<Advertizement> select = new List<Advertizement>();
            List<Advertizement> list = new AdvertizementsHandler().GetLatestAdvertizements(8, new AdvertizementStatus { Id = 2 });
            foreach (var item in list)
            {
                if (item.Category.Parent.Name == ad.Category.Parent.Name)
                {
                    select.Add(item);
                    if(item.Id == ad.Id)
                    {
                        select.Remove(item);
                    }
                }

            }
            
            ViewData["list"] = select.ToModelList();
            string img = Convert.ToBase64String(HttpContext.Session.Get<User>(Common.Constants.CURRENT_USER).Image);
            if (HttpContext.Session.Get<User>(Common.Constants.CURRENT_USER) != null)
            {
                ViewData["img"] = img;
            }
            
            ViewData["currentuser"] = HttpContext.Session.Get<User>(Common.Constants.CURRENT_USER).ToModel();
            return View(ad.ToModel());
        }

        public IActionResult Manage()
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/Advertizements/manage");
            List<Advertizement> modelsList = new AdvertizementsHandler().GetAdvertizements();
            ViewData["adsentity"] = modelsList;
            return View(modelsList.ToModelList());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/adevrtizements/manage");
            AdvertizementModel model = new AdvertizementsHandler().GetAdvertizements(id).ToModel();
            return PartialView("~/views/advertizements/_edit.cshtml", model);
        }

        [HttpPost]
        public IActionResult Edit(Advertizement model)
        {
           
            if (!IsAdmin) return Redirect("/users/login?rurl=/adverzements/manage");
            new AdvertizementsHandler().UpdateAd(model);
            return RedirectToAction("manage");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/advertizements/manage");
            AdvertizementModel toDelete = new AdvertizementsHandler().GetAdvertizements(id).ToModel();
            return PartialView("~/views/advertizements/_delete.cshtml", toDelete);
        }

        [HttpPost]
        public IActionResult Delete(int id, AdvertizementModel cat)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/advertizements/manage");
            Advertizement entity = new AdvertizementsHandler().DeleteAd(id);
            return RedirectToAction("manage");
        }


    }
}