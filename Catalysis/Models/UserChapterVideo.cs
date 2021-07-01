using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalysis.Models
{
    public class UserChapterVideo
    {
        [Key]
        public int UserChapterVideoId { get; set; }
        public int? UserId { get; set; }
        public int? VideoId { get; set; }
        public bool? IsFullyWatched { get; set; }
        public DateTime? LastTimeWatched { get; set; }

        public virtual User User { get; set; }
        public virtual ChapterVideo Video { get; set; }
    }
}
