using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Schoolmc1.DTO;
using Schoolmc1.Models.Repositories;

namespace Schoolmc1.Models.Repositories
{
    public class CourseRepository : BaseRepository<Course>
    {
        public CourseRepository(DbContext _context)
        {
            context = _context;
        }


    }
}