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
        /// 转换为 entity
        /// </summary>
        /// <param name="vo">需要转换的 vo</param>
        /// <returns>转换之后的 entity</returns>
        MetaRepositoryTypeEntity toEntity(MetaRepositoryTypeVo vo);

        /// <summary>
        /// 转换为 vo
        /// </summary>
        /// <param name="entity">需要转换的 entity</param>
        /// <param name="isEditable">是否用于编辑</param>
        /// <returns>转换之后的 vo</returns>
        MetaRepositoryTypeVo toVo(MetaRepositoryTypeEntity entity, bool isEditable);

        /// <summary>
        /// 转换为 entityList
        /// </summary>
        /// <param name="voList">需要转换的 voList</param>
        /// <returns>转换之后的 entityList</returns>
        List<MetaRepositoryTypeEntity> toEntityList(List<MetaRepositoryTypeVo> voList);

        /// <summary>
        /// 转换为 voList
        /// </summary>
        /// <param name="entityList">需要转换的 entityList</param>
        /// <returns>转换之后的 voList</returns>
        List<MetaRepositoryTypeVo> toVoList(List<MetaRepositoryTypeEntity> entityList);

        /// <summary>
        /// 从 entityList 中获取符合条件的 entityList, 并转换为 voList。用于展示
        /// </summary>
        /// <param name="entityList">所有的 entityList</param>
        /// <param name="keys">用于筛选出符合条件的 entityList</param>
        /// <returns>转换之后的 voList</returns>
        List<MetaRepositoryTypeVo> getVoListByIntKeyList(List<MetaRepositoryTypeEntity> entityList, List<int> keys);

        /// <summary>
        /// 从 entityList 中获取符合条件的 entityList, 并转换为 voList。用于编辑
        /// </summary>
        /// <param name="entityList">所有的 entityList</param>
        /// <param name="keys">用于筛选出符合条件的 entityList</param>
        /// <returns>转换之后的 voList</returns>
        List<MetaRepositoryTypeVo> getEditableListByIntKeyList(List<MetaRepositoryTypeEntity> entityList, List<int> keys);

        /// <summary>
        /// 从 entityList 中获取符合条件的 entity, 并转换为 vo
        /// </summary>
        /// <param name="entityList">所有的 entityList</param>
        /// <param name="key">用于筛选出符合条件的 entityList</param>
        /// <returns>转换之后的 vo</returns>
        MetaRepositoryTypeVo getVoByIntKey(List<MetaRepositoryTypeEntity> entityList, int key);
    }
}
