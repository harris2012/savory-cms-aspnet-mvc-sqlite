using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Repository.Entity;
using SavoryCms.Vo;

namespace SavoryCms.Convertor
{
    public class MetaRepositoryTypeConvertor : IMetaRepositoryTypeConvertor
    {

        public MetaRepositoryTypeEntity toEntity(MetaRepositoryTypeVo vo)
        {
            MetaRepositoryTypeEntity entity = new MetaRepositoryTypeEntity();

            entity.Id = vo.Id;
            entity.RepositoryTypeId = vo.RepositoryTypeId;
            entity.RepositoryTypeName = vo.RepositoryTypeName;

            return entity;
        }

        public MetaRepositoryTypeVo toVo(MetaRepositoryTypeEntity entity, bool isEditable)
        {
            MetaRepositoryTypeVo vo = new MetaRepositoryTypeVo();

            vo.Id = entity.Id;
            vo.RepositoryTypeId = entity.RepositoryTypeId;
            vo.RepositoryTypeName = entity.RepositoryTypeName;

            return vo;
        }

        public List<MetaRepositoryTypeEntity> toEntityList(List<MetaRepositoryTypeVo> voList)
        {
            if (voList == null || voList.Count == 0)
            {
                return null;
            }

            List<MetaRepositoryTypeEntity> entityList = new List<MetaRepositoryTypeEntity>();
            foreach (var vo in voList)
            {
                entityList.Add(toEntity(vo));
            }

            return entityList;
        }

        public List<MetaRepositoryTypeVo> toVoList(List<MetaRepositoryTypeEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<MetaRepositoryTypeVo> voList = new List<MetaRepositoryTypeVo>();
            foreach (var entity in entityList)
            {
                voList.Add(toVo(entity, false));
            }

            return voList;
        }

        public List<MetaRepositoryTypeVo> getVoListByIntKeyList(List<MetaRepositoryTypeEntity> entityList, List<int> keys) {

            List<MetaRepositoryTypeVo> voList = new List<MetaRepositoryTypeVo>();
            foreach(var value in keys) {

                MetaRepositoryTypeVo vo = getVoByIntKey(entityList, value);
                if (vo != null) {
                    voList.Add(vo);
                }
            }

            return voList;
        }

        public List<MetaRepositoryTypeVo> getEditableListByIntKeyList(List<MetaRepositoryTypeEntity> entityList, List<int> keys) {

            List<MetaRepositoryTypeVo> voList = new List<MetaRepositoryTypeVo>();
            foreach(var entity in entityList) {

                MetaRepositoryTypeVo vo = toVo(entity, true);
                if (keys.Contains(entity.RepositoryTypeId)) {
                    vo.Selected = true;
                }
                voList.Add(vo);
            }

            return voList;
        }

        public MetaRepositoryTypeVo getVoByIntKey(List<MetaRepositoryTypeEntity> entityList, int key) {

            foreach(var entity in entityList) {

                if (entity.RepositoryTypeId != key) {
                    continue;
                }

                MetaRepositoryTypeVo vo = toVo(entity, false);

                return vo;
            }

            return null;
        }
    }
}
