using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryCms.Repository.Entity
{
    public class AppEntity
    {

        public int Id { get; set; }

        public int AppId { get; set; }

        public string AppEname { get; set; }

        public string AppName { get; set; }

        public int AppTypeId { get; set; }

        public int DataStatus { get; set; }

        public string Description { get; set; }
    }
}
