using Schoolmc1.Models;
using Schoolmc1.DTO;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Schoolmc1.Models.Repositories;
using Schoolmc1.Helpers;
using System.Web.Http.Description;

namespace Schoolmc1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RequestController : ApiController
    {
        RequestRepository requestRepo;
        public RequestController()
        {
            var context = new SchoolDataEntities1();
            requestRepo = new RequestRepository(context);
        }

        public IEnumerable<RequestDto> Get()
        {
            return MappingHelper.MapRequest(requestRepo.Get());

        }
        [ResponseType(typeof(RequestDto))]
        public IHttpActionResult Get(int id)
        {
            RequestDto request = MappingHelper.MapRequest(requestRepo.GetById(id));
            //RequestDto request = MappingHelper.MapRequest(requestRepo.GetByIdWithCourses(id));
            //Request request = requestRepo.GetByIdWithCourses(id);
            if (request == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(request);
            }
        }

        [ResponseType(typeof(RequestDto))]
        public IHttpActionResult Put(int id, RequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != request.Id)
            {
                return BadRequest("Ids did not matched");
            }
            else 
            {
                requestRepo.UpdateWithCourses(id, request);
                requestRepo.Save();
                return Ok(request);

            }
        }

        [ResponseType(typeof(Request))]
        public IHttpActionResult Post([FromBody] Request request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                requestRepo.Insert(request);
                requestRepo.Save();
                return Ok(request);
            }
        }

        [ResponseType(typeof(Request))]

        public IHttpActionResult Delete(int id)
        {
            Request request = requestRepo.GetById(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != request.Id)
            {
                return BadRequest("Ids did not matched");
            }
            else
            {
                requestRepo.Delete(request);
                requestRepo.Save();
                return Ok(request);
            }

        }
    }
}
