using SavoryCms.Controllers.Request;
using SavoryCms.Repository.Entity;
using SavoryCms.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryCms.Convertor
{
    public interface IAppConvertor
    {

        /// <summary>
        /// request 转换为 entity
        /// </summary>
        AppEntity toEntity(AppCreateRequest request);

        /// <summary>
        /// request 转换为 entity
        /// </summary>
        AppEntity toEntity(AppUpdateRequest request, AppEntity oldEntity);

        /// <summary>
        /// 获取空 vo
        /// </summary>
        AppVo toEmptyVo();

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        AppVo toLessVo(AppEntity entity);

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        AppVo toMoreVo(AppEntity entity);

        /// <summary>
        /// entityList 转换为 voList
        /// </summary>
        List<AppVo> toLessVoList(List<AppEntity> entityList);
    }
}
