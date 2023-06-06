using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS373.PakClassified.WebUI.Models
{
    public class LoginModel
    {
        public string LoginId { get; set; }

        public string Password { get; set; }

        public bool Remember { get; set; }

    }
}
