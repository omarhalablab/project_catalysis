using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalysis.Models
{
    public class CourseChapter
    {
        [Key]
        public int ChapterId { get; set; }
        public string ChapterName { get; set; }
        public string Description { get; set; }
        public int? Ordering { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? CourseId { get; set; }
        public string DurationDescription { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<ChapterVideo> ChapterVideos { get; set; }
    }
}
