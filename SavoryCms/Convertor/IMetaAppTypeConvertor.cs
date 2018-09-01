using SavoryCms.Controllers.Request;
using SavoryCms.Repository.Entity;
using SavoryCms.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryCms.Convertor
{
    public interface IMetaAppTypeConvertor
    {

        /// <summary>
        /// request 转换为 entity
        /// </summary>
        MetaAppTypeEntity toEntity(MetaAppTypeCreateRequest request);

        /// <summary>
        /// request 转换为 entity
        /// </summary>
        MetaAppTypeEntity toEntity(MetaAppTypeUpdateRequest request);

        /// <summary>
        /// 获取空 vo
        /// </summary>
        MetaAppTypeVo toEmptyVo();

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        MetaAppTypeVo toLessVo(MetaAppTypeEntity entity);

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        MetaAppTypeVo toMoreVo(MetaAppTypeEntity entity);

        /// <summary>
        /// entityList 转换为 voList
        /// </summary>
        List<MetaAppTypeVo> toLessVoList(List<MetaAppTypeEntity> entityList);
    }
}
