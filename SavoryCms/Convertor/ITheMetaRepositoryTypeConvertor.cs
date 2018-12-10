using SavoryCms.Controllers.Request;
using SavoryCms.Repository.Entity;
using SavoryCms.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryCms.Convertor
{
    public interface ITheMetaRepositoryTypeConvertor
    {

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        TheMetaRepositoryTypeVo toVo(TheMetaRepositoryTypeEntity entity);

        /// <summary>
        /// 获取所有的选项
        /// </summary>
        List<TheMetaRepositoryTypeVo> getVoList(List<TheMetaRepositoryTypeEntity> entityList);

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        List<TheMetaRepositoryTypeVo> getLessVoList(List<TheMetaRepositoryTypeEntity> entityList, int key);

        /// <summary>
        /// 获取所有的元数据。标记已经选择的。
        /// </summary>
        List<TheMetaRepositoryTypeVo> getMoreVoList(List<TheMetaRepositoryTypeEntity> entityList, int key);

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        List<TheMetaRepositoryTypeVo> getLessVoList(List<TheMetaRepositoryTypeEntity> entityList, List<int> keys);

        /// <summary>
        /// 获取所有的元数据。标记已经选择的。
        /// </summary>
        List<TheMetaRepositoryTypeVo> getMoreVoList(List<TheMetaRepositoryTypeEntity> entityList, List<int> keys);

    }
}
