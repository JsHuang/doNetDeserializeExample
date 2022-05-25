using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace JsonTest
{
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonClass
    {
        private string classname;
        private string name;
        private int age;
        [JsonIgnore]
        public string Classname {get => classname; set => classname =value;}
        [JsonProperty]
        public string Name { get => name;set => name = value;}
        [JsonProperty]
        public int Age { get => age; set => age = value; }
        public override string ToString()
        {
            return base.ToString();
        }
        
        public static void ClassMethod(string value)
        {
            Process.Start(value);
        }
        
    }
}
