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
    [RoutePrefix("api/meta-repository-type")]
    public class MetaRepositoryTypeController : BaseController
    {
        /// <summary>
        /// 分页，每页个数
        /// </summary>
        private static readonly int PAGE_SIZE = 15;

        private IMetaRepositoryTypeRepository metaRepositoryTypeRepository;

        private IMetaRepositoryTypeConvertor metaRepositoryTypeConvertor;

        private ITheMetaRepositoryTypeMeta theMetaRepositoryTypeMeta;

        public MetaRepositoryTypeController(
            ITheMetaRepositoryTypeMeta theMetaRepositoryTypeMeta,
            IMetaRepositoryTypeRepository metaRepositoryTypeRepository,
            IMetaRepositoryTypeConvertor metaRepositoryTypeConvertor)
        {
            this.metaRepositoryTypeRepository = metaRepositoryTypeRepository;
            this.metaRepositoryTypeConvertor = metaRepositoryTypeConvertor;
            this.theMetaRepositoryTypeMeta = theMetaRepositoryTypeMeta;
        }

        [HttpPost]
        [Route("items")]
        public MetaRepositoryTypeItemsResponse Items([FromBody]MetaRepositoryTypeItemsRequest request)
        {
            MetaRepositoryTypeItemsResponse response = new MetaRepositoryTypeItemsResponse();

            List<MetaRepositoryTypeEntity> entityList = metaRepositoryTypeRepository.GetEntityList(request.PageIndex, PAGE_SIZE);

            response.Items = metaRepositoryTypeConvertor.toLessVoList(entityList);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("count")]
        public MetaRepositoryTypeCountResponse Count([FromBody]MetaRepositoryTypeCountRequest request)
        {
            MetaRepositoryTypeCountResponse response = new MetaRepositoryTypeCountResponse();

            int count = metaRepositoryTypeRepository.GetCount();

            response.TotalCount = count;

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("item")]
        public MetaRepositoryTypeItemResponse Item([FromBody]MetaRepositoryTypeItemRequest request)
        {
            MetaRepositoryTypeItemResponse response = new MetaRepositoryTypeItemResponse();

            if (request.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            MetaRepositoryTypeEntity entity = metaRepositoryTypeRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = metaRepositoryTypeConvertor.toLessVo(entity);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("create")]
        public MetaRepositoryTypeCreateResponse Create([FromBody]MetaRepositoryTypeCreateRequest request)
        {
            MetaRepositoryTypeCreateResponse response = new MetaRepositoryTypeCreateResponse();

            metaRepositoryTypeRepository.Create(metaRepositoryTypeConvertor.toEntity(request));

            theMetaRepositoryTypeMeta.Refresh();

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("empty")]
        public MetaRepositoryTypeEmptyResponse Empty([FromBody]MetaRepositoryTypeEditableRequest request)
        {
            MetaRepositoryTypeEmptyResponse response = new MetaRepositoryTypeEmptyResponse();

            response.Item = metaRepositoryTypeConvertor.toEmptyVo();

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("editable")]
        public MetaRepositoryTypeEditableResponse Editable([FromBody]MetaRepositoryTypeEditableRequest request)
        {

            MetaRepositoryTypeEditableResponse response = new MetaRepositoryTypeEditableResponse();

            if (request.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            MetaRepositoryTypeEntity entity = metaRepositoryTypeRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = metaRepositoryTypeConvertor.toMoreVo(entity);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("update")]
        public MetaRepositoryTypeUpdateResponse Update([FromBody]MetaRepositoryTypeUpdateRequest request)
        {

            MetaRepositoryTypeUpdateResponse response = new MetaRepositoryTypeUpdateResponse();

            if (request.Id == 0 || request.Id < 0)
            {
                response.Status = -1;
                return response;
            }

            MetaRepositoryTypeEntity entity = metaRepositoryTypeRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            metaRepositoryTypeRepository.Update(metaRepositoryTypeConvertor.toEntity(request, entity));

            theMetaRepositoryTypeMeta.Refresh();

            response.Status = 1;
            return response;
        }
    }
}
