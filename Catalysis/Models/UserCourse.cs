using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalysis.Models
{
    public class UserCourse
    {
        [Key]
        public int? UserId { get; set; }
        public int? CourseId { get; set; }
        public int UserCourseId { get; set; }
        public DateTime? JoiningTime { get; set; }
        public DateTime? LastSee { get; set; }
        public int? ChapterVideoId { get; set; }
        public TimeSpan? DurationStopped { get; set; }

        public virtual ChapterVideo ChapterVideo { get; set; }
        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
    }
}
