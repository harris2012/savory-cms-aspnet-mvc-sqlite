using SavoryCms.Vo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryCms.Controllers.Response
{
    public class MetaAppTypeItemsResponse : BaseResponse
    {
        [JsonProperty("items")]
        public List<MetaAppTypeVo> Items { get; set; }
    }
}
