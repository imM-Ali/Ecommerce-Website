using EVS373.UsersMgt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVS373.PakClassified
{
    public class Advertizement : IListable
    {
        public Advertizement()
        {
            Images = new List<AdvertizementImage>();
        }

        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        public float Price { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string Description { get; set; }
        
        [Required]
        public virtual User PostedBy { get; set; }

        public DateTime StartsOn { get; set; }

        public DateTime? EndsOn { get; set; }


        [Required]
        public virtual AdvertizementStatus Status { get; set; }

        [Required]
        public virtual AdvertizementType Type { get; set; }

        [Required]
        public virtual City City { get; set; }

        [Required]
        public virtual AdvertizementCategory Category { get; set; }

        public virtual ICollection<AdvertizementImage> Images { get; set; }

        






    }
}
