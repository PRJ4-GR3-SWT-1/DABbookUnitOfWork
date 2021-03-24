using System;
using System.Collections.Generic;

namespace Queries.Core.Domain
{
    public partial class Cover
    {
        public int Id { get; set; }

        public virtual Course IdNavigation { get; set; }
    }
}
