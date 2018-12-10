using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryCms.Vo
{
    public class TheMetaRepositoryTypeVo
    {
        [JsonProperty("repositoryTypeId")]
        public int RepositoryTypeId { get; set; }

        [JsonProperty("repositoryTypeName")]
        public string RepositoryTypeName { get; set; }

        [JsonProperty("selected")]
        public bool Selected { get; set; }
    }
}
