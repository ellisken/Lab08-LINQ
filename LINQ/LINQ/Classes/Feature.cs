using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ.Classes
{
    public class Feature
    {
        [JsonProperty("Properties")]
        public Property Properties { get; set; }
    }
}
