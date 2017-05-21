using System;

namespace Schoolmc1.DTO
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; }
        public Nullable<System.DateTime> CourseTime { get; set; }
        public string CourseDay { get; set; }
        public Nullable<decimal> CourseFee { get; set; }
        public Nullable<int> Level { get; set; }
        public string Professor { get; set; }
        public Nullable<bool> CoreCourse { get; set; }

    }
}