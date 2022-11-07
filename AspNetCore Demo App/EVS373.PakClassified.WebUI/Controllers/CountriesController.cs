using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS373.PakClassified.WebUI.Common;
using EVS373.PakClassified.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EVS373.PakClassified.WebUI.Controllers
{
    public class CountriesController : SecureController
    {

        [HttpGet]
        public IActionResult Manage()
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/countries/manage");
            List<CountryModel> modelsList = new LocationsHandler().GetCountries().ToModelList();           
            return View(modelsList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/countries/manage");
            return PartialView("~/views/countries/_create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(CountryModel model)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/countries/manage");
            Country entity  = new LocationsHandler().AddCountry(model.ToEntity());
            return RedirectToAction("manage");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/countries/manage");
            CountryModel toDelete = new LocationsHandler().GetCountry(id).ToModel();
            return PartialView("~/views/countries/_delete.cshtml", toDelete);
        }

        [HttpPost]
        public IActionResult Delete(CountryModel model)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/countries/manage");
            Country entity = new LocationsHandler().DeleteCountry(model.Id);
            return RedirectToAction("manage");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/countries/manage");
            CountryModel model = new LocationsHandler().GetCountry(id).ToModel();
            return PartialView("~/views/countries/_edit.cshtml", model);
        }

        [HttpPost]
        public IActionResult Edit(CountryModel model)
        {
            if (!IsAdmin) return Redirect("/users/login?rurl=/countries/manage");
            new LocationsHandler().UpdateCountry(model.Id, model.ToEntity());
            return RedirectToAction("manage");
        }


    }
}