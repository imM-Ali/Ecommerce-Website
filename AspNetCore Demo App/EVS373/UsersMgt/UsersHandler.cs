using EVS373;
using EVS373.UsersMgt;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ServiceStack.Host;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;


namespace EVS373
{
    public class UsersHandler
    {
        public List<User> GetUsers()
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                return (from u in context.Users
                        .Include("Role")
                        .Include("Address.City.Province.Country")
                        select u).ToList();
            }
        }
        

        public User GetUser(string loginid, string password)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                return (from u in context.Users
                        .Include("Role")
                        .Include("Address.City.Province.Country")                        
                        where u.LoginId.Equals(loginid) && u.Password.Equals(password)
                        select u).FirstOrDefault();
            }
        }

        public User GetUserById(int id)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                return (from u in context.Users                        
                        where u.Id.Equals(id)
                        select u).First();


            }

        }
        public User UpdateUser(int id, User city)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                User found = (from c in context.Users                             
                              where c.Id == id
                              select c).FirstOrDefault();
                if (!string.IsNullOrEmpty(city.Name))
                {
                    found.Name = city.Name;
                    found.Email = city.Email;
                    found.ContactNumber = city.ContactNumber;
                    found.LoginId = city.LoginId;
                    found.Image = city.Image;
                }
                
                context.SaveChanges();
                return found;
            }
        }
       

        public User GetUser(string apikey)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                return (from u in context.Users
                        .Include("Role")
                        .Include("Address.City.Province.Country")
                        where u.ApiKey.Equals(apikey)
                        select u).FirstOrDefault();
            }
        }

        public  List<Role> GetRoles()
        {
            PakClassifiedContext context = new PakClassifiedContext();
            using (context)
            {
                return (from u in context.Roles
                        select u).ToList();
            }
        }

        public User DeleteUser(int id)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                User found = (from c in context.Users
                                 where c.Id == id
                                 select c).FirstOrDefault();
                context.Remove(found);
                context.SaveChanges();
                return found;
            }
        }

    }
}
