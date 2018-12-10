using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Repository;
using SavoryCms.Repository.Entity;

namespace SavoryCms.Meta
{
    public class TheMetaRepositoryTypeMeta : ITheMetaRepositoryTypeMeta
    {
        ITheMetaRepositoryTypeRepository theMetaRepositoryTypeRepository;

        public TheMetaRepositoryTypeMeta(ITheMetaRepositoryTypeRepository theMetaRepositoryTypeRepository)
        {
            this.theMetaRepositoryTypeRepository = theMetaRepositoryTypeRepository;
        }

        public List<TheMetaRepositoryTypeEntity> GetEntityList()
        {
            return theMetaRepositoryTypeRepository.GetEntityList();
        }

        public void Refresh()
        {
            //throw new NotImplementedException();
        }
    }
}
