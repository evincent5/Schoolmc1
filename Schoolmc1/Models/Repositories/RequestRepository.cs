using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;
using Schoolmc1.DTO;
using System.Data.Entity;
using System.Collections.Generic;
using Schoolmc1.Helpers;

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
            //return context.Set<Request>().Where(x => x.Id == id).First();
            return context.Set<Request>().Where(x => x.Id == id).Include("Courses").First();
        }

        public void UpdateWithCourses(int id, RequestDto request)
        {
            Request requestWithCourses = GetByIdWithCourses(id);
            context.Entry(requestWithCourses).CurrentValues.SetValues(request);
            //List<Course> courses = context.Set<Course>().ToList();
            foreach(Course c in requestWithCourses.Courses)
            {
                if (!request.Courses.Any(x => x.Id == c.Id))
                {
                    requestWithCourses.Courses.Remove(c);
                }
                
            }
            foreach(CourseDto course in request.Courses)
            {
                //MappingHelper.MapCourseDto(course);
                Course cou = new Course();
                cou.Id = course.Id;
                cou.CourseTitle = course.CourseTitle;
                cou.CourseDay = course.CourseDay;
                cou.CourseTime = course.CourseTime;
                cou.CourseFee = course.CourseFee;
                cou.CoreCourse = course.CoreCourse;
                cou.Professor = course.Professor;
                cou.Level = course.Level;
                
               
                if (!request.Courses.Any(x => x.Id == course.Id))
                {
                    //context.Set<Course>().Attach(course);
                    //requestWithCourses.Courses.Add(course);
                }
            }
        }

    }

}