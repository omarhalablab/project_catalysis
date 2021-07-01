using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalysis.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? Rate { get; set; }

        public virtual Category Category { get; set; }
        public virtual User CreatedByNavigation { get; set; }
        public virtual ICollection<CourseChapter> CourseChapters { get; set; }
        public virtual ICollection<CourseImage> CourseImages { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}
