using System.ComponentModel.DataAnnotations;

namespace Schoolmc1.Models
{
    [MetadataType(typeof(RequestMetadata))]

    public partial class Request
    {
    }

    public class RequestMetadata
    {
        [Display(Name = "First Name")]
        public string FirstName;

        [Display(Name = "Last Name")]
        public string LastName;

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber;

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress;

        [Display(Name = "State")]
        public string StateId;

    }

    [MetadataType(typeof(CourseMetadata))]

    public partial class Course
    {
    }

    public class CourseMetadata
    {
        [MaxLength(6, ErrorMessage ="This field takes only six character")]
        [Display(Name = "Course")]
        public string CourseTitle;

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        [Display(Name = "Time")]
        public string CourseTime;

        [Display(Name = "Day")]
        public string CourseDay;

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c0}", ApplyFormatInEditMode = false)]
        [Display(Name = "Fee")]
        public float CourseFee;

        [Display(Name = "Core Course")]
        public string CoreCourse;

    }
}