using SavoryCms.Vo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryCms.Controllers.Response
{
    public class AppItemsResponse : BaseResponse
    {
        [JsonProperty("items")]
        public List<AppVo> Items { get; set; }
    }
}
