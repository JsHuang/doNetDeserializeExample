using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebApplication_Json.NET
{
    public class JsonUtils
    {
        public static string Stringify(object _in)
        {
            var indented = Formatting.Indented;
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            return JsonConvert.SerializeObject(_in, indented, settings);
        }

        public static T Deserialize<T>(string _in)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            return JsonConvert.DeserializeObject<T>(_in, settings);
        }

        public static object Deserialize(string _in)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            return JsonConvert.DeserializeObject(_in, settings);
        }

        public static object PopulateObject(object instance, string source)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            JsonConvert.PopulateObject(source, instance, settings);
            return instance;
        }
    }
}