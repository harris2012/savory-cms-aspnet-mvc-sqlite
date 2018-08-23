using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Meta;
using SavoryCms.Repository.Entity;
using SavoryCms.Vo;

namespace SavoryCms.Convertor
{
    public class RepositoryConvertor : IRepositoryConvertor
    {

        private IMetaRepositoryTypeMeta metaRepositoryTypeMeta;

        private IMetaRepositoryTypeConvertor metaRepositoryTypeConvertor;

        public RepositoryConvertor(IMetaRepositoryTypeMeta metaRepositoryTypeMeta, IMetaRepositoryTypeConvertor metaRepositoryTypeConvertor)
        {
            this.metaRepositoryTypeMeta = metaRepositoryTypeMeta;
            this.metaRepositoryTypeConvertor = metaRepositoryTypeConvertor;
        }

        public RepositoryEntity toEntity(RepositoryVo vo)
        {
            RepositoryEntity entity = new RepositoryEntity();

            entity.Id = vo.Id;
            entity.RepositoryName = vo.RepositoryName;
            entity.RepositoryTypeId = getRepositoryTypeId(vo);
            entity.GitlabProjectFullname = vo.GitlabProjectFullname;
            entity.DataStatus = vo.DataStatus;
            entity.Description = vo.Description;

            return entity;
        }

        public RepositoryVo toVo(RepositoryEntity entity, bool isEditable)
        {
            RepositoryVo vo = new RepositoryVo();

            List<MetaRepositoryTypeEntity> metaRepositoryTypeEntityList = metaRepositoryTypeMeta.GetEntityList();

            vo.Id = entity.Id;
            vo.RepositoryName = entity.RepositoryName;
            vo.RepositoryTypeId = getRepositoryTypeId(metaRepositoryTypeEntityList, entity, isEditable);
            vo.GitlabProjectFullname = entity.GitlabProjectFullname;
            vo.DataStatus = entity.DataStatus;
            vo.Description = entity.Description;

            return vo;
        }

        public List<RepositoryEntity> toEntityList(List<RepositoryVo> voList)
        {
            if (voList == null || voList.Count == 0)
            {
                return null;
            }

            List<RepositoryEntity> entityList = new List<RepositoryEntity>();
            foreach (var vo in voList)
            {
                entityList.Add(toEntity(vo));
            }

            return entityList;
        }

        public List<RepositoryVo> toVoList(List<RepositoryEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<RepositoryVo> voList = new List<RepositoryVo>();
            foreach (var entity in entityList)
            {
                voList.Add(toVo(entity, false));
            }

            return voList;
        }

        private int getRepositoryTypeId(RepositoryVo vo)
        {
            List<MetaRepositoryTypeVo> items = vo.RepositoryTypeId;
            if (items == null || items.Count == 0) {
                return 0;
            }

            foreach(var item in items) {
                if (item.Selected) {
                    return item.RepositoryTypeId;
                }
            }

            return 0;
        }

        private List<MetaRepositoryTypeVo> getRepositoryTypeId(List<MetaRepositoryTypeEntity> metaRepositoryTypeEntityList, RepositoryEntity entity, bool isEditable)
        {
            if (isEditable) {
                return metaRepositoryTypeConvertor.getEditableListByIntKeyList(metaRepositoryTypeEntityList, new List<int> { entity.RepositoryTypeId });
            } else {
                return metaRepositoryTypeConvertor.getVoListByIntKeyList(metaRepositoryTypeEntityList, new List<int> { entity.RepositoryTypeId });
            }
        }
    }
}
