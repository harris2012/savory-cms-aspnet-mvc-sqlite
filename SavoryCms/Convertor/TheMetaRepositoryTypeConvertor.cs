using SavoryCms.Controllers.Request;
using SavoryCms.Repository.Entity;
using SavoryCms.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryCms.Convertor
{
    public class TheMetaRepositoryTypeConvertor : ITheMetaRepositoryTypeConvertor
    {
        public TheMetaRepositoryTypeVo toVo(TheMetaRepositoryTypeEntity entity)
        {
            TheMetaRepositoryTypeVo vo = new TheMetaRepositoryTypeVo();

            vo.RepositoryTypeId = entity.RepositoryTypeId;
            vo.RepositoryTypeName = entity.RepositoryTypeName;

            return vo;
        }

        public List<TheMetaRepositoryTypeVo> getVoList(List<TheMetaRepositoryTypeEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0) {
                return null;
            }

            List<TheMetaRepositoryTypeVo> voList = new List<TheMetaRepositoryTypeVo>();
            foreach (TheMetaRepositoryTypeEntity entity in entityList)
            {

                TheMetaRepositoryTypeVo vo = toVo(entity);
                voList.Add(vo);
            }

            return voList;
        }

        public List<TheMetaRepositoryTypeVo> getLessVoList(List<TheMetaRepositoryTypeEntity> entityList, int key)
        {
            if (entityList == null || entityList.Count == 0) {
                return null;
            }

            foreach (TheMetaRepositoryTypeEntity entity in entityList)
            {
                if (entity.RepositoryTypeId == key)
                {
                    return new List<TheMetaRepositoryTypeVo> { toVo(entity) };
                }
            }

            return null;
        }

        public List<TheMetaRepositoryTypeVo> getMoreVoList(List<TheMetaRepositoryTypeEntity> entityList, int key)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<TheMetaRepositoryTypeVo> voList = new List<TheMetaRepositoryTypeVo>();
            foreach (TheMetaRepositoryTypeEntity entity in entityList)
            {
                TheMetaRepositoryTypeVo vo = toVo(entity);
                voList.Add(vo);

                if (entity.RepositoryTypeId == key)
                {
                    vo.Selected = true;
                }
            }

            return voList;
        }

        public List<TheMetaRepositoryTypeVo> getLessVoList(List<TheMetaRepositoryTypeEntity> entityList, List<int> keys)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<TheMetaRepositoryTypeVo> voList = new List<TheMetaRepositoryTypeVo>();
            foreach (TheMetaRepositoryTypeEntity entity in entityList)
            {
                if (!keys.Contains(entity.RepositoryTypeId))
                {
                    continue;
                }

                TheMetaRepositoryTypeVo vo = toVo(entity);
                vo.Selected = true;
                voList.Add(vo);

                if(voList.Count == keys.Count)
                {
                    break;
                }
            }

            return voList;
        }

        public List<TheMetaRepositoryTypeVo> getMoreVoList(List<TheMetaRepositoryTypeEntity> entityList, List<int> keys)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<TheMetaRepositoryTypeVo> voList = new List<TheMetaRepositoryTypeVo>();
            foreach (TheMetaRepositoryTypeEntity entity in entityList)
            {
                TheMetaRepositoryTypeVo vo = toVo(entity);
                if (keys.Contains(entity.RepositoryTypeId))
                {
                    vo.Selected = true;
                }
                voList.Add(vo);
            }

            return voList;
        }
    }
}
