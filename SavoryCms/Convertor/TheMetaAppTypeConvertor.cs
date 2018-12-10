using SavoryCms.Controllers.Request;
using SavoryCms.Repository.Entity;
using SavoryCms.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryCms.Convertor
{
    public class TheMetaAppTypeConvertor : ITheMetaAppTypeConvertor
    {
        public TheMetaAppTypeVo toVo(TheMetaAppTypeEntity entity)
        {
            TheMetaAppTypeVo vo = new TheMetaAppTypeVo();

            vo.AppTypeId = entity.AppTypeId;
            vo.AppTypeName = entity.AppTypeName;

            return vo;
        }

        public List<TheMetaAppTypeVo> getVoList(List<TheMetaAppTypeEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0) {
                return null;
            }

            List<TheMetaAppTypeVo> voList = new List<TheMetaAppTypeVo>();
            foreach (TheMetaAppTypeEntity entity in entityList)
            {

                TheMetaAppTypeVo vo = toVo(entity);
                voList.Add(vo);
            }

            return voList;
        }

        public List<TheMetaAppTypeVo> getLessVoList(List<TheMetaAppTypeEntity> entityList, int key)
        {
            if (entityList == null || entityList.Count == 0) {
                return null;
            }

            foreach (TheMetaAppTypeEntity entity in entityList)
            {
                if (entity.AppTypeId == key)
                {
                    return new List<TheMetaAppTypeVo> { toVo(entity) };
                }
            }

            return null;
        }

        public List<TheMetaAppTypeVo> getMoreVoList(List<TheMetaAppTypeEntity> entityList, int key)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<TheMetaAppTypeVo> voList = new List<TheMetaAppTypeVo>();
            foreach (TheMetaAppTypeEntity entity in entityList)
            {
                TheMetaAppTypeVo vo = toVo(entity);
                voList.Add(vo);

                if (entity.AppTypeId == key)
                {
                    vo.Selected = true;
                }
            }

            return voList;
        }

        public List<TheMetaAppTypeVo> getLessVoList(List<TheMetaAppTypeEntity> entityList, List<int> keys)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<TheMetaAppTypeVo> voList = new List<TheMetaAppTypeVo>();
            foreach (TheMetaAppTypeEntity entity in entityList)
            {
                if (!keys.Contains(entity.AppTypeId))
                {
                    continue;
                }

                TheMetaAppTypeVo vo = toVo(entity);
                vo.Selected = true;
                voList.Add(vo);

                if(voList.Count == keys.Count)
                {
                    break;
                }
            }

            return voList;
        }

        public List<TheMetaAppTypeVo> getMoreVoList(List<TheMetaAppTypeEntity> entityList, List<int> keys)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<TheMetaAppTypeVo> voList = new List<TheMetaAppTypeVo>();
            foreach (TheMetaAppTypeEntity entity in entityList)
            {
                TheMetaAppTypeVo vo = toVo(entity);
                if (keys.Contains(entity.AppTypeId))
                {
                    vo.Selected = true;
                }
                voList.Add(vo);
            }

            return voList;
        }
    }
}
