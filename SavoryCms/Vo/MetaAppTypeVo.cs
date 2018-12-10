using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryCms.Vo
{
    public class MetaAppTypeVo
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("appTypeId")]
        public int? AppTypeId { get; set; }

        [JsonProperty("appTypeName")]
        public string AppTypeName { get; set; }
    }
}
