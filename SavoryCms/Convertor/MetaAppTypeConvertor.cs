using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Repository.Entity;
using SavoryCms.Vo;

namespace SavoryCms.Convertor
{
    public class MetaAppTypeConvertor : IMetaAppTypeConvertor
    {

        public MetaAppTypeEntity toEntity(MetaAppTypeVo vo)
        {
            MetaAppTypeEntity entity = new MetaAppTypeEntity();

            entity.Id = vo.Id;
            entity.AppTypeId = vo.AppTypeId;
            entity.AppTypeName = vo.AppTypeName;

            return entity;
        }

        public MetaAppTypeVo toVo(MetaAppTypeEntity entity, bool isEditable)
        {
            MetaAppTypeVo vo = new MetaAppTypeVo();

            vo.Id = entity.Id;
            vo.AppTypeId = entity.AppTypeId;
            vo.AppTypeName = entity.AppTypeName;

            return vo;
        }

        public List<MetaAppTypeEntity> toEntityList(List<MetaAppTypeVo> voList)
        {
            if (voList == null || voList.Count == 0)
            {
                return null;
            }

            List<MetaAppTypeEntity> entityList = new List<MetaAppTypeEntity>();
            foreach (var vo in voList)
            {
                entityList.Add(toEntity(vo));
            }

            return entityList;
        }

        public List<MetaAppTypeVo> toVoList(List<MetaAppTypeEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<MetaAppTypeVo> voList = new List<MetaAppTypeVo>();
            foreach (var entity in entityList)
            {
                voList.Add(toVo(entity, false));
            }

            return voList;
        }

        public List<MetaAppTypeVo> getVoListByIntKeyList(List<MetaAppTypeEntity> entityList, List<int> keys) {

            List<MetaAppTypeVo> voList = new List<MetaAppTypeVo>();
            foreach(var value in keys) {

                MetaAppTypeVo vo = getVoByIntKey(entityList, value);
                if (vo != null) {
                    voList.Add(vo);
                }
            }

            return voList;
        }

        public List<MetaAppTypeVo> getEditableListByIntKeyList(List<MetaAppTypeEntity> entityList, List<int> keys) {

            List<MetaAppTypeVo> voList = new List<MetaAppTypeVo>();
            foreach(var entity in entityList) {

                MetaAppTypeVo vo = toVo(entity, true);
                if (keys.Contains(entity.AppTypeId)) {
                    vo.Selected = true;
                }
                voList.Add(vo);
            }

            return voList;
        }

        public MetaAppTypeVo getVoByIntKey(List<MetaAppTypeEntity> entityList, int key) {

            foreach(var entity in entityList) {

                if (entity.AppTypeId != key) {
                    continue;
                }

                MetaAppTypeVo vo = toVo(entity, false);

                return vo;
            }

            return null;
        }
    }
}
