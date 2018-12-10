using SavoryCms.Controllers.Request;
using SavoryCms.Repository.Entity;
using SavoryCms.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryCms.Convertor
{
    public interface IMetaRepositoryTypeConvertor
    {

        /// <summary>
        /// request 转换为 entity
        /// </summary>
        MetaRepositoryTypeEntity toEntity(MetaRepositoryTypeCreateRequest request);

        /// <summary>
        /// request 转换为 entity
        /// </summary>
        MetaRepositoryTypeEntity toEntity(MetaRepositoryTypeUpdateRequest request, MetaRepositoryTypeEntity oldEntity);

        /// <summary>
        /// 获取空 vo
        /// </summary>
        MetaRepositoryTypeVo toEmptyVo();

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        MetaRepositoryTypeVo toLessVo(MetaRepositoryTypeEntity entity);

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        MetaRepositoryTypeVo toMoreVo(MetaRepositoryTypeEntity entity);

        /// <summary>
        /// entityList 转换为 voList
        /// </summary>
        List<MetaRepositoryTypeVo> toLessVoList(List<MetaRepositoryTypeEntity> entityList);
    }
}
