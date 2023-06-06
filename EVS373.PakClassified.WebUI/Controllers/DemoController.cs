using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS373.PakClassified.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EVS373.PakClassified.WebUI.Controllers
{
    public class DemoController : Controller
    {
       
        public IActionResult Page1()
        {
            return View();
        }

        public IActionResult Page2()
        {
            return View();
        }

    }
}