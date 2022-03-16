using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace webApi.Models.Tags
{
    public class ArticleTagModel
    {
        public Guid ArticleId { get; set; }

        public Guid TagId { get; set; }
    }
}