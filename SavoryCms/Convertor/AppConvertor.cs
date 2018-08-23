using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Meta;
using SavoryCms.Repository.Entity;
using SavoryCms.Vo;

namespace SavoryCms.Convertor
{
    public class AppConvertor : IAppConvertor
    {

        private IMetaAppTypeMeta metaAppTypeMeta;

        private IMetaAppTypeConvertor metaAppTypeConvertor;

        public AppConvertor(IMetaAppTypeMeta metaAppTypeMeta, IMetaAppTypeConvertor metaAppTypeConvertor)
        {
            this.metaAppTypeMeta = metaAppTypeMeta;
            this.metaAppTypeConvertor = metaAppTypeConvertor;
        }

        public AppEntity toEntity(AppVo vo)
        {
            AppEntity entity = new AppEntity();

            entity.Id = vo.Id;
            entity.AppId = vo.AppId;
            entity.AppEname = vo.AppEname;
            entity.AppName = vo.AppName;
            entity.AppTypeId = getAppTypeId(vo);
            entity.DataStatus = vo.DataStatus;
            entity.Description = vo.Description;

            return entity;
        }

        public AppVo toVo(AppEntity entity, bool isEditable)
        {
            AppVo vo = new AppVo();

            List<MetaAppTypeEntity> metaAppTypeEntityList = metaAppTypeMeta.GetEntityList();

            vo.Id = entity.Id;
            vo.AppId = entity.AppId;
            vo.AppEname = entity.AppEname;
            vo.AppName = entity.AppName;
            vo.AppTypeId = getAppTypeId(metaAppTypeEntityList, entity, isEditable);
            vo.DataStatus = entity.DataStatus;
            vo.Description = entity.Description;

            return vo;
        }

        public List<AppEntity> toEntityList(List<AppVo> voList)
        {
            if (voList == null || voList.Count == 0)
            {
                return null;
            }

            List<AppEntity> entityList = new List<AppEntity>();
            foreach (var vo in voList)
            {
                entityList.Add(toEntity(vo));
            }

            return entityList;
        }

        public List<AppVo> toVoList(List<AppEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<AppVo> voList = new List<AppVo>();
            foreach (var entity in entityList)
            {
                voList.Add(toVo(entity, false));
            }

            return voList;
        }

        private int getAppTypeId(AppVo vo)
        {
            List<MetaAppTypeVo> items = vo.AppTypeId;
            if (items == null || items.Count == 0) {
                return 0;
            }

            foreach(var item in items) {
                if (item.Selected) {
                    return item.AppTypeId;
                }
            }

            return 0;
        }

        private List<MetaAppTypeVo> getAppTypeId(List<MetaAppTypeEntity> metaAppTypeEntityList, AppEntity entity, bool isEditable)
        {
            if (isEditable) {
                return metaAppTypeConvertor.getEditableListByIntKeyList(metaAppTypeEntityList, new List<int> { entity.AppTypeId });
            } else {
                return metaAppTypeConvertor.getVoListByIntKeyList(metaAppTypeEntityList, new List<int> { entity.AppTypeId });
            }
        }
    }
}
