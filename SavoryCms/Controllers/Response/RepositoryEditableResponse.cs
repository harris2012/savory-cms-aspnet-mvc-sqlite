using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Vo;

namespace SavoryCms.Controllers.Response
{
    public class RepositoryEditableResponse : BaseResponse
    {
        [JsonProperty("item")]
        public RepositoryVo Item { get; set; }
    }
}
