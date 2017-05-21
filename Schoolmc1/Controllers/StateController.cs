using Schoolmc1.DTO;
using Schoolmc1.Models;
using Schoolmc1.Models.Repositories;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper.QueryableExtensions;
using Schoolmc1.Helpers;
using System.Web.Http.Description;

namespace Schoolmc1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class StateController : ApiController
    {
        StateRepository stateRepo;
        public StateController()
        {
            var context = new SchoolDataEntities1();
            stateRepo = new StateRepository(context);
        }
        public IEnumerable<StateDto> Get()
        {
            IEnumerable<state> s = stateRepo.Get();
            return MappingHelper.MapRequest(s) ;
        }
        [ResponseType(typeof(StateDto))]
        public IHttpActionResult GetById(int id)
        {
            state s = stateRepo.GetById(id);
            if(s == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(MappingHelper.MapRequest(s));
            }
        }
    }
}
