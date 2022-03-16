using System;
using System.Collections.Generic;

#nullable disable

namespace webApi.Data.Entities
{
    public partial class ArticleTag
    {
        public Guid ArticleId { get; set; }
        public Guid TagId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
