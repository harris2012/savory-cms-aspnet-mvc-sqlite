using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Vo;

namespace SavoryCms.Controllers.Request
{
    public class RepositoryCreateRequest
    {

        public string RepositoryName { get; set; }

        public int? RepositoryTypeId { get; set; }

        public string GitlabProjectFullname { get; set; }

        public int? DataStatus { get; set; }

        public string Description { get; set; }

    }
}
