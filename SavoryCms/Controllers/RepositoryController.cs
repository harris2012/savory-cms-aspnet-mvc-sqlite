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

namespace SavoryCms.Controllers
{
    [RoutePrefix("api/repository")]
    public class RepositoryController : BaseController
    {
        /// <summary>
        /// 分页，每页个数
        /// </summary>
        private static readonly int PAGE_SIZE = 15;

        private IRepositoryRepository repositoryRepository;

        private IRepositoryConvertor repositoryConvertor;

        public RepositoryController(IRepositoryRepository repositoryRepository, IRepositoryConvertor repositoryConvertor)
        {
            this.repositoryRepository = repositoryRepository;
            this.repositoryConvertor = repositoryConvertor;
        }

        [HttpPost]
        [Route("items")]
        public RepositoryItemsResponse Items([FromBody]RepositoryItemsRequest request)
        {
            RepositoryItemsResponse response = new RepositoryItemsResponse();

            List<RepositoryEntity> entityList = repositoryRepository.GetEntityList(request.PageIndex, PAGE_SIZE);

            response.Items = repositoryConvertor.toVoList(entityList);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("count")]
        public RepositoryCountResponse Count([FromBody]RepositoryCountRequest request)
        {

            RepositoryCountResponse response = new RepositoryCountResponse();

            int count = repositoryRepository.GetCount();

            response.TotalCount = count;

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("item")]
        public RepositoryItemResponse Item([FromBody]RepositoryItemRequest request)
        {

            RepositoryItemResponse response = new RepositoryItemResponse();

            if (request.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            RepositoryEntity entity = repositoryRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = repositoryConvertor.toVo(entity, false);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("create")]
        public RepositoryCreateResponse Create([FromBody]RepositoryCreateRequest request)
        {

            RepositoryCreateResponse response = new RepositoryCreateResponse();

            repositoryRepository.Create(repositoryConvertor.toEntity(request.Item));

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("editable")]
        public RepositoryEditableResponse Editable([FromBody]RepositoryEditableRequest request)
        {

            RepositoryEditableResponse response = new RepositoryEditableResponse();

            if (request.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            RepositoryEntity entity = repositoryRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = repositoryConvertor.toVo(entity, true);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("update")]
        public RepositoryUpdateResponse Update([FromBody]RepositoryUpdateRequest request)
        {

            RepositoryUpdateResponse response = new RepositoryUpdateResponse();

            if (request.Item.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            RepositoryEntity entity = repositoryRepository.GetById(request.Item.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            repositoryRepository.Update(repositoryConvertor.toEntity(request.Item));

            response.Status = 1;
            return response;
        }
    }
}