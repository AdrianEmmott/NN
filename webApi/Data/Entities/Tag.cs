using System;
using System.Collections.Generic;

#nullable disable

namespace webApi.Data.Entities
{
    public partial class Tag
    {
        public Tag()
        {
            ArticleTags = new HashSet<ArticleTag>();
            InverseParent = new HashSet<Tag>();
        }

        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Title { get; set; }
        public bool ShowInNav { get; set; }
        public int SortOrder { get; set; }

        public virtual Tag Parent { get; set; }
        public virtual ICollection<ArticleTag> ArticleTags { get; set; }
        public virtual ICollection<Tag> InverseParent { get; set; }
    }
}
