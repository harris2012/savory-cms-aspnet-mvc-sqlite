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
        /// 转换为 entity
        /// </summary>
        /// <param name="vo">需要转换的 vo</param>
        /// <returns>转换之后的 entity</returns>
        AppEntity toEntity(AppVo vo);

        /// <summary>
        /// 转换为 vo
        /// </summary>
        /// <param name="entity">需要转换的 entity</param>
        /// <param name="isEditable">是否用于编辑</param>
        /// <returns>转换之后的 vo</returns>
        AppVo toVo(AppEntity entity, bool isEditable);

        /// <summary>
        /// 转换为 entityList
        /// </summary>
        /// <param name="voList">需要转换的 voList</param>
        /// <returns>转换之后的 entityList</returns>
        List<AppEntity> toEntityList(List<AppVo> voList);

        /// <summary>
        /// 转换为 voList
        /// </summary>
        /// <param name="entityList">需要转换的 entityList</param>
        /// <returns>转换之后的 voList</returns>
        List<AppVo> toVoList(List<AppEntity> entityList);
    }
}
