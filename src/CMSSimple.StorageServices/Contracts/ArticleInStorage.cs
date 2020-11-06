using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CMSSimple.StorageServices.Contracts
{
    public class ArticleInStorage
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime? Timestamp { get; set; }
    }
}
