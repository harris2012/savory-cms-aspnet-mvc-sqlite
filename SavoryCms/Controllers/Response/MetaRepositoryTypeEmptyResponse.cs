using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Vo;

namespace SavoryCms.Controllers.Response
{
    public class MetaRepositoryTypeEmptyResponse : BaseResponse
    {
        [JsonProperty("item")]
        public MetaRepositoryTypeVo Item { get; set; }
    }
}
