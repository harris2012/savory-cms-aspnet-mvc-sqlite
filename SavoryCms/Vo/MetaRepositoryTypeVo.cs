using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryCms.Vo
{
    public class MetaRepositoryTypeVo
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("repositoryTypeId")]
        public int? RepositoryTypeId { get; set; }

        [JsonProperty("repositoryTypeName")]
        public string RepositoryTypeName { get; set; }
    }
}
