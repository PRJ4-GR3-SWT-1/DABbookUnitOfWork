using System;
using System.Collections.Generic;

namespace Queries.Core.Domain
{
    public partial class Course
    {
        public Course()
        {
            CourseTags = new HashSet<CourseTags>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public float FullPrice { get; set; }
        public int AuthorId { get; set; }
        public bool IsBeginnerCourse
        {
            get { return Level == 1; }
        }

        public virtual Author Author { get; set; }
        public virtual Cover Covers { get; set; }
        public virtual ICollection<CourseTags> CourseTags { get; set; }
    }
}
