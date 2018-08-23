using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryCms.Controllers.Request
{
    public class MetaRepositoryTypeItemsRequest : MetaRepositoryTypeCountRequest
    {
        public int PageIndex { get; set; }
    }
}
