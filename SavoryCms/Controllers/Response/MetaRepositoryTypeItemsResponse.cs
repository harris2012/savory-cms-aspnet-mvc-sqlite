using SavoryCms.Vo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryCms.Controllers.Response
{
    public class MetaRepositoryTypeItemsResponse : BaseResponse
    {
        [JsonProperty("items")]
        public List<MetaRepositoryTypeVo> Items { get; set; }
    }
}
