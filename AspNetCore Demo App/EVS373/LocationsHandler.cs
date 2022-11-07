using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVS373
{
    public class LocationsHandler
    {
        //countries
        public List<Country> GetCountries()
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                return (from c in context.Countries
                        select c).ToList();
            }
        }

        public Country GetCountry(int id)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                return (from c in context.Countries
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        public Country AddCountry(Country country)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                context.Add(country);
                context.SaveChanges();
                return country;
            }
        }

        public Country UpdateCountry(int id, Country country)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                Country found = (from c in context.Countries
                              where c.Id == id
                              select c).FirstOrDefault();

                if (!string.IsNullOrEmpty(country.Name))
                {
                    found.Name = country.Name;
                }
                found.Code = country.Code;
                context.SaveChanges();
                return found;
            }
        }

        public Country DeleteCountry(int id)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                Country found = (from c in context.Countries
                              where c.Id == id
                              select c).FirstOrDefault();
                context.Remove(found);
                context.SaveChanges();
                return found;
            }
        }

        //provinces
        public Province UpdateProvince(int id, Province province)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                Province found = (from c in context.Provinces
                              where c.Id == id
                              select c).FirstOrDefault();
                if (!string.IsNullOrEmpty(province.Name))
                {
                    found.Name = province.Name;
                }
                Country country = new Country();
                country.Id = province.Country.Id;
                Country cfound = (from c in context.Countries
                                  where c.Id == country.Id
                                  select c).FirstOrDefault();

                found.Country = cfound;


                context.SaveChanges();
                return found;
            }
        }
        public List<Province> GetProvinces()
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                var result = (from p in context.Provinces
                              .Include(p => p.Country)
                              select p);
                return result.ToList();
            }
        }
        public List<Province> GetProvinces(Country country)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                var result = (from p in context.Provinces
                              .Include(p => p.Country)
                              where p.Country.Id == country.Id
                              select p);
                return result.ToList();
            }
        }

        public Province GetProvince(int id)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                var result = (from p in context.Provinces
                              .Include(p => p.Country)
                              where p.Id == id
                              select p);
                return result.FirstOrDefault();
            }
        }

        public Province AddProvince(Province province)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                context.Entry(province.Country).State = EntityState.Unchanged;
                context.Add(province);
                context.SaveChanges();
                return province;
            }
        }
        public Province DeleteProvince(int id)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                Province found = (from c in context.Provinces
                                 where c.Id == id
                                 select c).FirstOrDefault();
                context.Remove(found);
                context.SaveChanges();
                return found;
            }
        }


        //cities
        public City GetCity(int id)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                return (from c in context.Cities
                             .Include(p => p.Province.Country)
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }
        public List<City> GetCities()
        {
            using (PakClassifiedContext context=new PakClassifiedContext())
            {
                return (from c in context.Cities
                             .Include(p => p.Province.Country)
                        select c).ToList();
            }
        }

        public List<City> GetCities(Country country)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                return (from c in context.Cities
                             .Include(p => p.Province.Country)
                        where c.Province.Country.Id == country.Id
                        select c).ToList();
            }
        }

        public List<City> GetCities(Province province)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                return (from c in context.Cities
                             .Include(p => p.Province.Country)
                        where c.Province.Id == province.Id
                        select c).ToList();
            }
        }

       

        public City AddCity(City city)
        {

            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                context.Entry(city.Province).State = EntityState.Unchanged;
                context.Add(city);
                context.SaveChanges();
                return city;
            }
        }

        public City UpdateCity(int id,City city)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                City found = (from c in context.Cities
                             .Include(p => p.Province.Country)
                              where c.Id == id
                              select c).FirstOrDefault();
                if (!string.IsNullOrEmpty(city.Name))
                {
                    found.Name = city.Name;
                }
                if(city.Province?.Id > 0)
                {
                    found.Province = city.Province;
                }
                context.SaveChanges();
                return found;
            }
        }

        public City DeleteCity(int id)
        {
            using (PakClassifiedContext context = new PakClassifiedContext())
            {
                City found = (from c in context.Cities
                             .Include(p => p.Province.Country)
                              where c.Id == id
                              select c).FirstOrDefault();
                context.Remove(found);
                context.SaveChanges();
                return found;
            }
        }
    }
}
