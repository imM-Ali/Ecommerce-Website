using EVS373.UsersMgt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVS373.PakClassified
{
    public class AdvertizementsHandler
    {

        

        public List<AdvertizementCategory> GetTopCategories()
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                return (from ac in context.AdvertizementCategories
                            .Include(p => p.Parent)                            
                        where ac.Parent == null
                        select ac).ToList();
            }
        }

        public AdvertizementCategory GetTopCategories(int id)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                return (from adv in context.AdvertizementCategories                                             
                        where adv.Id == id
                        select adv).FirstOrDefault();
            }
        }

        public AdvertizementCategory GetSubCategories(int id)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                return (from adv in context.AdvertizementCategories
                        .Include(p => p.Parent)
                        where adv.Id == id
                        select adv).FirstOrDefault();
            }
        }
        public AdvertizementCategory UpdateCategory(AdvertizementCategory cat)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                AdvertizementCategory found = (from c in context.AdvertizementCategories
                                 where c.Id == cat.Id
                                 select c).FirstOrDefault();

                if (!string.IsNullOrEmpty(cat.Name))
                {
                    found.Name = cat.Name;
                }                
                context.SaveChanges();
                return found;
            }
            
        }

        public Advertizement UpdateAd(Advertizement cat)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                Advertizement found = (from c in context.Advertizements
                                               where c.Id == cat.Id
                                               select c).FirstOrDefault();

                if (!string.IsNullOrEmpty(cat.Name))
                {
                    found.Name = cat.Name;
                    found.Description = cat.Description;
                    found.Price = cat.Price;
                    
                }
                context.SaveChanges();
                return found;
            }

        }
        public AdvertizementCategory UpdateSubCategory(AdvertizementCategory cat)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                AdvertizementCategory found = (from c in context.AdvertizementCategories
                                               .Include(p => p.Parent)
                                               where c.Id == cat.Id
                                               select c).FirstOrDefault();

                if (!string.IsNullOrEmpty(cat.Name))
                {
                    found.Name = cat.Name;
                   
                }
                AdvertizementCategory country = new AdvertizementCategory();
                country.Id = cat.Parent.Id;
                AdvertizementCategory cfound = (from c in context.AdvertizementCategories
                                  where c.Id == country.Id
                                  select c).FirstOrDefault();

                found.Parent = cfound;

                                
                context.SaveChanges();
                return found;
            }

        }
       
        public AdvertizementCategory DeleteCategory(int id)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                AdvertizementCategory found = (from c in context.AdvertizementCategories
                                 where c.Id == id
                                 select c).FirstOrDefault();
                context.Remove(found);
                context.SaveChanges();
                return found;
            }
        }

        public Advertizement DeleteAd(int id)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                Advertizement found = (from c in context.Advertizements
                                               where c.Id == id
                                               select c).FirstOrDefault();
                context.Remove(found);
                context.SaveChanges();
                return found;
            }
        }
        public List<AdvertizementCategory> GetSubCategories()
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                return (from ac in context.AdvertizementCategories
                            .Include(p => p.Parent)
                        where ac.Parent != null
                        select ac).ToList();
            }
        }
        public List<AdvertizementCategory> GetSubCategories(AdvertizementCategory category)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                return (from ac in context.AdvertizementCategories
                            .Include(p => p.Parent)
                        where ac.Parent.Id == category.Id
                        select ac).ToList();
            }
        }





        public List<AdvertizementType> GetAdvTypes()
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                return (from t in context.AdvertizementTypes
                        select t).ToList();
            }
        }


        //all advertizements
        public List<Advertizement> GetAdvertizements()
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                return (from adv in context.Advertizements
                        .Include(p => p.Category.Parent)
                        .Include(p => p.City.Province.Country)
                        .Include(p => p.Images)
                        .Include(p => p.PostedBy.Role)
                        .Include(p => p.Status)
                        .Include(p => p.Type)
                        select adv).ToList();
            }
        }
        public List<Advertizement> GetAdvertizementsByCat(AdvertizementCategory category)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                return (from adv in context.Advertizements
                        .Include(p => p.Category.Parent)
                        .Include(p => p.City.Province.Country)
                        .Include(p => p.Images)
                        .Include(p => p.PostedBy.Role)
                        .Include(p => p.Status)
                        .Include(p => p.Description)
                        .Include(p => p.Price)
                        where adv.Category == category
                        select adv).ToList();
            }
        }


        public List<Advertizement> GetAdvertizementz(string name)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {



                return (from adv in context.Advertizements
                        .Include(p => p.Category.Parent)
                        .Include(p => p.City.Province.Country)
                        .Include(p => p.Images)
                        .Include(p => p.PostedBy.Role)
                        .Include(p => p.Status)
                        where adv.Name.Contains(name) || adv.Description.Contains(name) || adv.Category.Name.Contains(name) || adv.Category.Parent.Name.Contains(name)
                        select adv).ToList();





            }
        }


        //advertizement based on id (pk)
        public Advertizement GetAdvertizements(int id)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                return (from adv in context.Advertizements
                        .Include(p => p.Category.Parent)
                        .Include(p => p.City.Province.Country)
                        .Include(p => p.Images)
                        .Include(p => p.PostedBy.Role)
                        .Include(p => p.Status)
                        where adv.Id == id
                        select adv).FirstOrDefault();
            }
        }
               
        public List<Advertizement> GetLatestAdvertizements(int counter,AdvertizementStatus status)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                return (from adv in context.Advertizements
                        .Include(p => p.Category.Parent)
                        .Include(p => p.City.Province.Country)
                        .Include(p => p.Images)
                        .Include(p => p.PostedBy.Role)
                        .Include(p => p.Status)
                        .Include(p => p.Type)
                        where adv.Status.Id == status.Id
                        orderby adv.StartsOn descending
                        select adv).Take(counter).ToList();
            }
        }

        public AdvertizementCategory AddCategory(AdvertizementCategory category)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                context.Add(category);
                context.SaveChanges();
                return category;
            }
        }
        public AdvertizementCategory AddSubCategory(AdvertizementCategory category)
        {

            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                context.Entry(category.Parent).State = EntityState.Unchanged;
                context.Add(category);
                context.SaveChanges();
                return category;
            }
        }

        public void AddAdvertizement(Advertizement adv)
        {
            using (PakClassifiedContext context=new PakClassifiedContext())
            {
                context.Entry(adv.Status).State = EntityState.Unchanged;
                context.Entry(adv.Type).State = EntityState.Unchanged;
                context.Entry(adv.Category).State = EntityState.Unchanged;
                context.Entry(adv.City).State = EntityState.Unchanged;                
                context.Entry(adv.PostedBy).State = EntityState.Unchanged;

                context.Add(adv);
                context.SaveChanges();
            }
        }
    }
}