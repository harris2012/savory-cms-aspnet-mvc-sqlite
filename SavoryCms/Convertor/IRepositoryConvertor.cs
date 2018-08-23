using SavoryCms.Repository.Entity;
using SavoryCms.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryCms.Convertor
{
    public interface IRepositoryConvertor
    {
        /// <summary>
        /// 转换为 entity
        /// </summary>
        /// <param name="vo">需要转换的 vo</param>
        /// <returns>转换之后的 entity</returns>
        RepositoryEntity toEntity(RepositoryVo vo);

        /// <summary>
        /// 转换为 vo
        /// </summary>
        /// <param name="entity">需要转换的 entity</param>
        /// <param name="isEditable">是否用于编辑</param>
        /// <returns>转换之后的 vo</returns>
        RepositoryVo toVo(RepositoryEntity entity, bool isEditable);

        /// <summary>
        /// 转换为 entityList
        /// </summary>
        /// <param name="voList">需要转换的 voList</param>
        /// <returns>转换之后的 entityList</returns>
        List<RepositoryEntity> toEntityList(List<RepositoryVo> voList);

        /// <summary>
        /// 转换为 voList
        /// </summary>
        /// <param name="entityList">需要转换的 entityList</param>
        /// <returns>转换之后的 voList</returns>
        List<RepositoryVo> toVoList(List<RepositoryEntity> entityList);
    }
}
