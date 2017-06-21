using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schoolmc1.DTO
{
    public class RequestDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public string EmailAddress { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}