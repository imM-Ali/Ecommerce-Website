using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using EVS373.PakClassified.WebUI.Common;
using EVS373.PakClassified.WebUI.Models;
using EVS373.UsersMgt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IO;
using System.Web;
using ServiceStack;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;


namespace EVS373.PakClassified.WebUI.Controllers
{
    public class UsersController : Controller
    {




        [HttpGet]
        public IActionResult Login()
        {
            string qs = Request.Query["rurl"];
            ViewData["ReturnUrl"] = qs;

            string cookieData = HttpContext.Request.Cookies[Constants.MY_COOKIE];
            if (!string.IsNullOrWhiteSpace(cookieData))
            {
                string[] loginData = cookieData.Split(',');
                User userEntity = new UsersHandler().GetUser(loginData[0], loginData[1]);
                if (userEntity != null)
                {
                    HttpContext.Session.Set(Constants.CURRENT_USER, userEntity);

                    HttpContext.Response.Cookies.Append(Constants.MY_COOKIE, $"{userEntity.LoginId},{userEntity.Password}", new CookieOptions { Expires = DateTime.Today.AddDays(7) });


                    string returnUrl = Request.Query["rurl"];
                    if (!string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    if (userEntity.Role.Id == Constants.ADMIN_ROLE_ID)
                    {
                        return Redirect("/home/admin");
                    }
                    else
                    {
                        return Redirect("/home/index");
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            User userEntity = new UsersHandler().GetUser(model.LoginId, model.Password);
            HttpContext.Session.Set(Constants.CURRENT_USER, userEntity);
            if (userEntity != null)
            {
                if (model.Remember)
                {
                    HttpContext.Response.Cookies.Append(Constants.MY_COOKIE, $"{userEntity.LoginId},{userEntity.Password}", new CookieOptions { Expires = DateTime.Today.AddDays(7) });
                }
                string returnUrl = Request.Query["rurl"];
                if (!string.IsNullOrWhiteSpace(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                if (userEntity.Role.Id == Constants.ADMIN_ROLE_ID)
                {
                    return Redirect("/home/admin");
                }
                else
                {
                    return Redirect("/home/index");
                }
            }

            int counter = Convert.ToInt32(Request.Form["Attempts"]);
            if (++counter >= 3)
            {
                return Redirect("/users/recoverpassword");
            }
            ViewData[Constants.LOGIN_ATTEMPTS] = counter;
            return View();
        }


        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Response.Cookies.Delete(Constants.MY_COOKIE);
            return Redirect("login");

        }


        [HttpGet]

        public IActionResult SignUp()
        {
            UserModel Usermoddel = new UserModel();
            return View(Usermoddel);
        }

        [HttpPost]
        public IActionResult SignUp(UserModel user)
        {
            
            

            using (PakClassifiedContext DbModel = new PakClassifiedContext())
            {
                Role role = new Role() { Name = "others" };
                user.Role = role.ToModel();               
                User usere = user.ToEntity();
                for (int i = 0; i < Request.Form.Files.Count; i++)
                {
                    var filePhoto = Request.Form.Files[i];
                    if (filePhoto.Length > 0)
                    {
                        Image img = new Image();

                        using (MemoryStream ms = new MemoryStream())
                        {
                            filePhoto.CopyTo(ms);
                            img.Content = ms.ToArray();
                        }

                        usere.Image = img.Content;
                    }
                }
                //User currentuser = HttpContext.Session.Get<User>(Constants.CURRENT_USER);                
                //List<Role> roles = new UsersHandler().GetRoles();
                //Role role = (
                //    from r in roles
                //    where r.Name == "others"
                //    select r).FirstOrDefault();

                //user.Role = roles[1].ToModel();                

                DbModel.Users.Add(usere);                
                DbModel.SaveChanges();            


                return RedirectToAction("Login");

            }
        }

        [HttpGet]
        public IActionResult Profile(string name, string cname)
        {
            User currentuser = HttpContext.Session.Get<User>(Constants.CURRENT_USER);
            string img = Convert.ToBase64String(currentuser.Image);
            ViewData["image"] = img;
            if (currentuser.Image != null)           {

                ViewData["image"] = img;
                List<Advertizement> mobiles = new List<Advertizement>();
                List<Advertizement> mobilesonsub = new List<Advertizement>();
                List<Advertizement> list = new AdvertizementsHandler().GetLatestAdvertizements(8, new AdvertizementStatus { Id = 2 });
                foreach (var item in list)
                {
                    if (item.Category.Parent.Name == cname)
                    {
                        mobiles.Add(item);
                    }

                }
                foreach (var item in list)
                {
                    if (item.Category.Name == name)
                    {
                        mobilesonsub.Add(item);
                    }

                }


                ViewData["Parent"] = cname;
                if (!mobilesonsub.IsEmpty())
                {
                    ViewData["Child"] = mobilesonsub[0].Category.Name;
                }


                if (name == null)
                {
                    ViewData["list"] = mobiles.ToModelList();
                }
                else
                {
                    ViewData["list"] = mobilesonsub.ToModelList();
                }


                ViewData["Categories"] = new AdvertizementsHandler().GetTopCategories();
                ViewData["SubCategories"] = new AdvertizementsHandler().GetSubCategories();
                return View("~/Views/Users/Profile.cshtml", currentuser.ToModel());
            }
            else
            {
                ViewData["image"] = img;
                List<Advertizement> mobiles = new List<Advertizement>();
                List<Advertizement> mobilesonsub = new List<Advertizement>();
                List<Advertizement> list = new AdvertizementsHandler().GetLatestAdvertizements(8, new AdvertizementStatus { Id = 2 });
                foreach (var item in list)
                {
                    if (item.Category.Parent.Name == cname)
                    {
                        mobiles.Add(item);
                    }

                }
                foreach (var item in list)
                {
                    if (item.Category.Name == name)
                    {
                        mobilesonsub.Add(item);
                    }

                }


                ViewData["Parent"] = cname;
                if (!mobilesonsub.IsEmpty())
                {
                    ViewData["Child"] = mobilesonsub[0].Category.Name;
                }


                if (name == null)
                {
                    ViewData["list"] = mobiles.ToModelList();
                }
                else
                {
                    ViewData["list"] = mobilesonsub.ToModelList();
                }


                ViewData["Categories"] = new AdvertizementsHandler().GetTopCategories();
                ViewData["SubCategories"] = new AdvertizementsHandler().GetSubCategories();
                return View("~/Views/Users/Profile.cshtml", currentuser.ToModel());
            }          
                
                
                
            
        }


    




        [HttpGet]
        public IActionResult edituser()
        {
            User currentuser = HttpContext.Session.Get<User>(Constants.CURRENT_USER);            
            string image = Convert.ToBase64String(currentuser.Image);
            ViewData["image"] = image;
            return View("~/Views/Users/edituser.cshtml", currentuser);
        }

        [HttpPost]
        public IActionResult edituser(UserModel use)
        {
            User user = use.ToEntity();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var filePhoto = Request.Form.Files[i];
                if (filePhoto.Length > 0)
                {
                    Image img = new Image();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        filePhoto.CopyTo(ms);
                        img.Content = ms.ToArray();
                    }

                    user.Image = img.Content;
                }
            }


            
            new UsersHandler().UpdateUser(user.Id, user);
            
            return RedirectToAction("Profile");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            
            UserModel toDelete = new UsersHandler().GetUserById(id).ToModel();
            return PartialView("~/views/users/_delete.cshtml", toDelete);
        }

        [HttpPost]
        public IActionResult Delete(UserModel model)        {
            
            User entity = new UsersHandler().DeleteUser(model.Id);
            return RedirectToAction("Login");
        }

    }
}