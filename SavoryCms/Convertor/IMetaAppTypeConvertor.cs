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
        /// 转换为 entity
        /// </summary>
        /// <param name="vo">需要转换的 vo</param>
        /// <returns>转换之后的 entity</returns>
        MetaAppTypeEntity toEntity(MetaAppTypeVo vo);

        /// <summary>
        /// 转换为 vo
        /// </summary>
        /// <param name="entity">需要转换的 entity</param>
        /// <param name="isEditable">是否用于编辑</param>
        /// <returns>转换之后的 vo</returns>
        MetaAppTypeVo toVo(MetaAppTypeEntity entity, bool isEditable);

        /// <summary>
        /// 转换为 entityList
        /// </summary>
        /// <param name="voList">需要转换的 voList</param>
        /// <returns>转换之后的 entityList</returns>
        List<MetaAppTypeEntity> toEntityList(List<MetaAppTypeVo> voList);

        /// <summary>
        /// 转换为 voList
        /// </summary>
        /// <param name="entityList">需要转换的 entityList</param>
        /// <returns>转换之后的 voList</returns>
        List<MetaAppTypeVo> toVoList(List<MetaAppTypeEntity> entityList);

        /// <summary>
        /// 从 entityList 中获取符合条件的 entityList, 并转换为 voList。用于展示
        /// </summary>
        /// <param name="entityList">所有的 entityList</param>
        /// <param name="keys">用于筛选出符合条件的 entityList</param>
        /// <returns>转换之后的 voList</returns>
        List<MetaAppTypeVo> getVoListByIntKeyList(List<MetaAppTypeEntity> entityList, List<int> keys);

        /// <summary>
        /// 从 entityList 中获取符合条件的 entityList, 并转换为 voList。用于编辑
        /// </summary>
        /// <param name="entityList">所有的 entityList</param>
        /// <param name="keys">用于筛选出符合条件的 entityList</param>
        /// <returns>转换之后的 voList</returns>
        List<MetaAppTypeVo> getEditableListByIntKeyList(List<MetaAppTypeEntity> entityList, List<int> keys);

        /// <summary>
        /// 从 entityList 中获取符合条件的 entity, 并转换为 vo
        /// </summary>
        /// <param name="entityList">所有的 entityList</param>
        /// <param name="key">用于筛选出符合条件的 entityList</param>
        /// <returns>转换之后的 vo</returns>
        MetaAppTypeVo getVoByIntKey(List<MetaAppTypeEntity> entityList, int key);
    }
}
