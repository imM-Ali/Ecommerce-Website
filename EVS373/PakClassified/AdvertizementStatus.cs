using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVS373.PakClassified
{
    public class AdvertizementStatus : IListable
    {
        public int Id { get; set;}

        [Required]         
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
    }
}
