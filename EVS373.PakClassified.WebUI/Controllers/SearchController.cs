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
using ServiceStack;

namespace EVS373.PakClassified.WebUI.Controllers
{
    public class SearchController : Controller
    {
        //[HttpGet]
        //public IActionResult Search()
        //{
        //    return View();
        //}
        [HttpPost]
        public IActionResult Search(string search,string name, string cname)
        {

            List<Advertizement> ads = new AdvertizementsHandler().GetAdvertizementz(search);
            string[] names = new string[100];
            string[] topcats = new string[100];
            string[] cats = new string[100];
            for (int i = 0; i < ads.Count; i++)
            {
                names[i] = ads[i].PostedBy.Name;
                topcats[i] = ads[i].Category.Parent.Name;
                cats[i] = ads[i].Category.Name;
                //User abc = new UsersHandler().GetUserById(a.PostedBy.Id);
                //x.Name = abc.Name;

            }
            List<Advertizement> mobiles = new List<Advertizement>();
            List<Advertizement> mobilesonsub = new List<Advertizement>();
            List<Advertizement> list = new AdvertizementsHandler().GetLatestAdvertizements(8, new AdvertizementStatus { Id = 2 });
            foreach (var item in list)
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


            if (name == null)
            {
                ViewData["list"] = mobiles.ToModelList();
            }
            else
            {
                ViewData["list"] = mobilesonsub.ToModelList();
            }


            ViewData["Categories"] = new AdvertizementsHandler().GetTopCategories();
            ViewData["SubCategories"] = new AdvertizementsHandler().GetSubCategories();
            ViewBag.topcats = topcats;
            ViewBag.cats = cats;
            ViewBag.postedby = names;
            ViewData["LatestApprovedAds"] = ads.ToModelList();
            ViewData["query"] = search;
            return View("search");

        }
    }
}
