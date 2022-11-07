using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVS373.PakClassified
{
    public class AdvertizementImageModel 
    {
        public int Id { get; set; }

        public string Caption { get; set; }
        
        public string Content { get; set; }

        public int DisplayRank { get; set; }

    }
}
