using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryCms.Vo
{
    public class RepositoryVo
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("repositoryName")]
        public string RepositoryName { get; set; }

        [JsonProperty("repositoryTypeId")]
        public List<TheMetaRepositoryTypeVo> RepositoryTypeId { get; set; }

        [JsonProperty("gitlabProjectFullname")]
        public string GitlabProjectFullname { get; set; }

        [JsonProperty("dataStatus")]
        public int? DataStatus { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
