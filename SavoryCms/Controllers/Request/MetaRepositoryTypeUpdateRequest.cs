using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Vo;

namespace SavoryCms.Controllers.Request
{
    public class MetaRepositoryTypeUpdateRequest
    {

        public int Id { get; set; }

        public int? RepositoryTypeId { get; set; }

        public string RepositoryTypeName { get; set; }
    }
}
