using System.Collections.Generic;
using System.Web.Mvc;

namespace Schoolmc1.Models
{
    public class RequestViewModel
    {
        public Request NewRequest { get; set; }
        public List<SelectListItem> StateId { get; set; }
        public int[] CourseIds { get; set; }

    }
}