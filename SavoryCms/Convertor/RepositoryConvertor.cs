using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryCms.Meta;
using SavoryCms.Controllers.Request;
using SavoryCms.Repository.Entity;
using SavoryCms.Vo;

namespace SavoryCms.Convertor
{
    public class RepositoryConvertor : IRepositoryConvertor
    {

        private ITheMetaRepositoryTypeMeta theMetaRepositoryTypeMeta;
        private ITheMetaRepositoryTypeConvertor theMetaRepositoryTypeConvertor;

        public RepositoryConvertor(
            ITheMetaRepositoryTypeMeta theMetaRepositoryTypeMeta,
            ITheMetaRepositoryTypeConvertor theMetaRepositoryTypeConvertor
        )
        {
            this.theMetaRepositoryTypeMeta = theMetaRepositoryTypeMeta;
            this.theMetaRepositoryTypeConvertor = theMetaRepositoryTypeConvertor;
        }

        public RepositoryEntity toEntity(RepositoryCreateRequest request)
        {
            RepositoryEntity entity = new RepositoryEntity();

            entity.RepositoryName = request.RepositoryName;
            entity.RepositoryTypeId = request.RepositoryTypeId != null ? request.RepositoryTypeId.Value : 0;
            entity.GitlabProjectFullname = request.GitlabProjectFullname;
            entity.DataStatus = request.DataStatus != null ? request.DataStatus.Value : 0;
            entity.Description = request.Description;

            return entity;
        }

        public RepositoryEntity toEntity(RepositoryUpdateRequest request)
        {
            RepositoryEntity entity = new RepositoryEntity();

            entity.Id = request.Id;
            entity.RepositoryName = request.RepositoryName;
            entity.RepositoryTypeId = request.RepositoryTypeId != null ? request.RepositoryTypeId.Value : 0;
            entity.GitlabProjectFullname = request.GitlabProjectFullname;
            entity.DataStatus = request.DataStatus != null ? request.DataStatus.Value : 0;
            entity.Description = request.Description;

            return entity;
        }

        public RepositoryVo toEmptyVo()
        {
            RepositoryVo vo = new RepositoryVo();

            List<TheMetaRepositoryTypeEntity> theMetaRepositoryTypeEntityList = theMetaRepositoryTypeMeta.GetEntityList();
            vo.RepositoryTypeId = theMetaRepositoryTypeConvertor.getVoList(theMetaRepositoryTypeEntityList);

            return vo;
        }

        public RepositoryVo toLessVo(RepositoryEntity entity)
        {
            RepositoryVo vo = toVo(entity);

            List<TheMetaRepositoryTypeEntity> theMetaRepositoryTypeEntityList = theMetaRepositoryTypeMeta.GetEntityList();
            vo.RepositoryTypeId = theMetaRepositoryTypeConvertor.getLessVoList(theMetaRepositoryTypeEntityList, entity.RepositoryTypeId);

            return vo;
        }

        public RepositoryVo toMoreVo(RepositoryEntity entity)
        {
            RepositoryVo vo = toVo(entity);

            List<TheMetaRepositoryTypeEntity> theMetaRepositoryTypeEntityList = theMetaRepositoryTypeMeta.GetEntityList();
            vo.RepositoryTypeId = theMetaRepositoryTypeConvertor.getMoreVoList(theMetaRepositoryTypeEntityList, entity.RepositoryTypeId);

            return vo;
        }

        public List<RepositoryVo> toLessVoList(List<RepositoryEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<RepositoryVo> voList = new List<RepositoryVo>();
            foreach (RepositoryEntity entity in entityList) {
                voList.Add(toLessVo(entity));
            }

            return voList;
        }

        /// <summary>
        /// 将entity转换为vo。不包括来自元数据的属性
        /// </summary>
        private RepositoryVo toVo(RepositoryEntity entity)
        {
            RepositoryVo vo = new RepositoryVo();

            vo.Id = entity.Id;
            vo.RepositoryName = entity.RepositoryName;
            vo.GitlabProjectFullname = entity.GitlabProjectFullname;
            vo.DataStatus = entity.DataStatus;
            vo.Description = entity.Description;

            return vo;
        }
    }
}
