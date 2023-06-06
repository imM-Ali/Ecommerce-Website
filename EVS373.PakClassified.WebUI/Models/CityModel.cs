
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EVS373.PakClassified.WebUI.Models
{
    public class CityModel 
    {
        public int Id { get; set; }

        public string Name { get; set; }
                
        public ProvinceModel Province { get; set; }
    }
}
