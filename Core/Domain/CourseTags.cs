﻿using System;
using System.Collections.Generic;

namespace Queries.Core.Domain
{
    public partial class CourseTags
    {
        public int CourseId { get; set; }
        public int TagId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
