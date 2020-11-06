using System;
using System.Collections.Generic;
using System.Text;

namespace CMSSimple.BusinessLogic.Contracts
{
    public class ArticleContract
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime? Timestamp { get; set; }
    }
}
