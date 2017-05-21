using Schoolmc1.DTO;
using Schoolmc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schoolmc1.Helpers
{
    public static class MappingHelper
    {
        public static RequestDto MapRequest(Request request)
        {
            return AutoMapper.Mapper.Map<RequestDto>(request);
        }

        public static IEnumerable<RequestDto> MapRequest(
            IEnumerable<Request> request)
        {
            return AutoMapper.Mapper.Map<IEnumerable<RequestDto>>(request);
        }

        public static StateDto MapRequest(state s)
        {
            return AutoMapper.Mapper.Map<StateDto>(s);
        }

        public static IEnumerable<StateDto> MapRequest(
            IEnumerable<state> s)
        {
            return AutoMapper.Mapper.Map<IEnumerable<StateDto>>(s);
        }

        public static CourseDto MapRequest(Course course)
        {
            return AutoMapper.Mapper.Map<CourseDto>(course);
        }

        public static IEnumerable<CourseDto> MapRequest(
            IEnumerable<Course> course)
        {
            return AutoMapper.Mapper.Map<IEnumerable<CourseDto>>(course);
        }


    }
}