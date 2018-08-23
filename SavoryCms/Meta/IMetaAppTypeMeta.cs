using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Repository.Entity;

namespace SavoryCms.Meta
{
    public interface IMetaAppTypeMeta
    {
        /// <summary>
        /// 获取元数据列表
        /// </summary>
        /// <returns>元数据列表</returns>
        List<MetaAppTypeEntity> GetEntityList();

        /// <summary>
        /// 刷新缓存
        /// </summary>
        void Refresh();
    }
}
