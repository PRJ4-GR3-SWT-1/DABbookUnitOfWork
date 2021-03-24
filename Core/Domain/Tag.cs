using System;
using System.Collections.Generic;

namespace Queries.Core.Domain
{
    public partial class Tag
    {
        public Tag()
        {
            CourseTags = new HashSet<CourseTags>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CourseTags> CourseTags { get; set; }
    }
}
