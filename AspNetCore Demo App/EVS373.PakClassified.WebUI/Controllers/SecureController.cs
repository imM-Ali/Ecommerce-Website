using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS373.PakClassified.WebUI.Common;
using EVS373.UsersMgt;
using Microsoft.AspNetCore.Mvc;

namespace EVS373.PakClassified.WebUI.Controllers
{
    public abstract class SecureController : Controller
    {
        public bool IsLogin
        {
            get
            {
                User currentUser = HttpContext.Session.Get<User>(Constants.CURRENT_USER);
                return (currentUser != null);
            }

        }

        public bool IsAdmin
        {
            get
            {
                User currentUser = HttpContext.Session.Get<User>(Constants.CURRENT_USER);
                return (currentUser != null && currentUser.Role.Id == Constants.ADMIN_ROLE_ID);
            }

        }
    }
}
