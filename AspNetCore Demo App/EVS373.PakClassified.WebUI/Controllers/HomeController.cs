using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS373.PakClassified.WebUI.Common;
using EVS373.PakClassified.WebUI.Models;
using EVS373.UsersMgt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceStack;

namespace EVS373.PakClassified.WebUI.Controllers
{
    public class HomeController : SecureController
    {
        //home page for administrators
        [HttpGet]
        public IActionResult Admin()
        {
            if (!IsAdmin) return Redirect("/users/login");
            return View();
        }

        //home page for other users
        [HttpGet]
        public IActionResult Index(int id)
        {
            if (Constants.CURRENT_USER == null)
            {
                return Redirect("/users/login");
            }
            else
            {
                if ( !new AdvertizementsHandler().GetAdvertizements().IsEmpty())
                {
                    ViewData["LatestApprovedAds"] = new AdvertizementsHandler().GetLatestAdvertizements(20, new AdvertizementStatus { Id = 2 });
                    ViewData["Categories"] = new AdvertizementsHandler().GetTopCategories();
                    ViewData["SubCategories"] = new AdvertizementsHandler().GetSubCategories();
                }
                else
                {
                    ViewData["LatestApprovedAds"] = "Not found";
                }

               
                return View();
            }
        }
        
        public IActionResult Nav(string name, string cname)
        {
            if (Constants.CURRENT_USER == null)
            {
                return Redirect("/users/login");
            }
            else
            {
                //ViewData["LatestApprovedAds"]
                List<Advertizement> mobiles = new List<Advertizement>();
                List<Advertizement> mobilesonsub = new List<Advertizement>();
                List<Advertizement> list = new AdvertizementsHandler().GetLatestAdvertizements(100, new AdvertizementStatus { Id = 2 });
                foreach(var item in list)
                {
                    if (item.Category.Parent.Name == cname)
                    {
                        mobiles.Add(item);
                    }
                   
                }
                foreach (var item in list)
                {
                    if (item.Category.Name == name)
                    {
                        mobilesonsub.Add(item);
                    }

                }


                ViewData["Parent"] = cname;
                if (!mobilesonsub.IsEmpty())
                {
                    ViewData["Child"] = mobilesonsub[0].Category.Name;
                }
                
                if(name == null && cname == null)
                {
                    ViewData["list"] = list.ToModelList();
                }
                else if (name == null)
                {
                    ViewData["list"] = mobiles.ToModelList();
                }
                else 
                {
                    ViewData["list"] = mobilesonsub.ToModelList();
                }
                
                
                ViewData["Categories"] = new AdvertizementsHandler().GetTopCategories();
                ViewData["SubCategories"] = new AdvertizementsHandler().GetSubCategories();
                return View("Nav");
            }
        }
        
       
        




        public IActionResult CitiesDDL(int id)
        {
            DDListModel model = new DDListModel();
            model.Icon = "fa fa-map-marker";
            model.Name = "citiesddl";
            List<SelectListItem> items = new List<SelectListItem>() { new SelectListItem { Text = "- City -", Value = "0" } };
            items.AddRange(new LocationsHandler().GetCities(new Country { Id = id }).ToSelectItemsList());
            model.Items = items;
            return PartialView("~/views/shared/_DDListView.cshtml", model);
        }

        public IActionResult SubCategoriesDDL(int id)
        {
            DDListModel model = new DDListModel();
            model.Icon = "fa fa-tags";
            model.Name = "subcategoriesddl";
            List<SelectListItem> items = new List<SelectListItem>() { new SelectListItem { Text = "- Sub Category -", Value = "0" } };
            items.AddRange(new AdvertizementsHandler().GetSubCategories(new AdvertizementCategory { Id = id }).ToSelectItemsList());
            model.Items = items;
            return PartialView("~/views/shared/_DDListView.cshtml", model);
        }

        public IActionResult ProvincesDDL(int id)
        {
            DDListModel model = new DDListModel();
            model.Icon = "fa fa-tags";
            model.Name = "provincesddl";
            List<SelectListItem> items = new List<SelectListItem>() { new SelectListItem { Text = "- Province -", Value = "0" } };
            items.AddRange(new LocationsHandler().GetProvinces(new Country { Id = id }).ToSelectItemsList());
            model.Items = items;
            return PartialView("~/views/shared/_DDListView.cshtml", model);
        }




    }
}