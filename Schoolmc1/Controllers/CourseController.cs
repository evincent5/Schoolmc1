using Schoolmc1.DTO;
using Schoolmc1.Helpers;
using Schoolmc1.Models;
using Schoolmc1.Models.Repositories;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Schoolmc1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class CourseController : ApiController
    {
        CourseRepository courseRepo;
        public CourseController()  //h
        {
            var context = new SchoolDataEntities1();
            courseRepo = new CourseRepository(context);
        }
        public IEnumerable<CourseDto> Get()
        {
            IEnumerable<Course> course = courseRepo.Get();
            return MappingHelper.MapRequest(course);
        }

        [ResponseType(typeof(CourseDto))]
        public IHttpActionResult GetById(int id)
        {
            var course = courseRepo.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(MappingHelper.MapRequest(course));
            }
        }

        [ResponseType(typeof(Course))]

        public IHttpActionResult Put(int id, [FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != course.Id)
            {
                return BadRequest("Ids did not matched");
            }
            else
            {
                courseRepo.Update(id, course);
                courseRepo.Save();
                return Ok(course);
            }
        }

        [ResponseType(typeof(Course))]

        public IHttpActionResult Post([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                courseRepo.Insert(course);
                courseRepo.Save();
                return Ok(course);

            }

        }

        [ResponseType(typeof(Course))]
        public IHttpActionResult Delete(int id, [FromBody] Course course)
        {
            course = courseRepo.GetById(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != course.Id)
            {
                return BadRequest("Ids did not matched");
            }
            else
            {
                course = courseRepo.GetById(id);
                courseRepo.Delete(course);
                courseRepo.Save();
                return Ok(course);
            }
            
        }
    }
}
