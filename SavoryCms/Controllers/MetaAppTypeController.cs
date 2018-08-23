using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Web.Http;

using SavoryCms.Controllers.Request;
using SavoryCms.Controllers.Response;
using SavoryCms.Convertor;
using SavoryCms.Repository;
using SavoryCms.Repository.Entity;
using SavoryCms.Meta;

namespace SavoryCms.Controllers
{
    [RoutePrefix("api/meta-app-type")]
    public class MetaAppTypeController : BaseController
    {
        /// <summary>
        /// 分页，每页个数
        /// </summary>
        private static readonly int PAGE_SIZE = 15;

        private IMetaAppTypeRepository metaAppTypeRepository;

        private IMetaAppTypeConvertor metaAppTypeConvertor;

        private IMetaAppTypeMeta metaAppTypeMeta;

        public MetaAppTypeController(IMetaAppTypeRepository metaAppTypeRepository, IMetaAppTypeConvertor metaAppTypeConvertor, IMetaAppTypeMeta metaAppTypeMeta)
        {
            this.metaAppTypeRepository = metaAppTypeRepository;
            this.metaAppTypeConvertor = metaAppTypeConvertor;
            this.metaAppTypeMeta = metaAppTypeMeta;
        }

        [HttpPost]
        [Route("items")]
        public MetaAppTypeItemsResponse Items([FromBody]MetaAppTypeItemsRequest request)
        {
            MetaAppTypeItemsResponse response = new MetaAppTypeItemsResponse();

            List<MetaAppTypeEntity> entityList = metaAppTypeRepository.GetEntityList(request.PageIndex, PAGE_SIZE);

            response.Items = metaAppTypeConvertor.toVoList(entityList);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("count")]
        public MetaAppTypeCountResponse Count([FromBody]MetaAppTypeCountRequest request)
        {

            MetaAppTypeCountResponse response = new MetaAppTypeCountResponse();

            int count = metaAppTypeRepository.GetCount();

            response.TotalCount = count;

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("item")]
        public MetaAppTypeItemResponse Item([FromBody]MetaAppTypeItemRequest request)
        {

            MetaAppTypeItemResponse response = new MetaAppTypeItemResponse();

            if (request.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            MetaAppTypeEntity entity = metaAppTypeRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = metaAppTypeConvertor.toVo(entity, false);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("create")]
        public MetaAppTypeCreateResponse Create([FromBody]MetaAppTypeCreateRequest request)
        {

            MetaAppTypeCreateResponse response = new MetaAppTypeCreateResponse();

            metaAppTypeRepository.Create(metaAppTypeConvertor.toEntity(request.Item));

            metaAppTypeMeta.Refresh();

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("editable")]
        public MetaAppTypeEditableResponse Editable([FromBody]MetaAppTypeEditableRequest request)
        {

            MetaAppTypeEditableResponse response = new MetaAppTypeEditableResponse();

            if (request.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            MetaAppTypeEntity entity = metaAppTypeRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = metaAppTypeConvertor.toVo(entity, true);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("update")]
        public MetaAppTypeUpdateResponse Update([FromBody]MetaAppTypeUpdateRequest request)
        {

            MetaAppTypeUpdateResponse response = new MetaAppTypeUpdateResponse();

            if (request.Item.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            MetaAppTypeEntity entity = metaAppTypeRepository.GetById(request.Item.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            metaAppTypeRepository.Update(metaAppTypeConvertor.toEntity(request.Item));

            metaAppTypeMeta.Refresh();

            response.Status = 1;
            return response;
        }
    }
}