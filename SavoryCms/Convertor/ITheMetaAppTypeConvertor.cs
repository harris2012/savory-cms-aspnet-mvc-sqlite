using SavoryCms.Controllers.Request;
using SavoryCms.Repository.Entity;
using SavoryCms.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryCms.Convertor
{
    public interface ITheMetaAppTypeConvertor
    {

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        TheMetaAppTypeVo toVo(TheMetaAppTypeEntity entity);

        /// <summary>
        /// 获取所有的选项
        /// </summary>
        List<TheMetaAppTypeVo> getVoList(List<TheMetaAppTypeEntity> entityList);

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        List<TheMetaAppTypeVo> getLessVoList(List<TheMetaAppTypeEntity> entityList, int key);

        /// <summary>
        /// 获取所有的元数据。标记已经选择的。
        /// </summary>
        List<TheMetaAppTypeVo> getMoreVoList(List<TheMetaAppTypeEntity> entityList, int key);

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        List<TheMetaAppTypeVo> getLessVoList(List<TheMetaAppTypeEntity> entityList, List<int> keys);

        /// <summary>
        /// 获取所有的元数据。标记已经选择的。
        /// </summary>
        List<TheMetaAppTypeVo> getMoreVoList(List<TheMetaAppTypeEntity> entityList, List<int> keys);

    }
}
