using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalysis.Models
{
    public class ChapterVideo
    {
        [Key]
        public int ChapterVideoId { get; set; }
        public string ChapterVideoName { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public int? ChapterId { get; set; }
        public string VideoUrl { get; set; }
        public int? Ordering { get; set; }
        public bool? CanComment { get; set; }
        public int? NumberOfLikes { get; set; }
        public int? NumberOfDislike { get; set; }
        public TimeSpan? Duration { get; set; }

        public virtual CourseChapter Chapter { get; set; }
        public virtual ICollection<UserChapterVideo> UserChapterVideos { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
        public virtual ICollection<VideoComments> VideoComments { get; set; }
    }
}
