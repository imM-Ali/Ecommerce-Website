using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS373.PakClassified.WebUI.Common;
using EVS373.PakClassified.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EVS373.PakClassified.WebUI.Controllers
{
    public class CitiesController : SecureController
    {
        [HttpGet]
        public IActionResult Manage()
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/cities/manage");            
            List<CityModel> modelsList = new LocationsHandler().GetCities().ToModelList();
            return View(modelsList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/cities/manage");
            List<SelectListItem> provinces = new List<SelectListItem> { new SelectListItem { Text = "Select Province", Value = "0" } };
            provinces.AddRange(new LocationsHandler().GetProvinces().ToSelectItemsList());
            ViewData["ProvincesList"] = provinces;

            return PartialView("~/views/cities/_create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(CityModel model)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/cities/manage");
            City entity = new LocationsHandler().AddCity(model.ToEntity());
            return RedirectToAction("manage");
        }
    }
}
