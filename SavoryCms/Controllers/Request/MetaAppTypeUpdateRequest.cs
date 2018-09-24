using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Vo;

namespace SavoryCms.Controllers.Request
{
    public class MetaAppTypeUpdateRequest
    {

        public int Id { get; set; }

        public int? AppTypeId { get; set; }

        public string AppTypeName { get; set; }
    }
}
