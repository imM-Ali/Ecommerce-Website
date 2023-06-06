using EVS373.UsersMgt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVS373
{
    public class Address
    {
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string StreetAddress { get; set; }

        [Required]
        public virtual City City { get; set; }

        public int UserId { get; set; }

        

    }
}
