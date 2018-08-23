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
    [RoutePrefix("api/app")]
    public class AppController : BaseController
    {
        /// <summary>
        /// 分页，每页个数
        /// </summary>
        private static readonly int PAGE_SIZE = 15;

        private IAppRepository appRepository;

        private IAppConvertor appConvertor;

        public AppController(IAppRepository appRepository, IAppConvertor appConvertor)
        {
            this.appRepository = appRepository;
            this.appConvertor = appConvertor;
        }

        [HttpPost]
        [Route("items")]
        public AppItemsResponse Items([FromBody]AppItemsRequest request)
        {
            AppItemsResponse response = new AppItemsResponse();

            List<AppEntity> entityList = appRepository.GetEntityList(request.PageIndex, PAGE_SIZE);

            response.Items = appConvertor.toVoList(entityList);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("count")]
        public AppCountResponse Count([FromBody]AppCountRequest request)
        {

            AppCountResponse response = new AppCountResponse();

            int count = appRepository.GetCount();

            response.TotalCount = count;

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("item")]
        public AppItemResponse Item([FromBody]AppItemRequest request)
        {

            AppItemResponse response = new AppItemResponse();

            if (request.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            AppEntity entity = appRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = appConvertor.toVo(entity, false);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("create")]
        public AppCreateResponse Create([FromBody]AppCreateRequest request)
        {

            AppCreateResponse response = new AppCreateResponse();

            appRepository.Create(appConvertor.toEntity(request.Item));

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("editable")]
        public AppEditableResponse Editable([FromBody]AppEditableRequest request)
        {

            AppEditableResponse response = new AppEditableResponse();

            if (request.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            AppEntity entity = appRepository.GetById(request.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = appConvertor.toVo(entity, true);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("update")]
        public AppUpdateResponse Update([FromBody]AppUpdateRequest request)
        {

            AppUpdateResponse response = new AppUpdateResponse();

            if (request.Item.Id <= 0)
            {
                response.Status = -1;
                return response;
            }

            AppEntity entity = appRepository.GetById(request.Item.Id);
            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            appRepository.Update(appConvertor.toEntity(request.Item));

            response.Status = 1;
            return response;
        }
    }
}