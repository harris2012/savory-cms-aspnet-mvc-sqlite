using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Repository.Entity;

namespace SavoryCms.Repository
{
    public interface ITheMetaAppTypeRepository
    {
        /// <summary>
        /// 获取所有实体
        /// </summary>
        List<TheMetaAppTypeEntity> GetEntityList();

        /// <summary>
        /// 获取单个实体
        /// </summary>
        TheMetaAppTypeEntity GetById(int id);
    }
}
