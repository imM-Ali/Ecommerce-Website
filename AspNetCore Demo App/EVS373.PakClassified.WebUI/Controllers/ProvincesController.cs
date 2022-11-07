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
    public class ProvincesController : SecureController
    {

        [HttpGet]
        public IActionResult Manage()
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/provinces/manage");
            List<ProvinceModel> modelsList = new LocationsHandler().GetProvinces().ToModelList();
            return View(modelsList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/provinces/manage");
            List<SelectListItem> countries = new List<SelectListItem> { new SelectListItem { Text = "Select Country", Value = "0" } };
            countries.AddRange(new LocationsHandler().GetCountries().ToSelectItemsList());            
            ViewData["CountriesList"] = countries;
            return PartialView("~/views/provinces/_create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(ProvinceModel model)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/provinces/manage");
            Province province = new LocationsHandler().AddProvince(model.ToEntity());
            return RedirectToAction("manage");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ProvinceModel toDelete = new LocationsHandler().GetProvince(id).ToModel();
            return View(toDelete);
        }

        [HttpPost]
        public IActionResult Delete(ProvinceModel model)
        {
            Province entity = new LocationsHandler().DeleteProvince(model.Id);
            return RedirectToAction("manage");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ProvinceModel model = new LocationsHandler().GetProvince(id).ToModel();
            List<SelectListItem> countries = new List<SelectListItem> { new SelectListItem { Text = "Select Country", Value = "0" } };
            countries.AddRange(new LocationsHandler().GetCountries().ToSelectItemsList());
            ViewData["CountriesList"] = countries;
            return View(model);
            
        }

        [HttpPost]
        public IActionResult Edit(ProvinceModel model)
        {
            new LocationsHandler().UpdateProvince(model.Id, model.ToEntity());
            return RedirectToAction("manage");
        }


    }
}