using SavoryCms.Controllers.Request;
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
        /// request 转换为 entity
        /// </summary>
        RepositoryEntity toEntity(RepositoryCreateRequest request);

        /// <summary>
        /// request 转换为 entity
        /// </summary>
        RepositoryEntity toEntity(RepositoryUpdateRequest request, RepositoryEntity oldEntity);

        /// <summary>
        /// 获取空 vo
        /// </summary>
        RepositoryVo toEmptyVo();

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        RepositoryVo toLessVo(RepositoryEntity entity);

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        RepositoryVo toMoreVo(RepositoryEntity entity);

        /// <summary>
        /// entityList 转换为 voList
        /// </summary>
        List<RepositoryVo> toLessVoList(List<RepositoryEntity> entityList);
    }
}
