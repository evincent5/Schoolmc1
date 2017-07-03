using Schoolmc1.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Schoolmc1.Models
{
    [MetadataType(typeof(RequestMetadata))]

    public partial class Request
    {
    }

    public class RequestMetadata
    {
        //[RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", 
        //    ErrorMessage = "Please enter upper and lower case alphabets")]
        [Display(Name = "First Name")]
        public string FirstName;

        [StringLength(10, MinimumLength = 3)]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName;

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber;

        //[RegularExpression(@"/^\w{4,}@\w+[.]{1}(com|co.kr|go.kr|net|or.kr)$/g")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress;

        [Display(Name = "State")]
        public string StateId;

    }

    [MetadataType(typeof(CourseMetadata))]

    public partial class Course
    {
        //[System.ComponentModel.DataAnnotations.Compare("Professor")]
        //public string ConfirmProfessor { get; set; }
    }

    public class CourseMetadata
    {
        [MaxLength(6, ErrorMessage ="This field takes only six character")]
        [Display(Name = "Course")]
        public string CourseTitle;

        [DataType(DataType.Time)]
        //[DateRange("08:00")]
        [CurrentDate]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        [Display(Name = "Time")]
        public string CourseTime;

        [Display(Name = "Day")]
        public string CourseDay;

        [DataType(DataType.Currency)]
        [Range(10.0, 50.0)]
        [DisplayFormat(DataFormatString = "{0:c0}", ApplyFormatInEditMode = false)]
        [Display(Name = "Fee")]
        public float CourseFee;

        [Display(Name = "Core Course")]
        public string CoreCourse;

        //[RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$",
        //    ErrorMessage = "Please enter upper and lower case alphabets")]
        //[Remote("IsProfessorNameAvailable", "Home", ErrorMessage ="Professor already assigned")]
        public string  Professor{ get; set; }


    }
}