using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Repository;
using SavoryCms.Repository.Entity;

namespace SavoryCms.Meta
{
    public class TheMetaAppTypeMeta : ITheMetaAppTypeMeta
    {
        ITheMetaAppTypeRepository theMetaAppTypeRepository;

        public TheMetaAppTypeMeta(ITheMetaAppTypeRepository theMetaAppTypeRepository)
        {
            this.theMetaAppTypeRepository = theMetaAppTypeRepository;
        }

        public List<TheMetaAppTypeEntity> GetEntityList()
        {
            return theMetaAppTypeRepository.GetEntityList();
        }

        public void Refresh()
        {
            //throw new NotImplementedException();
        }
    }
}
