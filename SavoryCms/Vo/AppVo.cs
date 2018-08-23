using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryCms.Vo
{
    public class AppVo
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("appId")]
        public int AppId { get; set; }

        [JsonProperty("appEname")]
        public string AppEname { get; set; }

        [JsonProperty("appName")]
        public string AppName { get; set; }

        [JsonProperty("appTypeId")]
        public List<MetaAppTypeVo> AppTypeId { get; set; }

        [JsonProperty("dataStatus")]
        public int DataStatus { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
