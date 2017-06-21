using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;
using Schoolmc1.DTO;
using System.Data.Entity;
using System.Collections.Generic;

namespace Schoolmc1.Models.Repositories
{
    public class RequestRepository : BaseRepository<Request>
    {
        public RequestRepository(DbContext _context)
        {
            context = _context;
        }
        //get the courses
        public Request GetByIdWithCourses(int id)
        {
            return context.Set<Request>().Where(x => x.Id == id).Include("Courses").First();
        }

    }

}