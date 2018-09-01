using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Repository.Entity;

namespace SavoryCms.Repository
{
    public interface ITheMetaRepositoryTypeRepository
    {
        /// <summary>
        /// 获取所有实体
        /// </summary>
        List<TheMetaRepositoryTypeEntity> GetEntityList();

        /// <summary>
        /// 获取单个实体
        /// </summary>
        TheMetaRepositoryTypeEntity GetById(int id);
    }
}
