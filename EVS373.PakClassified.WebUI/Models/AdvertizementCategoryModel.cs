using System;
using System.Collections.Generic;

namespace EVS373.PakClassified.WebUI.Models
{
    public class AdvertizementCategoryModel 
    {
        public AdvertizementCategoryModel()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Content { get; set; }

        public virtual AdvertizementCategoryModel Parent { get; set; }


    }
}
