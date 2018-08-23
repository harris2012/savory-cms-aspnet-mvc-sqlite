using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Repository;
using SavoryCms.Repository.Entity;

namespace SavoryCms.Meta
{
    public class MetaRepositoryTypeMeta : IMetaRepositoryTypeMeta
    {
        IMetaRepositoryTypeRepository metaRepositoryTypeRepository;

        public MetaRepositoryTypeMeta(IMetaRepositoryTypeRepository metaRepositoryTypeRepository)
        {
            this.metaRepositoryTypeRepository = metaRepositoryTypeRepository;
        }

        public List<MetaRepositoryTypeEntity> GetEntityList()
        {
            return metaRepositoryTypeRepository.GetEntityList();
        }

        public void Refresh()
        {
            //throw new NotImplementedException();
        }
    }
}
