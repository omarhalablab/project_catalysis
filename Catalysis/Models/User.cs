using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Catalysis.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(200)]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(200)]
        public string Email { get; set; }
        
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string ProfileImageUrl { get; set; }
        [NotMapped]
        public IFormFile image { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<UserChapterVideo> UserChapterVideos { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}
