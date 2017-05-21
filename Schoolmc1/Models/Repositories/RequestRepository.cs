using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;
using Schoolmc1.DTO;
using System.Data.Entity;

namespace Schoolmc1.Models.Repositories
{
    public class RequestRepository : BaseRepository<Request>
    {
        public RequestRepository(DbContext _context)
        {
            context = _context;
        }
      
    }

}