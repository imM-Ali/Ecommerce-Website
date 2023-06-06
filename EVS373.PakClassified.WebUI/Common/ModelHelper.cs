using EVS373.PakClassified.WebUI.Models;
using EVS373.UsersMgt;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS373.PakClassified.WebUI.Common
{
    public static class ModelHelper
    {
        //This method will be used to convert collection IListable object to list of SelectListItem 
        public static List<SelectListItem> ToSelectItemsList(this IEnumerable<IListable> entitiesList)
        {
            List<SelectListItem> modelsList = new List<SelectListItem>();
            foreach (var entity in entitiesList)
            {
                modelsList.Add(new SelectListItem { Text=entity.Name, Value=Convert.ToString(entity.Id) });
            }
            modelsList.TrimExcess();
            return modelsList;
        }



        #region countries
        public static CountryModel ToModel(this Country entity)
        {
            CountryModel m = new CountryModel { Id = entity.Id, Name = entity.Name };
            if (entity.Code.HasValue)
            {
                m.Code = entity.Code.Value;
            }
            return m;
        }

        public static Country ToEntity(this CountryModel model)
        {
            Country entity = new Country { Id = model.Id, Name = model.Name };
            if (model.Code!=0)
            {
                entity.Code = model.Code;
            }
            return entity;
        }

        public static List<CountryModel> ToModelList(this List<Country> entitiesList)
        {
            List<CountryModel> modelsList = new List<CountryModel>();
            foreach (var entity in entitiesList)
            {
                modelsList.Add(entity.ToModel());
            }
            return modelsList;
        }

        #endregion


        #region provinces

        public static ProvinceModel ToModel(this Province entity)
        {
            return new ProvinceModel { Id = entity.Id, Name = entity.Name, Country = entity.Country?.ToModel() };
        }


        public static Province ToEntity(this ProvinceModel model)
        {
            return new Province { Id = model.Id, Name = model.Name, Country = model.Country?.ToEntity() };
        }

        public static List<ProvinceModel> ToModelList(this List<Province> entitiesList)
        {
            List<ProvinceModel> modelsList = new List<ProvinceModel>();
            foreach (var entity in entitiesList)
            {
                modelsList.Add(entity.ToModel());
            }
            modelsList.TrimExcess();
            return modelsList;
        }
        #endregion



        #region categories

        public static AdvertizementCategoryModel ToModel(this AdvertizementCategory entity)
        {
            return new AdvertizementCategoryModel { Id = entity.Id, Name = entity.Name, Parent = entity.Parent?.ToModel() };
        }


        public static AdvertizementCategory ToEntity(this AdvertizementCategoryModel model)
        {
            return new AdvertizementCategory { Id = model.Id, Name = model.Name, Parent=model.Parent?.ToEntity() };
        }

        public static List<AdvertizementCategoryModel> ToModelList(this List<AdvertizementCategory> entitiesList)
        {
            List<AdvertizementCategoryModel> modelsList = new List<AdvertizementCategoryModel>();
            foreach (var entity in entitiesList)
            {
                modelsList.Add(entity.ToModel());
            }
            modelsList.TrimExcess();
            return modelsList;
        }
        #endregion














        public static Advertizement ToEntity(this AdvertizementModel model)
        {
            Advertizement entity = new Advertizement();
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.StartsOn = model.StartsOn;
            entity.EndsOn = model.EndsOn;
            entity.Price = model.Price;
            entity.Status = model.Status.ToEntity();
            entity.Type = model.Type.ToEntity();
            entity.Category = model.Category.ToEntity();
            entity.City = model.City.ToEntity();
            entity.PostedBy = model.PostedBy.ToEntity();
            //entity.Images
            return entity;
        }

        public static AdvertizementModel ToModel(this Advertizement entity)
        {
            AdvertizementModel model = new AdvertizementModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Description = entity.Description;
            model.StartsOn = entity.StartsOn;
            model.EndsOn = entity.EndsOn;
            model.Price = entity.Price;           
            foreach (var imgEntity in entity.Images)
            {
                model.Images.Add(Convert.ToBase64String(imgEntity.Content));
            }
            //set more properties here
            return model;
        }
        

        public static List<AdvertizementModel> ToModelList(this List<Advertizement> entitiesList)
        {
            List<AdvertizementModel> models = new List<AdvertizementModel>();
            foreach (var entity in entitiesList)
            {
                models.Add(entity.ToModel());
            }
            models.TrimExcess();
            return models;
        }

        //public static List<AdvertizementCategoryModel> ToModelList(this List<AdvertizementCategory> entitiesList)
        //{
        //    List<AdvertizementModel> models = new List<AdvertizementModel>();
        //    foreach (var entity in entitiesList)
        //    {
        //        models.Add(entity.ToModel());
        //    }
        //    models.TrimExcess();
        //    return models;
        //}



        public static AdvertizementStatus ToEntity(this AdvertizementStatusModel model)
        {
            return new AdvertizementStatus { Id = model.Id, Name = model.Name };
        }

        public static AdvertizementType ToEntity(this AdvTypeModel model)
        {
            return new AdvertizementType { Id = model.Id, Name = model.Name };
        }

        //public static AdvertizementCategory ToEntity(this AdvertizementCategoryModel model)
        //{
        //    AdvertizementCategory c = new AdvertizementCategory();
        //    c.Id = model.Id;
        //    c.Name = model.Name;
        //    c.Parent = model.Parent?.ToEntity();
        //    return c;
        //}
        


        //city
        public static City ToEntity(this CityModel model)
        {
            return new City { Id = model.Id, Name = model.Name, Province = model.Province?.ToEntity() };
        }

        public static CityModel ToModel(this City entity)
        {
            return new CityModel { Id = entity.Id, Name = entity.Name, Province = entity.Province?.ToModel() };
        }

        public static List<CityModel> ToModelList(this List<City> entitiesList)
        {
            List<CityModel> modelsList = new List<CityModel>();
            foreach (var entity in entitiesList)
            {
                modelsList.Add(entity.ToModel());
            }
            modelsList.TrimExcess();
            return modelsList;
        }

        public static User ToEntity(this UserModel model)
        {
            User entity = new User
            {
                Id = model.Id,
                Name = model.Name,
                Password = model.Password,
                BirthDate = model.BirthDate,
                ContactNumber = model.ContactNumber,
                Email = model.Email,
                LoginId = model.LoginId,
                SecurityQuestion = model.SecurityQuestion,
                SecurityAnswer = model.SecurityAnswer,
                ApiKey = model.ApiKey,
                Role = model.Role?.ToEntity()
            };
            return entity;
        }


        public static UserModel ToModel(this User entity)
        {
            UserModel model = new UserModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Password = entity.Password;
            model.BirthDate = entity.BirthDate;
            model.ContactNumber = entity.ContactNumber;
            model.Email = entity.Email;
            model.LoginId = entity.LoginId;
            model.SecurityQuestion = entity.SecurityQuestion;
            model.SecurityAnswer = entity.SecurityAnswer;
            model.ApiKey = entity.ApiKey;
            model.Role = entity.Role?.ToModel();
            return model;
        }



        public static RoleModel ToModel(this Role entity)
        {
            RoleModel model = new RoleModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
            return model;
        }

        public static Role ToEntity(this RoleModel model)
        {
            Role entity = new Role
            {
                Id = model.Id,
                Name = model.Name
            };
            return entity;
        }



    }
}
