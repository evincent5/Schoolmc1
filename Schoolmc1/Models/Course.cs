//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Schoolmc1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.Requests = new HashSet<Request>();
        }
    
        public int Id { get; set; }
        public string CourseTitle { get; set; }
        public Nullable<System.DateTime> CourseTime { get; set; }
        public string CourseDay { get; set; }
        public Nullable<decimal> CourseFee { get; set; }
        public Nullable<int> Level { get; set; }
        public string Professor { get; set; }
        public Nullable<bool> CoreCourse { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
