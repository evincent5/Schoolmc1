using AutoMapper;
using Schoolmc1.DTO;
using Schoolmc1.Models;
using System;

namespace Schoolmc1.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(
                cfg =>
                {
                    cfg.CreateMap<Request, RequestDto>()
                    .ForMember(destination => destination.StateName,
                     opt => opt.MapFrom(source => source.state.StateName));

                    cfg.CreateMap<Course, CourseDto>();
                    cfg.CreateMap<state, StateDto>();
                 }
                );
        }
    }
}


