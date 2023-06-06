using EVS373.UsersMgt;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS373.PakClassified.WebUI.Common
{
    public static class Util
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            string jsonData = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonData);
        }

        public static T Get<T>(this ISession session, string key)
        {
            string jsonData = session.GetString(key);
            if (string.IsNullOrWhiteSpace(jsonData)) return default;
            T obj = JsonConvert.DeserializeObject<T>(jsonData);
            return obj;
        }

      
    }
}
