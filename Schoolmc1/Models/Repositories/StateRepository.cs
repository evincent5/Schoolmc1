using AutoMapper.QueryableExtensions;
using Schoolmc1.DTO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Schoolmc1.Models.Repositories
{
    public class StateRepository : BaseRepository<state>
    {
        public StateRepository(DbContext _context)
        {
            context = _context;
        }

    }
}