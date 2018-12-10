using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryCms.Vo
{
    public class TheMetaAppTypeVo
    {
        [JsonProperty("appTypeId")]
        public int AppTypeId { get; set; }

        [JsonProperty("appTypeName")]
        public string AppTypeName { get; set; }

        [JsonProperty("selected")]
        public bool Selected { get; set; }
    }
}
