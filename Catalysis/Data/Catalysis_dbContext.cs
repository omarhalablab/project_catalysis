using Catalysis.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalysis.Data
{
    public class Catalysis_dbContext:DbContext
    {
        public Catalysis_dbContext(DbContextOptions<Catalysis_dbContext> option) : base(option)
        {

        }


        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ChapterVideo> ChapterVideos { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseChapter> CourseChapters { get; set; }
        public virtual DbSet<CourseImage> CourseImages { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserChapterVideo> UserChapterVideos { get; set; }
        public virtual DbSet<UserCourse> UserCourses { get; set; }
        public virtual DbSet<VideoComments> VideoComments { get; set; }
    }
}
