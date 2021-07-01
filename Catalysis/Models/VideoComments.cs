using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalysis.Models
{
    public class VideoComments
    {
        [Key]
        public int VideoCommentId { get; set; }
        public string Comment { get; set; }
        public int? CommentedBy { get; set; }
        public bool? Approved { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public int? ApprovedBy { get; set; }
        public int ChapterVideoId { get; set; }

        public virtual ChapterVideo ChapterVideo { get; set; }
    }
}
