using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Controllers.Request;
using SavoryCms.Repository.Entity;
using SavoryCms.Vo;

namespace SavoryCms.Convertor
{
    public class MetaAppTypeConvertor : IMetaAppTypeConvertor
    {

        public MetaAppTypeEntity toEntity(MetaAppTypeCreateRequest request)
        {
            MetaAppTypeEntity entity = new MetaAppTypeEntity();

            entity.AppTypeId = request.AppTypeId != null ? request.AppTypeId.Value : 0;
            entity.AppTypeName = request.AppTypeName;

            return entity;
        }

        public MetaAppTypeEntity toEntity(MetaAppTypeUpdateRequest request)
        {
            MetaAppTypeEntity entity = new MetaAppTypeEntity();

            entity.Id = request.Id != null ? request.Id.Value : 0;
            entity.AppTypeId = request.AppTypeId != null ? request.AppTypeId.Value : 0;
            entity.AppTypeName = request.AppTypeName;

            return entity;
        }

        public MetaAppTypeVo toEmptyVo()
        {
            MetaAppTypeVo vo = new MetaAppTypeVo();

            return vo;
        }

        public MetaAppTypeVo toLessVo(MetaAppTypeEntity entity)
        {
            MetaAppTypeVo vo = toVo(entity);

            return vo;
        }

        public MetaAppTypeVo toMoreVo(MetaAppTypeEntity entity)
        {
            MetaAppTypeVo vo = toVo(entity);

            return vo;
        }

        public List<MetaAppTypeVo> toLessVoList(List<MetaAppTypeEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<MetaAppTypeVo> voList = new List<MetaAppTypeVo>();
            foreach (MetaAppTypeEntity entity in entityList) {
                voList.Add(toLessVo(entity));
            }

            return voList;
        }

        /// <summary>
        /// 将entity转换为vo。不包括来自元数据的属性
        /// </summary>
        private MetaAppTypeVo toVo(MetaAppTypeEntity entity)
        {
            MetaAppTypeVo vo = new MetaAppTypeVo();

            vo.Id = entity.Id;
            vo.AppTypeId = entity.AppTypeId;
            vo.AppTypeName = entity.AppTypeName;

            return vo;
        }
    }
}
