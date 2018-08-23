using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Repository;
using SavoryCms.Repository.Entity;

namespace SavoryCms.Meta
{
    public class MetaAppTypeMeta : IMetaAppTypeMeta
    {
        IMetaAppTypeRepository metaAppTypeRepository;

        public MetaAppTypeMeta(IMetaAppTypeRepository metaAppTypeRepository)
        {
            this.metaAppTypeRepository = metaAppTypeRepository;
        }

        public List<MetaAppTypeEntity> GetEntityList()
        {
            return metaAppTypeRepository.GetEntityList();
        }

        public void Refresh()
        {
            //throw new NotImplementedException();
        }
    }
}
