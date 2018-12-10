using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Meta;
using SavoryCms.Controllers.Request;
using SavoryCms.Repository.Entity;
using SavoryCms.Vo;
using SavoryCms.Utility;

namespace SavoryCms.Convertor
{
    public class AppConvertor : IAppConvertor
    {

        private ITheMetaAppTypeMeta theMetaAppTypeMeta;
        private ITheMetaAppTypeConvertor theMetaAppTypeConvertor;

        public AppConvertor(
            ITheMetaAppTypeMeta theMetaAppTypeMeta,
            ITheMetaAppTypeConvertor theMetaAppTypeConvertor
        )
        {
            this.theMetaAppTypeMeta = theMetaAppTypeMeta;
            this.theMetaAppTypeConvertor = theMetaAppTypeConvertor;
        }

        public AppEntity toEntity(AppCreateRequest request)
        {
            AppEntity entity = new AppEntity();

            entity.AppId = request.AppId != null ? request.AppId.Value : 0;
            entity.AppEname = request.AppEname;
            entity.AppName = request.AppName;
            entity.AppTypeId = request.AppTypeId != null ? request.AppTypeId.Value : 0;
            entity.DataStatus = request.DataStatus != null ? request.DataStatus.Value : 0;
            entity.Description = request.Description;

            return entity;
        }

        public AppEntity toEntity(AppUpdateRequest request, AppEntity oldEntity)
        {
            AppEntity entity = new AppEntity();

            entity.Id = request.Id;
            entity.AppId = request.AppId != null ? request.AppId.Value : 0;
            entity.AppEname = request.AppEname;
            entity.AppName = request.AppName;
            entity.AppTypeId = request.AppTypeId != null ? request.AppTypeId.Value : 0;
            entity.DataStatus = request.DataStatus != null ? request.DataStatus.Value : 0;
            entity.Description = request.Description;

            return entity;
        }

        public AppVo toEmptyVo()
        {
            AppVo vo = new AppVo();

            List<TheMetaAppTypeEntity> theMetaAppTypeEntityList = theMetaAppTypeMeta.GetEntityList();
            vo.AppTypeId = theMetaAppTypeConvertor.getVoList(theMetaAppTypeEntityList);

            return vo;
        }

        public AppVo toLessVo(AppEntity entity)
        {
            AppVo vo = toVo(entity);

            List<TheMetaAppTypeEntity> theMetaAppTypeEntityList = theMetaAppTypeMeta.GetEntityList();
            vo.AppTypeId = theMetaAppTypeConvertor.getLessVoList(theMetaAppTypeEntityList, entity.AppTypeId);

            return vo;
        }

        public AppVo toMoreVo(AppEntity entity)
        {
            AppVo vo = toVo(entity);

            List<TheMetaAppTypeEntity> theMetaAppTypeEntityList = theMetaAppTypeMeta.GetEntityList();
            vo.AppTypeId = theMetaAppTypeConvertor.getMoreVoList(theMetaAppTypeEntityList, entity.AppTypeId);

            return vo;
        }

        public List<AppVo> toLessVoList(List<AppEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<AppVo> voList = new List<AppVo>();
            foreach (AppEntity entity in entityList) {
                voList.Add(toLessVo(entity));
            }

            return voList;
        }

        /// <summary>
        /// 将entity转换为vo。不包括来自元数据的属性
        /// </summary>
        private AppVo toVo(AppEntity entity)
        {
            AppVo vo = new AppVo();

            vo.Id = entity.Id;
            vo.AppId = entity.AppId;
            vo.AppEname = entity.AppEname;
            vo.AppName = entity.AppName;
            vo.DataStatus = entity.DataStatus;
            vo.Description = entity.Description;

            return vo;
        }
    }
}
