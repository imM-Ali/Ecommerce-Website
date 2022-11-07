using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace EVS373.PakClassified.WebUI.Models
{
    public class AdvertizementModel
    {
        public AdvertizementModel()
        {
            StartsOn = DateTime.Today;
            EndsOn = DateTime.Today.AddDays(30);
            Images = new List<string>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }

        public DateTime StartsOn { get; set; }

        public DateTime? EndsOn { get; set; }
        
        public List<SelectListItem> Countries { get; set; }

        public List<SelectListItem> TopLevelCategories { get; set; }

        public List<SelectListItem> Types { get; set; }




        public UserModel PostedBy { get; set; }

        public AdvertizementStatusModel Status { get; set; }

        public virtual CityModel City { get; set; }

        public AdvertizementCategoryModel Category { get; set; }

        public AdvTypeModel Type { get; set; }

        public List<string> Images { get; set; }

        

    }
}
