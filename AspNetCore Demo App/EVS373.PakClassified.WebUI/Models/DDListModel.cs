using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS373.PakClassified.WebUI.Models
{
    public class DDListModel
    {
        public string Name { get; set; }
        //public string Caption { get; set; }
        public string Icon { get; set; }
        public List<SelectListItem> Items { get; set; }


    }
}
