using EVS373.UsersMgt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVS373.PakClassified
{
    public class AdvertizementCategory : IListable
    {
        public AdvertizementCategory()
        {
        }

        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "image")]
        public byte[] Content { get; set; }

        public virtual AdvertizementCategory Parent { get; set; }


    }
}
