using System;
using System.Collections.Generic;

namespace webApi.Models.Tags
{
    public class TagModel
    {
        public Guid Id { get; set; }

        public Guid? ParentId {get; set; }

        public string Title { get; set; }

        public bool ShowInNav { get; set; }

        public int SortOrder { get; set; }

        public string Path { get; set; }

        public List<TagModel> Tags { get; set; }
    }
}