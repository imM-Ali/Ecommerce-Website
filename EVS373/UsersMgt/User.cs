using EVS373.PakClassified;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EVS373.UsersMgt
{

    public class User
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string ApiKey { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string LoginId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string SecurityQuestion { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string SecurityAnswer { get; set; }

        public DateTime? BirthDate { get; set; }

        [NotMapped]
        public int? Age
        {
            get
            {
                if (BirthDate.HasValue)
                {
                    return (int)(DateTime.Today.Subtract(BirthDate.Value).TotalDays / 365.25);
                }
                return null;
            }
        }

        [Column(TypeName = "varchar(15)")]
        public string ContactNumber { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [Required]
        public virtual Role Role { get; set; }

        public virtual Address Address { get; set; }

       

    }
}
