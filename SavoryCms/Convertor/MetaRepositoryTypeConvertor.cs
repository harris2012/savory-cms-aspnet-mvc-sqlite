using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Controllers.Request;
using SavoryCms.Repository.Entity;
using SavoryCms.Vo;

namespace SavoryCms.Convertor
{
    public class MetaRepositoryTypeConvertor : IMetaRepositoryTypeConvertor
    {

        public MetaRepositoryTypeEntity toEntity(MetaRepositoryTypeCreateRequest request)
        {
            MetaRepositoryTypeEntity entity = new MetaRepositoryTypeEntity();

            entity.RepositoryTypeId = request.RepositoryTypeId != null ? request.RepositoryTypeId.Value : 0;
            entity.RepositoryTypeName = request.RepositoryTypeName;

            return entity;
        }

        public MetaRepositoryTypeEntity toEntity(MetaRepositoryTypeUpdateRequest request)
        {
            MetaRepositoryTypeEntity entity = new MetaRepositoryTypeEntity();

            entity.Id = request.Id != null ? request.Id.Value : 0;
            entity.RepositoryTypeId = request.RepositoryTypeId != null ? request.RepositoryTypeId.Value : 0;
            entity.RepositoryTypeName = request.RepositoryTypeName;

            return entity;
        }

        public MetaRepositoryTypeVo toEmptyVo()
        {
            MetaRepositoryTypeVo vo = new MetaRepositoryTypeVo();

            return vo;
        }

        public MetaRepositoryTypeVo toLessVo(MetaRepositoryTypeEntity entity)
        {
            MetaRepositoryTypeVo vo = toVo(entity);

            return vo;
        }

        public MetaRepositoryTypeVo toMoreVo(MetaRepositoryTypeEntity entity)
        {
            MetaRepositoryTypeVo vo = toVo(entity);

            return vo;
        }

        public List<MetaRepositoryTypeVo> toLessVoList(List<MetaRepositoryTypeEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<MetaRepositoryTypeVo> voList = new List<MetaRepositoryTypeVo>();
            foreach (MetaRepositoryTypeEntity entity in entityList) {
                voList.Add(toLessVo(entity));
            }

            return voList;
        }

        /// <summary>
        /// 将entity转换为vo。不包括来自元数据的属性
        /// </summary>
        private MetaRepositoryTypeVo toVo(MetaRepositoryTypeEntity entity)
        {
            MetaRepositoryTypeVo vo = new MetaRepositoryTypeVo();

            vo.Id = entity.Id;
            vo.RepositoryTypeId = entity.RepositoryTypeId;
            vo.RepositoryTypeName = entity.RepositoryTypeName;

            return vo;
        }
    }
}
