using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalysis.Models
{
    public class CourseImage
    {
        [Key]
        public int CourseImageId { get; set; }
        public string CourseImageName { get; set; }
        public string ImageUrl { get; set; }
        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
